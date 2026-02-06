using ForjaDev.Application.Following.UseCases.Command.Request;
using ForjaDev.Application.Member.UseCases.Command.Request;
using ForjaDev.Application.Member.UseCases.Query.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ForjaDev.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MembersController : ControllerBase
{
    private readonly IMediator _mediator;

    public MembersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Post
        [HttpPost("RestartPassword")]
        public async Task<ActionResult> RestartPasswordByCode([FromBody]RestartPasswordByCodeRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok() : BadRequest(response.Error);
        }
    
        [HttpPost("SendEmailCode")]
        public async Task<ActionResult> SendEmailCode([FromBody]SendEmailNotificationRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok() : BadRequest(response.Error);
        }
    
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
        
        [HttpPost("AddLink")]
        public async Task<ActionResult> AddLink([FromBody]AddLinkInMemberRequest request)
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

    #region Delete

        [HttpDelete("UnFollow")]
        public async Task<ActionResult> UnFollow([FromQuery]RemoveFollowingRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok() : BadRequest(response.Error);
        }
        [HttpDelete("RemoveLink")]
        public async Task<ActionResult> RemoveLink([FromQuery]RemoveLinkInMemberRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok() : BadRequest(response.Error);
        }
    #endregion
}