using System.Security.Claims;

using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository
{
    public interface ICustomerRepository : IGenericOwnedRepository<Customer, CustomerDTO>
    {
        public Task Seed(ClaimsPrincipal User);
    }
}
