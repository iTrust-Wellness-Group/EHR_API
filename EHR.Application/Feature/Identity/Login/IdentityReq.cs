using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Identity.Login
{
    public class IdentityReq : IRequest<ResponseData<IdentityRes>>
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }
}
