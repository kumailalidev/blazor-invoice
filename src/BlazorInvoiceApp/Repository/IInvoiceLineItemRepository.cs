using System.Security.Claims;

using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository
{
    public interface IInvoiceLineItemRepository :
        IGenericOwnedRepository<InvoiceLineItem, InvoiceLineItemDTO>
    {
        public Task<List<InvoiceLineItemDTO>> GetAllByInvoiceId(ClaimsPrincipal User, string invoiceId);
    }
}
