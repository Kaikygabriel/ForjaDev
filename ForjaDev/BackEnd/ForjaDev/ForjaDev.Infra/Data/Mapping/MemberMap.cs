using System.Text.Json;
using System.Text.Json.Serialization;
using ForjaDev.Domain.BackOffice.Entities;
using ForjaDev.Domain.BackOffice.ValuesObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForjaDev.Infra.Data.Mapping;

internal sealed class MemberMap : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("member");

        builder.HasKey(x => x.Id)
            .HasName("pk_member");

        builder.Property(x => x.CreateAt)
            .HasColumnName("created_at_utc")
            .HasColumnType("TIMESTAMPTZ")
            .IsRequired(true);

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(200)
            .IsRequired(true);
        
        builder.Property(x => x.Bio)
            .HasColumnName("bio")
            .HasColumnType("TEXT")
            .IsRequired(true);
        
        builder.Property(x => x.Slug)
            .HasColumnName("slug")
            .HasColumnType("VARCHAR")
            .HasMaxLength(200)
            .IsRequired(true);

        builder.HasOne(x => x.User)
            .WithOne()
            .HasForeignKey<Member>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(true);

        builder.OwnsOne(x => x.Role, x =>
        {
            x.Property(x => x.Title)
                .HasColumnName("role_title")
                .HasColumnType("VARCHAR")
                .HasMaxLength(150)
                .IsRequired(false);
        });
        builder.Property(x => x.Links)
            .HasColumnType("jsonb")
            .HasColumnName("links")
            .HasConversion(
                x => 
                    JsonSerializer.Serialize(x),
                x=>
                    string.IsNullOrWhiteSpace(x) ?
                        new List<Link>(): 
                        JsonSerializer.Deserialize<List<Link>>(x) ?? new()
            )
          ;

    }
}