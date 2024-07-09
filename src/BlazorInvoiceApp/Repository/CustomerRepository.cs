using System.Security.Claims;

using AutoMapper;

using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

using Microsoft.EntityFrameworkCore;

namespace BlazorInvoiceApp.Repository
{
    public class CustomerRepository :
        GenericOwnedRepository<Customer, CustomerDTO>,
        ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context, IMapper mapper) :
            base(context, mapper)
        {
        }

        public async Task Seed(ClaimsPrincipal User)
        {
            string? userId = getMyUserId(User);
            if (User is not null)
            {
                int count = await context.Customers.Where(c => c.UserId == userId).CountAsync();

                if (count == 0)
                {
                    // Seed some data
                    CustomerDTO defaultCustomer = new CustomerDTO
                    {
                        Name = "My First Customer"
                    };
                    await AddMine(User, defaultCustomer);
                }
            }

            return;
        }
    }
}
