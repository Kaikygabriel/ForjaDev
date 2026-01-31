using ForjaDev.Application.Dtos.StoreFront.Member;

namespace ForjaDev.Application.Query.Interfaces;

public interface IMemberQuery
{
    Task<MemberDashBoardPublic?> GetDashBoardPublicBySlug(string slugMember);
}