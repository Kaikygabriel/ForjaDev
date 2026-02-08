using ForjaDev.Domain.BackOffice.Commum;
using MediatR;

namespace ForjaDev.Application.Member.UseCases.Query.Request;

public record GetPostByFollowsRequest(Guid MemberId) :
    IRequest<Result<List<Domain.BackOffice.Entities.Post>>>;