using System.Security.Claims;
using ForjaDev.Application.Comment.Command.Request;
using ForjaDev.Application.Comment.UseCases.Command.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    
    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Create(CreateCommentRequest request)
    {
        var claims = User;
        if (VerifyAuthorization(request.MemberId, claims))
            return Forbid();
        var response = await _mediator.Send(request);
        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }
    
    [Authorize]
    [HttpPost("SubComment")]
    public async Task<ActionResult> CreateSubComment(CreateSubCommentRequest request)
    {
        var claims = User;
        if (VerifyAuthorization(request.MemberId, claims))
            return Forbid();
        var response = await _mediator.Send(request);
        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }
    
    [Authorize]
    [HttpDelete]
    public async Task<ActionResult> DeleteComment([FromQuery]RemoveCommentRequest request)
    {
        var claims = User;
        if (VerifyAuthorization(request.MemberId, claims))
            return Forbid();
        var response = await _mediator.Send(request);
        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }

    private bool VerifyAuthorization(Guid memberId, ClaimsPrincipal claims)
        => !memberId.ToString().Equals(claims.Identity!.Name);
}