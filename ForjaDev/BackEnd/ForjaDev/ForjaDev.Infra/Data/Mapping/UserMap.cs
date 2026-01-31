using ForjaDev.Domain.BackOffice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForjaDev.Infra.Data.Mapping;

internal sealed class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.HasKey(x => x.Id)
            .HasName("pk_user");

        builder.OwnsOne(x => x.Email, x =>
        {
            x.Property(x => x.Address)
                .HasColumnName("email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(220)
                .IsRequired(true);
        });
        builder.OwnsOne(x => x.Password, x =>
        {
            x.Property(x=>x.PasswordHash)
                .HasColumnName("password_hash")
                .HasColumnType("VARCHAR")
                .HasMaxLength(260)
                .IsRequired(true);
        });
        
    }
}