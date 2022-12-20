using EHR.API.Controllers.Base;
using EHR.Application.Feature.Identity.LeadSquaredLogin;
using EHR.Application.Feature.Identity.Login;
using EHR.Application.Feature.Identity.Refresh;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHR.API.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : BaseController
    {
        private readonly IMediator _mediator;
        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(IdentityReq req)
        {
            var result = await this._mediator.Send(req);
            return Ok(result);
        }

        [HttpPost("LeadSquaredLogin")]
        [AllowAnonymous]
        public async Task<IActionResult> LeadSquaredLogin(LeadSquaredLoginReq req)
        {
            var result = await this._mediator.Send(req);
            return Ok(result);
        }

        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> refresh(RefreshReq req)
        {
            var result = await this._mediator.Send(req);
            return Ok(result);
        }
    }
}
