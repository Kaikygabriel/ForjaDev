using ForjaDev.Domain.BackOffice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForjaDev.Infra.Data.Mapping;

internal sealed class FollowingMap : IEntityTypeConfiguration<Following>
{
    public void Configure(EntityTypeBuilder<Following> builder)
    {
        builder.ToTable("following");

        builder.HasKey(x => x.Id)
            .HasName("pk_following");

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.HasOne(x => x.FollowingMember)
            .WithMany() // Normalmente não mapeamos a lista de 'Followers' de volta aqui por enquanto
            .HasForeignKey(x => x.FollowingMemberId)
            .HasConstraintName("fk_following_target_member")
            .IsRequired();
        
        builder.HasOne(x => x.MemberToFollow)
            .WithMany(m => m.Followings) // Esta é a lista que está na sua classe Member
            .HasForeignKey(x => x.MemberToFollowId) // CORRIGIDO: Apontando para o ID
            .HasConstraintName("fk_following_follower_member")
            .IsRequired();

        builder.HasIndex(x => new { x.MemberToFollowId, x.FollowingMemberId }) // CORRIGIDO: Usando IDs
            .IsUnique()
            .HasDatabaseName("ix_following_unique_relationship");
    }
}