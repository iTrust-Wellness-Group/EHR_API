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
    public class RefreshTokenHandler : BaseHandler, IRequestHandler<RefreshModel, ResponseData<LoginResponseModel>>
    {
        IServiceContext service;
        public RefreshTokenHandler(IServiceContext service)
        {
            this.service = service;
        }
        public async Task<ResponseData<LoginResponseModel>> Handle(RefreshModel request, CancellationToken cancellationToken)
        {
            bool isVaild = this.service.identity.RefreshTokenAsync(request);
            if (isVaild)
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
                Guid refreshToken = Guid.NewGuid();
                var response = new LoginResponseModel()
                {
                    Token = token,
                    RefreshToken = refreshToken.ToString()
                };
                this.service.identity.RevokeToken(new RefreshModel() { 
                    UserID = Guid.Parse("65be07fd-5bbd-4838-ba36-625caf3380c6"),
                    RefreshToken = refreshToken
                });
                var data = new ResponseData<LoginResponseModel>(response);
                return await Task.FromResult(data);
            }
            else
            {
                var data = new ResponseData<LoginResponseModel>(401,"RefreshToken驗證失敗");
                return await Task.FromResult(data);
            }
        }
    }
}
