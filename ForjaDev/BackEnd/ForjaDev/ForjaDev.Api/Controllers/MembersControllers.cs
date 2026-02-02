using ForjaDev.Application.Following.UseCases.Command.Request;
using ForjaDev.Application.Following.UseCases.Query.Request;
using ForjaDev.Application.Member.UseCases.Command.Request;
using ForjaDev.Application.Member.UseCases.Query.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ForjaDev.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MembersControllers : ControllerBase
{
    private readonly IMediator _mediator;

    public MembersControllers(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Post

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody]RegisterMemberRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
        }
        
        [HttpPost("Login")]
        public async Task<ActionResult> Register([FromBody]LoginMemberRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
        }

        [HttpPost("Follow")]
        public async Task<ActionResult> Follow([FromBody]CreateFollowingRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok() : BadRequest(response.Error);
        }
    #endregion


    #region Get

        [HttpGet("DashBoardPublic")]
        public async Task<ActionResult> DashBoardPublic([FromQuery] GetDashBoardPublicRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
        }
        
        [HttpGet("DashBoardPrivate")]
        public async Task<ActionResult> DashBoardPrivate([FromQuery] GetDashBoardPrivateRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
        }
    #endregion
   
}