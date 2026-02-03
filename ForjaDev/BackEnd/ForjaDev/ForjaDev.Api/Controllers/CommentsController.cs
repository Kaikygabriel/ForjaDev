using ForjaDev.Application.Comment.Command.Request;
using ForjaDev.Application.Comment.UseCases.Command.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ForjaDev.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<ActionResult> Create(CreateCommentRequest request)
    {
        var response = await _mediator.Send(request);
        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }
    
    [HttpPost("SubComment")]
    public async Task<ActionResult> CreateSubComment(CreateSubCommentRequest request)
    {
        var response = await _mediator.Send(request);
        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }
    
    [HttpDelete]
    public async Task<ActionResult> DeleteComment([FromQuery]RemoveCommentRequest request)
    {
        var response = await _mediator.Send(request);
        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }
}