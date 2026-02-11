using ForjaDev.Application.Category.Command.Request;
using ForjaDev.Domain.BackOffice.Abstract;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Repositories;
using MediatR;

namespace ForjaDev.Application.Category.UseCases.Command.Command;

internal sealed class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest,Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var createCategoryResult = request.ToEntity();
        if (!createCategoryResult.IsSuccess)
            return createCategoryResult.Error;
        
        var category = createCategoryResult.Value;
        
        _unitOfWork.CategoryRepository.Create(category);
        await _unitOfWork.CommitAsync();

        return Result.Success();
    }
}