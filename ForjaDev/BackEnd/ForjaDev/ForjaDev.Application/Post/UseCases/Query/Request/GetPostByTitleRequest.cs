using ForjaDev.Domain.BackOffice.Commum;
using MediatR;

namespace ForjaDev.Application.Post.UseCases.Query.Request;

public record GetPostByTitleRequest(string Title)  : IRequest<Result<IEnumerable<Domain.BackOffice.Entities.Post>>>;