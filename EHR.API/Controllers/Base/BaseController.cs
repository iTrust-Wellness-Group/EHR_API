using EHR.Identity.Utility.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHR.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [AuthenticationService]
    public class BaseController : ControllerBase
    {
    }
}
