using ForjaDev.Domain.BackOffice.Commum.Abstract;
using MediatR;

namespace ForjaDev.Application.Member.UseCases.Command.Request;

public record RestartPasswordByCodeRequest(string Code,string NewPassword) : IRequest<Result>;