using ForjaDev.Application.Category.UseCases.Query.Request;
using ForjaDev.Domain.BackOffice.Commum;
using ForjaDev.Domain.BackOffice.Interfaces.Repositories;
using ForjaDev.Domain.BackOffice.Repositories;
using MediatR;

namespace ForjaDev.Application.Category.UseCases.Query.Handler;

internal sealed class GetAllCategoryHandler  :IRequestHandler<GetAllCategoryRequest,Result<IEnumerable<Domain.BackOffice.Entities.Category>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<Domain.BackOffice.Entities.Category>>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
    {
        var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
        if (categories is null)
            return new Error("Categories.NotFound", "Not Found !");
        return Result<IEnumerable<Domain.BackOffice.Entities.Category>>.Success(categories);
    }
}