
using EHR.API.Controllers.Base;
using EHR.Application.Feature.DetailedForm.GetFormData;
using EHR.Application.Feature.DetailedForm.SaveFormAttachments;
using EHR.Application.Feature.DetailedForm.SaveFormData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EHR.API.Controllers.DetailedForm
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class DetailedFormController : BaseController
    {
        private readonly IMediator _mediator;
        public DetailedFormController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("form")]
        public async Task<IActionResult> GetFormData(GetFormDataReq req)
        {
            var res = await _mediator.Send(req);
            return Ok(res);
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveFormData(SaveFormDataReq req)
        {
            var res = await _mediator.Send(req);
            return Ok(res);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshCsrfToken(SaveFormDataReq req)
        {
            var res = await _mediator.Send(req);
            return Ok(res);
        }

        [HttpPost("save/attachment")]
        public async Task<IActionResult> SaveAttachments([FromForm] SaveFormAttachmentsReq req)
        {
            var res = await _mediator.Send(req);
            return Ok(res);
        }

    }
}
