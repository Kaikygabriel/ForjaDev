using ForjaDev.Application.Dtos.StoreFront.Posts;
using ForjaDev.Domain.BackOffice.Commum;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Query.Request;

public record GetAllPostByCategoryRequest(string CategoryName, int Skip = 0, int Take = 25)
    : IRequest<Result<IEnumerable<PostDto>>> ;
