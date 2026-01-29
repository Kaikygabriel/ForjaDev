using ForjaDev.Application.Dtos.StoreFront.Posts;
using ForjaDev.Domain.BackOffice.Commum;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Query.Request;

public record GetPostByIdRequest(Guid PostId) : IRequest<Result<PostByIdDTo>>;