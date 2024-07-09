using System.Security.Claims;

using AutoMapper;

using BlazorInvoiceApp.Data;
using BlazorInvoiceApp.DTOs;

using Microsoft.EntityFrameworkCore;

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

        public async Task DeleteWithLineItems(ClaimsPrincipal User, string invoiceId)
        {
            string? userId = getMyUserId(User);

            List<InvoiceLineItem> lineItems = await context.InvoiceLineItems
                .Where(i => i.InvoiceId == invoiceId && i.UserId == userId)
                .ToListAsync();
            foreach (InvoiceLineItem lineItem in lineItems)
            {
                context.InvoiceLineItems.Remove(lineItem);
            }

            Invoice? invoice = await context.Invoices
                .Where(i => i.Id == invoiceId && i.UserId == userId)
                .FirstOrDefaultAsync(); // Returns invoice or null
            if (invoice != null)
            {
                context.Invoices.Remove(invoice);
            }
        }

        public async Task<List<InvoiceDTO>> GetAllMineFlat(ClaimsPrincipal User)
        {
            string? userId = getMyUserId(User);

            var q = from i in context.Invoices.Where(i => i.UserId == userId)
                .Include(i => i.InvoiceLineItems) // Performing SQL Joining
                .Include(i => i.InvoiceTerms)
                .Include(i => i.Customer)
                    select new InvoiceDTO
                    {
                        Id = i.Id,
                        CreateDate = i.CreateDate,
                        InvoiceNumber = i.InvoiceNumber,
                        Description = i.Description,
                        CustomerId = i.CustomerId,
                        CustomerName = i.Customer!.Name,
                        InvoiceTermsId = i.InvoiceTermsId,
                        InvoiceTermsName = i.InvoiceTerms!.Name,
                        Paid = i.Paid,
                        Credit = i.Credit,
                        TaxRate = i.TaxRate,
                        UserId = i.UserId,
                        InvoiceTotal = i.InvoiceLineItems.Sum(a => a.TotalPrice)
                    };

            List<InvoiceDTO>? results = await q.ToListAsync();
            return results;
        }
    }
}
