using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository
{
    public interface IInvoiceLineItemRepository :
        IGenericOwnedRepository<InvoiceLineItem, InvoiceLineItemDTO>
    {
    }
}
