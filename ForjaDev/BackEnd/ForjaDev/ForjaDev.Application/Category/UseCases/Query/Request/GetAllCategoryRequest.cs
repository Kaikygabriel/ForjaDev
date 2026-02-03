using ForjaDev.Domain.BackOffice.Commum;
using MediatR;

namespace ForjaDev.Application.Category.UseCases.Query.Request;

public record GetAllCategoryRequest : IRequest<Result<IEnumerable<Domain.BackOffice.Entities.Category>>>;