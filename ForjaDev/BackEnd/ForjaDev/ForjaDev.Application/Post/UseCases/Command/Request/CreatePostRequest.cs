using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Command.Request;

public record CreatePostRequest(Guid MemberId,string Title,string Body,Guid CategoryId = default) : IRequest<Result>
{
    public Result<Domain.BackOffice.Entities.Post> ToEntity()
        => Domain.BackOffice.Entities.Post.Factory.Create(Title, Body, MemberId, CategoryId);
}