using EHR.API.Controllers.Base;
using EHR.Application.Feature.CRM.Office.QueryOffice;
using EHR.Application.Feature.Drchrono.CreatePatient;
using EHR.Application.Feature.Drchrono.GetPatiens;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace EHR.API.Controllers.Drchrono
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrchronoController : BaseController
    {
        private readonly IMediator _mediator;
        public DrchronoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("patients")]
        public async Task<IActionResult> GetPatients()
        {
            var res = await _mediator.Send(new PatientsHandlerReq());
            return Ok(res);
        }

        [HttpPost("patients")]
        public async Task<IActionResult> CreatePatient(CreatePatientReq req)
        {
            var res = await _mediator.Send(req);
            return Ok(res);
        }
    }
}
