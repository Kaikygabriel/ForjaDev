using ForjaDev.Application.Member.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using MediatR;

namespace ForjaDev.Application.Member.UseCases.Command.Handler;

internal sealed class AddLinkInMemberHandler : IRequestHandler<AddLinkInMemberRequest,Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddLinkInMemberHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AddLinkInMemberRequest request, CancellationToken cancellationToken)
    {
        var resultCreateLink = request.ToEntity();
        if (!resultCreateLink.IsSuccess)
            return resultCreateLink.Error;

        var link = resultCreateLink.Value;
        
        var member = await _unitOfWork.MemberRepository.GetByPredicateAsync(x => x.Id == request.MemberId);
        if (member is null)
            return new Error("Member.NotFound", "Not Found !");
        
        member.AddLink(link);
        _unitOfWork.MemberRepository.Update(member);
        await _unitOfWork.CommitAsync();
        
        return Result.Success();
    }
}