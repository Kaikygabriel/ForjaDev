using ForjaDev.Domain.BackOffice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForjaDev.Infra.Data.Mapping;

internal sealed class CommentMap  : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("comment");

        builder.HasKey(x => x.Id)
            .HasName("pk_comment");

        builder.Property(x => x.Message)
            .HasColumnName("message")
            .HasColumnType("TEXT")
            .IsRequired(true);
        
        builder.Property(x=>x.CreateAt)
            .HasColumnName("create_at_utc")
            .HasColumnType("TIMESTAMPTZ")
            .IsRequired(true);

        builder.HasOne(x => x.Member)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.MemberId)
            .HasConstraintName("fk_comment_member")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(true);

        builder.HasOne(x => x.ParentComment)
            .WithMany(x => x.SubComments)
            .HasForeignKey(x => x.ParentCommentId)
            .HasConstraintName("fk_comment_parent_comment")
            .IsRequired(false);
        
        
    }
}