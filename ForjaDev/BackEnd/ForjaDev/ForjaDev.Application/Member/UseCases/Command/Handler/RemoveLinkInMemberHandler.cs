using ForjaDev.Application.Member.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using MediatR;

namespace ForjaDev.Application.Member.UseCases.Command.Handler;

internal sealed  class RemoveLinkInMemberHandler : IRequestHandler<RemoveLinkInMemberRequest,Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveLinkInMemberHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveLinkInMemberRequest request, CancellationToken cancellationToken)
    {
        var member = await _unitOfWork.MemberRepository.GetByPredicateAsync
            (x => x.Id == request.MemberId);
        if (member is null)
            return new Error("Member.NotFound", "not found");

        var resultRemoveLink = member.RemoveLink(request.PlaceLink);
        if (!resultRemoveLink.IsSuccess)
            return resultRemoveLink.Error;

        _unitOfWork.MemberRepository.Update(member);
        await _unitOfWork.CommitAsync();
        
        return Result.Success();
    }
}