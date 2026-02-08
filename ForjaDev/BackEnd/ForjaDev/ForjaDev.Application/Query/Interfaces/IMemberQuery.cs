using ForjaDev.Application.Dtos.StoreFront.Member;

namespace ForjaDev.Application.Query.Interfaces;

public interface IMemberQuery
{
    Task<IEnumerable<Domain.BackOffice.Entities.Post>> GetPostsByFollows(Guid memberId);

    Task<MemberDashBoardPublic?> GetDashBoardPublicBySlug(string memberSlug);
    Task<MemberDashBoardPrivate?> GetDashBoardPrivateById(Guid memberId);

}