using ForjaDev.Application.Post.UseCases.Query.Request;
using ForjaDev.Application.Query.Interfaces;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Query.Handler;

internal sealed class GetPostByTitleHandler : 
    IRequestHandler<GetPostByTitleRequest,Result<IEnumerable<Domain.BackOffice.Entities.Post>>>
{
    private readonly IPostQuery _postQuery;

    public GetPostByTitleHandler(IPostQuery postQuery)
    {
        _postQuery = postQuery;
    }

    public async Task<Result<IEnumerable<Domain.BackOffice.Entities.Post>>> Handle(GetPostByTitleRequest request, CancellationToken cancellationToken)
    {
        if (request.Title.Length <= 0)
            return new Error("Title.Length.Invalid", "Length Small!");
        var posts = await _postQuery.GetByTitle(request.Title);
        return Result<IEnumerable<Domain.BackOffice.Entities.Post>>.Success(posts);
    }
}