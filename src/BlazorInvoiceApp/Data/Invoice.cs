using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

namespace BlazorInvoiceApp.Data
{
    public class Invoice : IEntity, IOwnedEntity
    {
        // Telling Db not to fill the Id field by default
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserId { get; set; } = null!;
        public IdentityUser? User { get; set; } = null!; // Navigation property

        // NOTE: Will not work with file based databases such as SQLite
        // Letting database to generate invoice numbers
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int InvoiceNumber { get; set; }

        // For file based databases only
        public string InvoiceNumber { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public string Description { get; set; } = String.Empty;

        public string CustomerId { get; set; } = String.Empty;
        public Customer? Customer { get; set; } = null!; // Navigation property

        public string InvoiceTermsId { get; set; } = String.Empty;
        public InvoiceTerms? InvoiceTerms { get; set; } = null!; // Navigation property

        public double Paid { get; set; } = 0;
        public double Credit { get; set; } = 0;
        public double TaxRate { get; set; } = 0;

        // For a single invoice there can be many invoice line items
        // Navigation property allow us to get all the invoice line items related to the invoice
        public ICollection<InvoiceLineItem> InvoiceLineItems { get; set; } = new List<InvoiceLineItem>(); // Navigation property
    }
}
