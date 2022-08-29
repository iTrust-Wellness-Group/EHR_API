using EHR.API.Controllers.Base;
using EHR.Application.Feature.ReferralSystem.Office.Command;
using EHR.Application.Feature.ReferralSystem.Office.Models;
using EHR.Application.Feature.ReferralSystem.Office.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace EHR.API.Controllers.ReferralSystem
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : BaseController
    {
        private readonly IMediator _mediator;
        public OfficeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Office/{Name}")]
        public async Task<IActionResult> GetOffice(String Name)
        {
            var res = await _mediator.Send(new OfficeSearchSearchModel() { Name = Name });
            return Ok(res);
        }
        [HttpPost("Office")]
        public async Task<IActionResult> CreateOffice(OfficeModel request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }
    }
}
