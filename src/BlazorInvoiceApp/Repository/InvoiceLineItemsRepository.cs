using AutoMapper;

using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository
{
    public class InvoiceLineItemsRepository :
        GenericOwnedRepository<InvoiceLineItem, InvoiceLineItemDTO>,
        IInvoiceLineItemsRepository
    {
        public InvoiceLineItemsRepository(ApplicationDbContext context, IMapper mapper) :
            base(context, mapper)
        {
        }
    }
}
