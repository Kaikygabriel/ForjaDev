using ForjaDev.Domain.BackOffice.ValuesObject;

namespace ForjaDev.Application.Dtos.StoreFront.Member;

public record MemberDashBoardPublic
(
    DateTime CreateAt,
    IEnumerable<Domain.BackOffice.Entities.Post>Posts,
    string Name,
    string Email,
    string Bio,
    int FollowingsCount,
    int FollowingCount,
    IEnumerable<Link>Links);