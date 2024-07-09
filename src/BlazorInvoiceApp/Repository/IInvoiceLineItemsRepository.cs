using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository
{
    public interface IInvoiceLineItemsRepository :
        IGenericOwnedRepository<InvoiceLineItem, InvoiceLineItemDTO>
    {
    }
}
