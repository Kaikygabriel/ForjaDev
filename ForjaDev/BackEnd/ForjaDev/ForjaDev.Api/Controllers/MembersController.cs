using System.Security.Claims;
using ForjaDev.Application.Following.UseCases.Command.Request;
using ForjaDev.Application.Member.UseCases.Command.Request;
using ForjaDev.Application.Member.UseCases.Query.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost("Follow")]
        public async Task<ActionResult> Follow([FromBody]CreateFollowingRequest request)
        {
            var claims = User;
            if (VerifyAuthorization(request.MemberToFollow, claims))
                return Forbid();

            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok() : BadRequest(response.Error);
        }
        
        [Authorize]
        [HttpPost("AddLink")]
        public async Task<ActionResult> AddLink([FromBody]AddLinkInMemberRequest request)
        {
            var claims = User;
            if (VerifyAuthorization(request.MemberId, claims))
                return Forbid();

            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok() : BadRequest(response.Error);
        }
    #endregion

    #region Get
        [Authorize]
        [HttpGet("DashBoardPublic")]
        public async Task<ActionResult> DashBoardPublic([FromQuery] GetDashBoardPublicRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
        }
        [Authorize]
        [HttpGet("DashBoardPrivate")]
        public async Task<ActionResult> DashBoardPrivate([FromQuery] GetDashBoardPrivateRequest request)
        {
            var claims = User;
            if (VerifyAuthorization(request.MemberId, claims))
                return Forbid();
            
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
        }
        
        [Authorize]
        [HttpGet("GetPostsByFollows")]
        public async Task<ActionResult> GetPostsByFollows([FromQuery] GetPostByFollowsRequest request)
        {
            var claims = User;
            if (VerifyAuthorization(request.MemberId, claims))
                return Forbid();
            
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
        }
    #endregion

    #region Delete
        [Authorize]
        [HttpDelete("UnFollow")]
        public async Task<ActionResult> UnFollow([FromQuery]RemoveFollowingRequest request)
        {
            var claims = User;
            if (VerifyAuthorization(request.MemberToFollowId, claims))
                return Forbid();
            
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok() : BadRequest(response.Error);
        }
        
        [Authorize]
        [HttpDelete("RemoveLink")]
        public async Task<ActionResult> RemoveLink([FromQuery]RemoveLinkInMemberRequest request)
        {
            var claims = User;
            if (VerifyAuthorization(request.MemberId, claims))
                return Forbid();
            
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok() : BadRequest(response.Error);
        }
    #endregion

    private bool VerifyAuthorization(Guid memberId, ClaimsPrincipal claims)
        => !memberId.ToString().Equals(claims.Identity!.Name);
}