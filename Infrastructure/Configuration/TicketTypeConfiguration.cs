using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TicketTypeConfiguration : IEntityTypeConfiguration<TicketType>
{
    public void Configure(EntityTypeBuilder<TicketType> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Price).HasPrecision(10, 2);

        builder.ToTable(t =>
        {
            t.HasCheckConstraint("CK_TicketTypes_Quantity_NonNegative", "\"Quantity\" >= 0");
            t.HasCheckConstraint("CK_TicketTypes_SoldCount_NotMoreThanQuantity", "\"SoldCount\" <= \"Quantity\"");
        });

        builder.HasMany(t => t.Tickets)
            .WithOne(x => x.TicketType)
            .HasForeignKey(x => x.TicketTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
