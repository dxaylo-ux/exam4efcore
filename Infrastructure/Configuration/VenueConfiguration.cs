using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class VenueConfiguration : IEntityTypeConfiguration<Venue>
{
    public void Configure(EntityTypeBuilder<Venue> builder)
    {
        builder.HasKey(v => v.Id);

        builder.HasMany(v => v.Events)
            .WithOne(e => e.Venue)
            .HasForeignKey(e => e.VenueId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new Venue { Id = 1, Name = "Central Arena", Address = "Rudaki Avenue 10", City = "Dushanbe", Capacity = 5000 },
            new Venue { Id = 2, Name = "Sogd Hall", Address = "Lenin Street 25", City = "Khujand", Capacity = 1200 }
        );
    }
}
