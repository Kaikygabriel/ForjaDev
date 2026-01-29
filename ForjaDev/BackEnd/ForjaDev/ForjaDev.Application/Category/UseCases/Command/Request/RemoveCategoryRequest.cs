using ForjaDev.Domain.BackOffice.Commum.Abstract;
using MediatR;

namespace ForjaDev.Application.Category.Command.Request;

public record RemoveCategoryRequest(Guid CategoryId) : IRequest<Result>;