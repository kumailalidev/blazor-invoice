using AutoMapper;

using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository
{
    public class InvoiceRepository :
        GenericOwnedRepository<Invoice, InvoiceDTO>,
        IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context, IMapper mapper) :
            base(context, mapper)
        {
        }
    }
}
