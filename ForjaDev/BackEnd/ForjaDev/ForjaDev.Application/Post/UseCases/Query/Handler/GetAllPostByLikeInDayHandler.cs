using ForjaDev.Application.Dtos.StoreFront.Posts;
using ForjaDev.Application.Post.UseCases.Query.Request;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Query.Handler;

internal sealed class GetAllPostByLikeInDayHandler : IRequestHandler<GetAllPostByLikesInDayRequest,Result<IEnumerable<PostDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPostByLikeInDayHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<PostDto>>> Handle(GetAllPostByLikesInDayRequest request, CancellationToken cancellationToken)
    {
        var posts = await _unitOfWork.PostRepository.GetAllByLikesAsync
            (request.Skip, request.Take);
        if (posts is null)
            return new Error("Posts.NotFound", "Not Found");
        var postsDtos = PostDto.ToPostDtos(posts);

        return Result<IEnumerable<PostDto>>.Success(postsDtos);
    }
}