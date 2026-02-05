using ForjaDev.Domain.BackOffice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForjaDev.Infra.Data.Mapping;

internal sealed class PostMap : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("post");

        builder.HasKey(x => x.Id)
            .HasName("pk_post");

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Body)
            .HasColumnName("body")
            .HasColumnType("Text")
            .IsRequired(true);

        builder.Property(x=>x.Title)
            .HasColumnName("title")
            .HasMaxLength(200)
            .HasColumnType("VARCHAR")
            .IsRequired(true);
        
        builder.Property(x=>x.Tag)
            .HasColumnName("tag")
            .HasMaxLength(180)
            .HasColumnType("VARCHAR")
            .IsRequired(true);

        builder.Property(x => x.CreateAt)
            .HasColumnName("create_at_utc")
            .HasColumnType("TIMESTAMPTZ")
            .IsRequired(true);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Posts)
            .HasForeignKey(x=>x.CategoryId)
            .HasConstraintName("fk_post_category")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(false);

        builder.Property(x => x.LikeCount)
            .HasColumnName("likes_count")
            .HasColumnType("INT")
            .HasDefaultValue(0)
            .IsRequired(true);
            
        builder.HasMany(x => x.Comments)
            .WithOne(x => x.Post)
            .HasForeignKey(x => x.PostId)
            .HasConstraintName("fk_comment_post")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(true);

        builder.HasOne(x => x.Member)
            .WithMany(x => x.Posts)
            .HasForeignKey(x => x.MemberId)
            .HasConstraintName("fk_post_member")
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}