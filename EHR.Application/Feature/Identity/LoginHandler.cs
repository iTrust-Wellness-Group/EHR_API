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
    public class LoginHandler : BaseHandler, IRequestHandler<LoginModel, ResponseData<LoginResponseModel>>
    {
        IServiceContext service;
        public LoginHandler(IServiceContext service)
        {
            this.service = service;
        }
        public async Task<ResponseData<LoginResponseModel>> Handle(LoginModel request, CancellationToken cancellationToken)
        {
            var claims = new Claim[]
            {
                new Claim("UserId", "123"),
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
                RefreshToken = "123"
            };
            var data = new ResponseData<LoginResponseModel>(response);
            return await Task.FromResult(data);

        }
    }
}
