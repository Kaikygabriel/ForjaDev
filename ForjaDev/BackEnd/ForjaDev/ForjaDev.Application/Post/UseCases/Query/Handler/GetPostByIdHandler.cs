using ForjaDev.Application.Dtos.StoreFront.Comments;
using ForjaDev.Application.Dtos.StoreFront.Posts;
using ForjaDev.Application.Post.UseCases.Query.Request;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Repositories;
using ForjaDev.Domain.BackOffice.Specification.Post;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Query.Handler;

internal sealed class GetPostByIdHandler : IRequestHandler<GetPostByIdRequest,Result<PostByIdDTo>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPostByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PostByIdDTo>> Handle(GetPostByIdRequest request, CancellationToken cancellationToken)
    {
        var post = await _unitOfWork.PostRepository.GetByIdWithMemberAsync(request.PostId);
        if (post is null)
            return Error.PostNotFound();
        var comments = await _unitOfWork.CommentRepository.GetAllByPostId(request.PostId);
        var commentsDto = CommentDto.ToCommentDtos(comments);

        var response = new PostByIdDTo(post.Member.Name, post.Title, post.Body, post.Tag,post.CreateAt, post.Likes.Count,
            commentsDto);
        return Result<PostByIdDTo>.Success(response);
    }
}