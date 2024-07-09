using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository
{
    public interface ICustomerRepository : IGenericOwnedRepository<Customer, CustomerDTO>
    {
    }
}
