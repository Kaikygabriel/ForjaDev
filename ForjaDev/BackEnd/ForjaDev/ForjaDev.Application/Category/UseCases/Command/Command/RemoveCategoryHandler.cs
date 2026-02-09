using ForjaDev.Application.Category.Command.Request;
using ForjaDev.Domain.BackOffice.Abstract;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Repositories;
using MediatR;

namespace ForjaDev.Application.Category.UseCases.Command.Command;

internal sealed class RemoveCategoryHandler : IRequestHandler<RemoveCategoryRequest,Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemoveCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByPredicateAsync(x => x.Id == request.CategoryId);
        if (category is null)
            return new Error("Category.NotFound","Not Found");
        _unitOfWork.CategoryRepository.Delete(category);
        await _unitOfWork.CommitAsync();
        
        return Result.Success();
    }
}