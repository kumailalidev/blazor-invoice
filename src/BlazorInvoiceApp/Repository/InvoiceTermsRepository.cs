using System.Security.Claims;

using AutoMapper;

using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

using Microsoft.EntityFrameworkCore;

namespace BlazorInvoiceApp.Repository
{
    public class InvoiceTermsRepository :
        GenericOwnedRepository<InvoiceTerms, InvoiceTermsDTO>,
        IInvoiceTermsRepository
    {
        public InvoiceTermsRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task Seed(ClaimsPrincipal User)
        {
            string? userId = getMyUserId(User);

            if (userId is not null)
            {
                int count = await context.InvoiceTerms.Where(it => it.UserId == userId)
                    .CountAsync();

                if (count == 0)
                {
                    // Seed some data
                    InvoiceTermsDTO terms1 = new InvoiceTermsDTO
                    {
                        Name = "Net 30"
                    };
                    InvoiceTermsDTO terms2 = new InvoiceTermsDTO
                    {
                        Name = "Net 60"
                    };
                    InvoiceTermsDTO terms3 = new InvoiceTermsDTO
                    {
                        Name = "Net 90"
                    };
                    await AddMine(User, terms1);
                    await AddMine(User, terms2);
                    await AddMine(User, terms3);
                }
            }
        }
    }
}
