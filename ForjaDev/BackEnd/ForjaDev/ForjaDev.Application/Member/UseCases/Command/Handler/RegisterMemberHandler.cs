using ForjaDev.Application.Member.UseCases.Command.Request;
using ForjaDev.Application.Member.UseCases.Command.Response;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Interfaces.Services;
using MediatR;

namespace ForjaDev.Application.Member.UseCases.Command.Handler;

internal  sealed class RegisterMemberHandler : IRequestHandler<RegisterMemberRequest,Result<AuthMemberResponse>>
{
    private readonly ITokenService _serviceToken;
    private readonly IServiceUser _serviceUser;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterMemberHandler(IUnitOfWork unitOfWork, IServiceUser serviceUser, ITokenService serviceToken)
    {
        _unitOfWork = unitOfWork;
        _serviceUser = serviceUser;
        _serviceToken = serviceToken;
    }

    public async Task<Result<AuthMemberResponse>> Handle(RegisterMemberRequest request, CancellationToken cancellationToken)
    {
        var resultCreateMember = request.ToEntity();
        if (!resultCreateMember.IsSuccess)
            return resultCreateMember.Error;

        var member = resultCreateMember.Value;
        var resultEmailExists = await _serviceUser.EmailExists(member.User.Email.Address);
        if (!resultEmailExists.IsSuccess)
            return resultEmailExists.Error;

        var claims = _serviceToken.GetClaimsByMember(member);
        var token = _serviceToken.GenerateAccessToken(claims);
        
        _unitOfWork.MemberRepository.Create(member);
        await _unitOfWork.CommitAsync();

        var response = new AuthMemberResponse(member.Id, token);
        return Result<AuthMemberResponse>.Success(response);
    }
}