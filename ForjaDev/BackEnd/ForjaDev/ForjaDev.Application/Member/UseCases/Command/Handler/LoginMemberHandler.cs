using ForjaDev.Application.Member.UseCases.Command.Request;
using ForjaDev.Application.Member.UseCases.Command.Response;
using ForjaDev.Application.Services.Interfaces;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Repositories;
using MediatR;

namespace ForjaDev.Application.Member.UseCases.Command.Handler;

internal sealed class LoginMemberHandler : IRequestHandler<LoginMemberRequest,Result<AuthMemberResponse>>
{
    private readonly IServiceUser _serviceUser;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;

    public LoginMemberHandler(IServiceUser serviceUser, IUnitOfWork unitOfWork, ITokenService tokenService)
    {
        _serviceUser = serviceUser;
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
    }

    public async Task<Result<AuthMemberResponse>> Handle(LoginMemberRequest request, CancellationToken cancellationToken)
    {
        var member = await _unitOfWork.MemberRepository.GetByEmail(request.Email);
        if (member is null)
            return Error.MemberNotFound();
        var resultPasswordIsValid = _serviceUser.CheckPassword(request.Password, member.User);
        if (!resultPasswordIsValid.IsSuccess)
            return resultPasswordIsValid.Error;
        
        var claims = _tokenService.GetClaimsByMember(member);
        var token = _tokenService.GenerateAccessToken(claims);

        var response = new AuthMemberResponse(member.Id, token);
        return Result<AuthMemberResponse>.Success(response);
    }
}