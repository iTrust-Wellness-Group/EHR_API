using EHR.API.Controllers.Base;
using EHR.Application.Feature.CRM.Office.QueryOffice;
using EHR.Application.Feature.Drchrono.createOnpatientAccess;
using EHR.Application.Feature.Drchrono.CreatePatient;
using EHR.Application.Feature.Drchrono.creatPatientsSummary;
using EHR.Application.Feature.Drchrono.deleteOnpatientAccess;
using EHR.Application.Feature.Drchrono.deletePatient;
using EHR.Application.Feature.Drchrono.getOnpatientAccess;
using EHR.Application.Feature.Drchrono.GetPatiens;
using EHR.Application.Feature.Drchrono.getPatientsSummary;
using EHR.Application.Feature.Drchrono.updatePatient;
using EHR.Application.Feature.Drchrono.updatePatientsSummary;
using EHR.Application.Feature.Drchrono.updatePatientsSummaryPart;
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
        [AllowAnonymous]
        public async Task<IActionResult> GetPatients()
        {
            var res = await _mediator.Send(new PatientsHandlerReq());
            return Ok(res);
        }
        [HttpPost("patients")]
        [AllowAnonymous]
        public async Task<IActionResult> CreatePatient(CreatePatientReq req)
        {
            var res = await _mediator.Send(req);
            return Ok(res);
        }
        [HttpPut("patients")]
        public async Task<IActionResult> UpdatePatient(UpdatePatientReq req)
        {
            var res = await _mediator.Send(req);
            return Ok(res);
        }
        [HttpDelete("patients")]
        public async Task<IActionResult> DeletePatient(DeletePatientReq req)
        {
            var res = await _mediator.Send(req);
            return Ok(res);
        }
        [HttpGet("patients/:id/ccda")]
        public async Task<IActionResult> GetPatientsCCDA()
        {
            var res = await _mediator.Send(new PatientsHandlerReq());
            return Ok(res);
        }
        [HttpGet("patients/:id/onpatient_access")]
        public async Task<IActionResult> GetOnpatientAccess()
        {
            var res = await _mediator.Send(new GetOnpatientAccessReq());
            return Ok(res);
        }
        [HttpPost("patients/:id/onpatient_access")]
        public async Task<IActionResult> CreateOnpatientAccess(CreateOnpatientAccessReq req)
        {
            var res = await _mediator.Send(req);
            return Ok(res);
        }
        [HttpDelete("patients/:id/onpatient_access")]
        public async Task<IActionResult> DeleteOnpatientAccess(DeleteOnpatientAccessReq req)
        {
            var res = await _mediator.Send(req);
            return Ok(res);
        }
        [HttpGet("patients/patients_summary")]
        public async Task<IActionResult> GetPatientsSummary()
        {
            var res = await _mediator.Send(new GetPatientsSummaryReq());
            return Ok(res);
        }
        [HttpPost("patients/patients_summary")]
        public async Task<IActionResult> CreatPatientsSummary()
        {
            var res = await _mediator.Send(new CreatPatientsSummaryReq());
            return Ok(res);
        }
        [HttpPut("patients/patients_summary")]
        public async Task<IActionResult> UpdatePatientsSummary(UpdatePatientsSummaryReq req)
        {
            var res = await _mediator.Send(req);
            return Ok(res);
        }
        [HttpPatch("patients/patients_summary")]
        public async Task<IActionResult> UpdatePatientsSummaryPart(UpdatePatientsSummaryPartReq req)
        {
            var res = await _mediator.Send(req);
            return Ok(res);
        }
        [HttpDelete("patients/patients_summary")]
        public async Task<IActionResult> DeletePatientsSummary(DeleteOnpatientAccessReq req)
        {
            var res = await _mediator.Send(req);
            return Ok(res);
        }
    }
}
