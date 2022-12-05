using EHR.API.Controllers.Base;
using EHR.Application.Feature.CRM.Lead.GetLeads;
using EHR.Identity.Models;
using EHR.Identity.Utility.Attributes;
using EHR.Shared.Utils.Http;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace EHR.API.Controllers.CRM.Lead
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : BaseController
    {
        private readonly IMediator _mediator;
        public LeadController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("lead")]
        public async Task<IActionResult> GetLeads()
        {
            var res = await _mediator.Send(new GetLeadsReq());
            return Ok(res);
        }
    }
}