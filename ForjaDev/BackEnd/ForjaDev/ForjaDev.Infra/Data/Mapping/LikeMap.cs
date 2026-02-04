using ForjaDev.Domain.BackOffice.ValuesObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForjaDev.Infra.Data.Mapping;

internal sealed class LikeMap : IEntityTypeConfiguration<Like> 
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.ToTable("Like");

        builder.HasKey(x => x.Id)
            .HasName("pk_like");

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.HasOne(x => x.Member)
            .WithMany()
            .HasForeignKey(x => x.MemberId)
            .HasConstraintName("fk_like_member")
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(x => x.Post)
            .WithMany(x=>x.Likes)
            .HasForeignKey(x => x.PostId)
            .HasConstraintName("fk_like_post")
            .OnDelete(DeleteBehavior.NoAction);

    }
}