using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorInvoiceApp.Data
{
    public class InvoiceTerms : IEntity, IOwnedEntity
    {
        // Telling Db not to fill the Id field by default
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserId { get; set; } = null!;

        public string Name { get; set; } = String.Empty;
    }
}
