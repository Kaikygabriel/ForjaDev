namespace ForjaDev.Application.Dtos.StoreFront.Member;

public record MemberDashBoardPublic
(
    DateTime CreateAt,
    IEnumerable<Domain.BackOffice.Entities.Post>Posts,
    string Name,
    int FollowingsCount,
    int FollowingCount
);