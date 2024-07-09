using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository
{
    public interface IInvoiceRepository :
        IGenericOwnedRepository<Invoice, InvoiceDTO>
    {
    }
}
