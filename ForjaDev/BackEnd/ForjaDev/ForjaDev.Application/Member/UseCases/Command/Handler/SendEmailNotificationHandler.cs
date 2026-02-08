using ForjaDev.Application.Member.UseCases.Command.Request;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Interfaces.Services;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace ForjaDev.Application.Member.UseCases.Command.Handler;

internal sealed class SendEmailNotificationHandler : IRequestHandler<SendEmailNotificationRequest,Result>
{
    private readonly IMemoryCache _memoryCache;
    private readonly IServiceEmail _serviceEmail;
    private readonly IUnitOfWork _unitOfWork;

    public SendEmailNotificationHandler(IUnitOfWork unitOfWork, IServiceEmail serviceEmail, IMemoryCache memoryCache)
    {
        _unitOfWork = unitOfWork;
        _serviceEmail = serviceEmail;
        _memoryCache = memoryCache;
    }

    public async Task<Result> Handle(SendEmailNotificationRequest request, CancellationToken cancellationToken)
    {
        var member = await _unitOfWork.MemberRepository.GetByEmail(request.EmailOfMember);
        if (member is null)
            return new Error("Member.NotFound", "Not Found");
        
        var code = Guid.NewGuid().ToString("N")[0..5];
        _memoryCache.Set(code, member.User.Email.Address);

        await _serviceEmail.Send(EmailSendBuilder.Configure()
            .To(request.EmailOfMember)
            .WithBody(code)
            .WithTitle("Email de recuperação")
            .WithName(member.Name));
        
        return Result.Success();
    }
}