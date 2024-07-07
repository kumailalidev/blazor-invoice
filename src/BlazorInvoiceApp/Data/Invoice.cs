using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorInvoiceApp.Data
{
    public class Invoice : IEntity, IOwnedEntity
    {
        // Telling Db not to fill the Id field by default
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserId { get; set; } = null!;

        // Letting database to generate invoice numbers
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceNumber { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public string Description { get; set; } = String.Empty;

        public string CustomerId { get; set; } = String.Empty;

        public string InvoiceTermsId { get; set; } = String.Empty;
    }
}
