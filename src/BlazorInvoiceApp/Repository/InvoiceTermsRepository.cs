using AutoMapper;

using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository
{
    public class InvoiceTermsRepository :
        GenericOwnedRepository<InvoiceTerms, InvoiceTermsDTO>,
        IInvoiceTermsRepository
    {
        public InvoiceTermsRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
