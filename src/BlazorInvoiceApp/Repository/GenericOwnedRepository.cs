using System.Linq.Expressions;
using System.Security.Claims;

using AutoMapper;

using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

using Microsoft.EntityFrameworkCore;

namespace BlazorInvoiceApp.Repository
{
    public class GenericOwnedRepository<TEntity, TDTO> : IGenericOwnedRepository<TEntity, TDTO>
        where TEntity : class, IEntity, IOwnedEntity
        where TDTO : class, IDTO, IOwnedDTO
    {
        public readonly ApplicationDbContext context;
        public readonly IMapper mapper;

        public GenericOwnedRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected string? getMyUserId(ClaimsPrincipal User)
        {
            Claim? uid = User?.FindFirst(type: "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

            if (uid is not null)
            {
                return uid.Value;
            }
            else
            {
                return null;
            }
        }

        public virtual async Task<List<TDTO>> GetAllMine(ClaimsPrincipal User)
        {
            string? userId = getMyUserId(User);

            if (userId is not null)
            {
                List<TEntity> entities = await context.Set<TEntity>()
                    .Where(e => e.UserId == userId)
                    .ToListAsync();
                List<TDTO> result = mapper.Map<List<TDTO>>(entities);

                return result;
            }
            else
            {
                return new List<TDTO>();
            }
        }

        public virtual async Task<TDTO> GetMineById(ClaimsPrincipal User, string id)
        {
            string? userId = getMyUserId(User);

            if (userId is not null)
            {
                TEntity? entity = await context.Set<TEntity>()
                    .Where(entity => entity.Id == id && entity.UserId == userId)
                    .FirstOrDefaultAsync();
                TDTO result = mapper.Map<TDTO>(entity);

                return result;
            }
            else
            {
                return null!;
            }
        }

        public virtual async Task<string> AddMine(ClaimsPrincipal User, TDTO dto)
        {
            string? userId = getMyUserId(User);

            if (userId is not null)
            {
                dto.UserId = userId; // DTO 
                dto.Id = Guid.NewGuid().ToString();

                TEntity toAdd = mapper.Map<TEntity>(dto);
                await context.Set<TEntity>().AddAsync(toAdd);

                return toAdd.Id;
            }
            else
            {
                return null!;
            }
        }

        public virtual async Task<TDTO> UpdateMine(ClaimsPrincipal User, TDTO dto)
        {
            string? userId = getMyUserId(User);

            if (userId is not null)
            {
                TEntity? toUpdate = await context.Set<TEntity>()
                    .Where(entity => entity.Id == dto.Id && entity.UserId == userId)
                    .FirstOrDefaultAsync();
                if (toUpdate is not null)
                {
                    mapper.Map<TDTO, TEntity>(dto, toUpdate);
                    context.Entry(toUpdate).State = EntityState.Modified;
                    TDTO result = mapper.Map<TDTO>(toUpdate);

                    // Changes to database will not be applied here...

                    return result;
                }
                else
                {
                    return null!;
                }
            }
            else
            {
                return null!;
            }
        }

        public virtual async Task<bool> DeleteMine(ClaimsPrincipal User, string id)
        {
            string? userId = getMyUserId(User);

            if (userId is not null)
            {
                TEntity? entity = await context.Set<TEntity>()
                    .Where(entity => entity.Id == id && entity.UserId == userId)
                    .FirstOrDefaultAsync();

                if (entity is not null)
                {
                    context.Remove(entity);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        protected async Task<List<TDTO>> GenericQuery(
            ClaimsPrincipal User,
            Expression<Func<TEntity, bool>>? expression, // SQL Query
            List<Expression<Func<TEntity, object>>> includes) // SQL Join
        {
            string? userId = getMyUserId(User);

            if (userId is not null)
            {
                IQueryable<TEntity> query = context.Set<TEntity>()
                    .Where(e => e.UserId == userId);

                if (expression is not null)
                    query = query.Where(expression);

                if (includes is not null)
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(include);
                    }
                }

                List<TEntity> entities = await query.ToListAsync();
                List<TDTO> result = mapper.Map<List<TDTO>>(entities);
                return result;
            }
            else
            {
                return new List<TDTO>();
            }
        }
    }
}
