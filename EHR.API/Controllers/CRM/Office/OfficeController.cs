using EHR.API.Controllers.Base;
using EHR.Application.Feature.CRM.Office.CreateOffice;
using EHR.Application.Feature.CRM.Office.QueryOffice;
using EHR.Application.Feature.CRM.Office.UpdateOffice;
using EHR.Identity.Models;
using EHR.Identity.Utility.Attributes;
using EHR.Shared.Utils.Http;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace EHR.API.Controllers.CRM.Office
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
        public async Task<IActionResult> GetOffice(string Name)
        {
            var res = await _mediator.Send(new QueryOfficeReq() { Name = Name });
            return Ok(res);
        }
        [HttpPost("Office")]
        public async Task<IActionResult> CreateOffice(CreateOfficeReq request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpPost("UpdateOffice")]
        public async Task<IActionResult> CreateOffice(UpdateOfficeReq request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }
    }
}
