using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasIndex(c => c.Name).IsUnique();

        builder.HasData(
            new Category { Id = 1, Name = "Music" },
            new Category { Id = 2, Name = "Sport" },
            new Category { Id = 3, Name = "Conference" },
            new Category { Id = 4, Name = "Theatre" },
            new Category { Id = 5, Name = "Festival" }
        );
    }
}
