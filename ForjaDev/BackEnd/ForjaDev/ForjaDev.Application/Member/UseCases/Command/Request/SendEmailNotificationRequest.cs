using ForjaDev.Domain.BackOffice.Abstract;
using MediatR;

namespace ForjaDev.Application.Member.UseCases.Command.Request;

public record SendEmailNotificationRequest(string EmailOfMember): IRequest<Result>;