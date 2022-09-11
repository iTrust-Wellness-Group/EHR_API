using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Identity.Models
{
    public class LoginModel : IRequest<ResponseData<LoginResponseModel>>
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }

    public class RefreshModel : IRequest<ResponseData<LoginResponseModel>>
    {
        public Guid UserID { get; set; }
        public Guid RefreshToken { get; set; }

    }
}
