using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

public class AttendeConfiguration : IEntityTypeConfiguration<Attendee>
{
    public void Configure(EntityTypeBuilder<Attendee> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasIndex(a => a.Email).IsUnique();

        builder.HasOne(a => a.Profile)
            .WithOne(p => p.Attendee)
            .HasForeignKey<AttendeeProfile>(p => p.AttendeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(a => a.Orders)
            .WithOne(o => o.Attendee)
            .HasForeignKey(o => o.AttendeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(a => a.Tickets)
            .WithOne(t => t.Attendee)
            .HasForeignKey(t => t.AttendeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(a => a.Reviews)
            .WithOne(r => r.Attendee)
            .HasForeignKey(r => r.AttendeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
