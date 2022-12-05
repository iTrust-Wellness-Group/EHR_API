using EHR.API.Controllers.Base;
using EHR.Application.Feature.Drchrono.getPatients;
using EHR.Application.Feature.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHR.API.Controllers.DrChrono
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : BaseController
    {
        private readonly IMediator _mediator;
        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("patients")]
        public async Task<IActionResult> patients()
        {
            var result = await this._mediator.Send(new PatientsHandlerReq());
            return Ok(result);
        }

        [HttpGet("patients/:id/ccda")]
        public async Task<IActionResult> patientCCDA(String req)
        {
            var result = await this._mediator.Send(req);
            return Ok(result);
        }

        [HttpGet("patients/:id/onpatient_access")]
        public async Task<IActionResult> onpatientAccess(String req)
        {
            var result = await this._mediator.Send(req);
            return Ok(result);
        }

        [HttpGet("patients/patients_summary")]
        public async Task<IActionResult> patientsSummary(String req)
        {
            var result = await this._mediator.Send(req);
            return Ok(result);
        }


    }
}
