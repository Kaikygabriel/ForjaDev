using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Commum.Abstract;
using MediatR;

namespace ForjaDev.Application.Category.Command.Request;

public record CreateCategoryRequest(string Title) : IRequest<Result>
{
    public Result<Domain.BackOffice.Entities.Category> ToEntity()
        => Domain.BackOffice.Entities.Category.Factory.Create(Title); 
};