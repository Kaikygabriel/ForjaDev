using ForjaDev.Application.Member.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace ForjaDev.Application.Member.UseCases.Command.Handler;

internal sealed class RestartPasswordByCodeHandler : IRequestHandler<RestartPasswordByCodeRequest,Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMemoryCache _memoryCache;

    public RestartPasswordByCodeHandler(IMemoryCache memoryCache, IUnitOfWork unitOfWork)
    {
        _memoryCache = memoryCache;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RestartPasswordByCodeRequest request, CancellationToken cancellationToken)
    {
        if (!_memoryCache.TryGetValue(request.Code, out string email))
            return new Error("Code.Invalid", "Code invalid");

        var member = await _unitOfWork.MemberRepository.GetByEmail(email);
        if (member is null)
            return new Error("Member Not Found", "Not Found");

        var resultUpdatePassword = member.User.Password.UpdatePassword(request.NewPassword);
        if (!resultUpdatePassword.IsSuccess)
            return resultUpdatePassword.Error;
        
        _unitOfWork.MemberRepository.Update(member);
        await _unitOfWork.CommitAsync();
        
        return Result.Success();
    }
}