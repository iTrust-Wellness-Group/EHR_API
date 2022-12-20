using AutoMapper;
using EHR.Application.Contract.CRM.Office;
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

namespace EHR.Application.Feature.Identity.Login
{
    public class IdentityHandler : BaseHandler, IRequestHandler<IdentityReq, ResponseData<IdentityRes>>
    {
        IServiceContext _serviceContext;
        public IdentityHandler(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public async Task<ResponseData<IdentityRes>> Handle(IdentityReq request, CancellationToken cancellationToken)
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

            var token = this._serviceContext.jwtService.GenerateTokens(JWTUserTypeEnum.Backend, claims, DateTime.Now);
            var response = new IdentityRes()
            {
                Token = token,
                RefreshToken = "9472e6a1-b91e-408c-bca9-8a149c3738e4"
            };
            var data = new ResponseData<IdentityRes>(response);
            return await Task.FromResult(data);
        }
    }
}
