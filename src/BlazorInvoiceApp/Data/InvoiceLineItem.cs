using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

namespace BlazorInvoiceApp.Data
{
    public class InvoiceLineItem : IEntity, IOwnedEntity
    {
        // Telling Db not to fill the Id field by default
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string InvoiceId { get; set; } = String.Empty;
        public Invoice? Invoice { get; set; } = null; // Navigation property

        public string Description { get; set; } = String.Empty;
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public double TotalPrice { get; private set; }

        public string UserId { get; set; } = null!;
        public IdentityUser? User { get; set; } = null; // Navigation property
    }
}
