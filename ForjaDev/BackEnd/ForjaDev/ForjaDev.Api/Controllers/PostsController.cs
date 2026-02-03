using ForjaDev.Application.Post.UseCases.Command.Request;
using ForjaDev.Application.Post.UseCases.Query.Request;
using MediatR;
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
    
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreatePostRequest request) 
    {
        var response = await _mediator.Send(request);
        return response.IsSuccess ? Created() : BadRequest(response.Error);
    }
    
    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] RemovePostRequest request) 
    {
        var response = await _mediator.Send(request);
        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }
    
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

    #endregion
}
