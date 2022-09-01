﻿using EHR.API.Controllers.Base;
using EHR.Application.Feature.Identity.Models;
using MediatR;
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
        public async Task<IActionResult> Login(LoginModel req)
        {
            var result = await this._mediator.Send(req);
            return Ok(result);
        }
    }
}