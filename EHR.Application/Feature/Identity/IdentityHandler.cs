using EHR.Application.Feature.Identity.Models;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using EHR.Identity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Identity
{
    public class IdentityHandler : BaseHandler, IRequestHandler<LoginModel, ResponseData<LoginResponseModel>>
    {
        IServiceContext service;
        public IdentityHandler(IServiceContext service)
        {
            this.service = service;
        }
        public async Task<ResponseData<LoginResponseModel>> Handle(LoginModel request, CancellationToken cancellationToken)
        {
            var claims = new Claim[]
            {
                new Claim("UserId", "65be07fd-5bbd-4838-ba36-625caf3380c6"),
                new Claim("Name","Leo"),
                new Claim("Email", "LeoChou@gmail.com"),
                new Claim("MobilePhone","09123456789"),
                new Claim("Role", "Admin"),
                new Claim("RoleId",JWTUserRolesEnum.Admin.ToString()),

            };

            var token = this.service.jwtService.GenerateTokens(JWTUserTypeEnum.Backend, claims, DateTime.Now);
            var response = new LoginResponseModel()
            {
                Token = token,
                RefreshToken = "9472e6a1-b91e-408c-bca9-8a149c3738e4"
            };
            var data = new ResponseData<LoginResponseModel>(response);
            return await Task.FromResult(data);

        }
    }
}
