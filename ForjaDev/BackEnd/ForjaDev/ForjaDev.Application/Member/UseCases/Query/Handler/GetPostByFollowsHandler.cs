using ForjaDev.Application.Member.UseCases.Query.Request;
using ForjaDev.Application.Query.Interfaces;
using ForjaDev.Domain.BackOffice.Commum;
using MediatR;

namespace ForjaDev.Application.Member.UseCases.Query.Handler;

internal sealed class GetPostByFollowsHandler : 
    IRequestHandler<GetPostByFollowsRequest,Result<List<Domain.BackOffice.Entities.Post>>>
{
    private readonly IMemberQuery _memberQuery;

    public GetPostByFollowsHandler(IMemberQuery memberQuery)
    {
        _memberQuery = memberQuery;
    }

    public async Task<Result<List<Domain.BackOffice.Entities.Post>>> Handle(GetPostByFollowsRequest request, CancellationToken cancellationToken)
    {
        var posts = await _memberQuery.GetPostsByFollows(request.MemberId);
        return Result<List<Domain.BackOffice.Entities.Post>>.Success(posts.ToList());
    }
}