namespace BlazorInvoiceApp.Repository
{
    public interface IRepositoryCollection : IDisposable
    {
        IInvoiceRepository Invoice { get; }
        ICustomerRepository Customer { get; }
        IInvoiceTermsRepository InvoiceTerms { get; }
        IInvoiceLineItemRepository InvoiceLineItems { get; }

        Task<int> Save();
    }
}
