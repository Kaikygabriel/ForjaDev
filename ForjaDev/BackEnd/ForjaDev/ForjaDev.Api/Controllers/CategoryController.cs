using ForjaDev.Application.Category.Command.Request;
using ForjaDev.Application.Category.UseCases.Query.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ForjaDev.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateCategoryRequest request)
    {
        throw new Exception("teste");
        var response = await _mediator.Send(request);
        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetAllCategoryRequest());
        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }
}