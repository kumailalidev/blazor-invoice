using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorInvoiceApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    // Database Tables
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<InvoiceTerms> InvoiceTerms { get; set; }
    public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    // Disabling cascading deletes
    public void RemoveFixups(ModelBuilder modelBuilder, Type type)
    {
        foreach (var relationship in modelBuilder.Model.FindEntityType(type)!.GetForeignKeys())
        {
            relationship.DeleteBehavior = DeleteBehavior.ClientNoAction;
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Customizations; How database tables are created
        RemoveFixups(modelBuilder: builder, type: typeof(Invoice));
        RemoveFixups(modelBuilder: builder, type: typeof(Customer));
        RemoveFixups(modelBuilder: builder, type: typeof(InvoiceTerms));
        RemoveFixups(modelBuilder: builder, type: typeof(InvoiceLineItem));

        builder.Entity<Invoice>().Property(u => u.InvoiceNumber).Metadata
               .SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        // Telling EF not to create a column 'Total Price' in Db,
        // make it as a computed column
        builder.Entity<InvoiceLineItem>()
            .Property(u => u.TotalPrice)
            .HasComputedColumnSql(sql: "[UnitPrice] * [Quantity]");

        base.OnModelCreating(builder);
    }
}
