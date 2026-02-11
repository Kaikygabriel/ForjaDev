using System.Security.Claims;
using ForjaDev.Application.Post.UseCases.Command.Request;
using ForjaDev.Application.Post.UseCases.Query.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForjaDev.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PostsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreatePostRequest request) 
    {
        var claims = User;
        if (VerifyAuthorization(request.MemberId, claims))
            return Forbid();
        
        var response = await _mediator.Send(request);
        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }
    
    [Authorize]
    [HttpPost("AddedLike")]
    public async Task<ActionResult> AddedLike([FromBody] AddedLikeRequest request) 
    {
        var claims = User;
        if (VerifyAuthorization(request.MemberId, claims))
            return Forbid();
        
        var response = await _mediator.Send(request);
        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }
    
    [Authorize]
    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] RemovePostRequest request) 
    {
        var claims = User;
        if (VerifyAuthorization(request.MemberId, claims))
            return Forbid();
        
        var response = await _mediator.Send(request);
        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }
    
    [Authorize]
    [HttpDelete("RemoveLike")]
    public async Task<ActionResult> RemoveLike([FromQuery] RemoveLikeRequest request) 
    {
        var claims = User;
        if (VerifyAuthorization(request.MemberId, claims))
            return Forbid();
        
        var response = await _mediator.Send(request);
        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }
    
    private bool VerifyAuthorization(Guid memberId, ClaimsPrincipal claims)
        => !memberId.ToString().Equals(claims.Identity!.Name);

    
    #region get

    
        [HttpGet("GetAllPostByLikes")]
        public async Task<ActionResult> GetAllPostByLikes([FromQuery] GetAllPostByLikesInDayRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
        }
        
        [HttpGet("GetAllPostByCategory")]
        public async Task<ActionResult> GetAllPostByCategory([FromQuery] GetAllPostByCategoryRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
        }
        
        [HttpGet("GetPostById")]
        public async Task<ActionResult> GetPostById([FromQuery] GetPostByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
        }
        [HttpGet("GetPostByTitle")]
        public async Task<ActionResult> GetPostByTitle([FromQuery] GetPostByTitleRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
        }
    #endregion
}
