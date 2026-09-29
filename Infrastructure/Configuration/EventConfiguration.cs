using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasIndex(e => new { e.Status, e.StartDate });

        builder.HasQueryFilter(e => !e.IsDeleted);

        builder.ToTable(t => t.HasCheckConstraint("CK_Events_EndDate_After_StartDate", "\"EndDate\" > \"StartDate\""));

        builder.HasMany(e => e.Categories)
            .WithMany(c => c.Events)
            .UsingEntity(j => j.ToTable("EventCategories"));

        builder.HasMany(e => e.TicketTypes)
            .WithOne(t => t.Event)
            .HasForeignKey(t => t.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.Reviews)
            .WithOne(r => r.Event)
            .HasForeignKey(r => r.EventId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
