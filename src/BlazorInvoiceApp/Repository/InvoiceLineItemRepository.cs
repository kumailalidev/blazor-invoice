using AutoMapper;

using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository
{
    public class InvoiceLineItemRepository :
        GenericOwnedRepository<InvoiceLineItem, InvoiceLineItemDTO>,
        IInvoiceLineItemRepository
    {
        public InvoiceLineItemRepository(ApplicationDbContext context, IMapper mapper) :
            base(context, mapper)
        {
        }
    }
}
