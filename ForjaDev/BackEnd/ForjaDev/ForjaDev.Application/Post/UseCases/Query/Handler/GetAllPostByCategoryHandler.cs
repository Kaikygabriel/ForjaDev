using ForjaDev.Application.Dtos.StoreFront.Posts;
using ForjaDev.Application.Post.UseCases.Query.Request;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Query.Handler;

internal sealed class GetAllPostByCategoryHandler :
    IRequestHandler<GetAllPostByCategoryRequest,Result<IEnumerable<PostDto>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPostByCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<PostDto>>> Handle(GetAllPostByCategoryRequest request, CancellationToken cancellationToken)
    {
        var posts = await _unitOfWork.PostRepository.GetAllByTitleCategoryAsync(
            request.CategoryName, request.Skip, request.Take);
        var response = PostDto.ToPostDtos(posts);

        return Result<IEnumerable<PostDto>>.Success(response);
    }
}