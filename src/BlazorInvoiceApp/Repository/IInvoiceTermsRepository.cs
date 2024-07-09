using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

namespace BlazorInvoiceApp.Repository
{
    public interface IInvoiceTermsRepository :
        IGenericOwnedRepository<InvoiceTerms, InvoiceTermsDTO>
    {
    }
}
