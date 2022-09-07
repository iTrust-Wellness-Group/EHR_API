using EHR.API.Controllers.Base;
using EHR.Application.Feature.ReferralSystem.Office.Command;
using EHR.Application.Feature.ReferralSystem.Office.Models;
using EHR.Application.Feature.ReferralSystem.Office.Query;
using EHR.Identity.Models;
using EHR.Identity.Utility.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("Office")]
        [Authentication(JWTUserRolesEnum.Admin, JWTUserRolesEnum.User)]
        public async Task<IActionResult> GetOffice(String Name)
        {
            var res = await _mediator.Send(new OfficeSearchModel() { Name = Name });
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
