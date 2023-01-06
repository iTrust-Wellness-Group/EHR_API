using EHR.API.Controllers.Base;
using EHR.Application.Feature.Leadsquared.PostContactFormScript;
using EHR.Application.Feature.Leadsquared.PostDetailedFormScript;
using EHR.Application.Feature.Leadsquared.ResumeDetailForm;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace EHR.API.Controllers.Drchrono
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsquaredController : BaseController
    {
        private readonly IMediator _mediator;
        public LeadsquaredController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("contact_form")]
        public async Task<IActionResult> PostContactForm()
        {
            var res = await _mediator.Send(new PostContactFormScriptReq());
            return Ok(res);
        }

        [HttpPost("detailed_form")]
        public async Task<IActionResult> PostDetailForm()
        {
            var res = await _mediator.Send(new PostDetailedFormScriptReq());
            return Ok(res);
        }

        [HttpPost("resume_form")]
        public async Task<IActionResult> ResumeDetailForm()
        {
            var res = await _mediator.Send(new ResumeDetailFormReq());
            return Ok(res);
        }

    }
}
