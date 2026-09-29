using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasIndex(r => new { r.EventId, r.AttendeeId }).IsUnique();

        builder.ToTable(t => t.HasCheckConstraint("CK_Reviews_Rating_Range", "\"Rating\" >= 1 AND \"Rating\" <= 5"));
    }
}
