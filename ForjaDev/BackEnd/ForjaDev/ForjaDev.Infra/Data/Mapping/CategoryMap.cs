using ForjaDev.Domain.BackOffice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForjaDev.Infra.Data.Mapping;

internal sealed class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("category");

        builder.HasKey(x => x.Id)
            .HasName("pk_category");

        builder.Property(x =>x.Id )
            .ValueGeneratedNever();

        builder.Property(x => x.Title)
            .HasColumnName("title")
            .HasColumnType("VARCHAR")
            .HasMaxLength(180)
            .IsRequired(true);

    }
}