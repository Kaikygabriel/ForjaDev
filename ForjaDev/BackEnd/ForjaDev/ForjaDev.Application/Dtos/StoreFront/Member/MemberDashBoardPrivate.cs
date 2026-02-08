using ForjaDev.Domain.BackOffice.ValuesObject;

namespace ForjaDev.Application.Dtos.StoreFront.Member;

public record MemberDashBoardPrivate(
    Guid Id,
    DateTime CreateAt,
    IEnumerable<Domain.BackOffice.Entities.Post>Posts,
    string Name,
    string Email,
    string Bio,
    string Slug,
    int FollowingsCount,
    int FollowingCount,
    IEnumerable<Link>Links
);