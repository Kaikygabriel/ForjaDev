using ForjaDev.Domain.BackOffice.Abstract;
using ForjaDev.Domain.BackOffice.Commum;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Command.Request;

public record CreatePostRequest(Guid MemberId,string Title,string Body,string Tag,Guid CategoryId = default) : IRequest<Result>
{
    public Result<Domain.BackOffice.Entities.Post> ToEntity()
        => Domain.BackOffice.Entities.Post.Factory.Create(Title, Body, MemberId, Tag,CategoryId);
}