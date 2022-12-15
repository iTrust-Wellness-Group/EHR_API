using AutoMapper;
using EHR.Application.Contract.CRM.Office;
using EHR.Application.Feature.Identity.Login;
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

namespace EHR.Application.Feature.Identity.LeadSquaredLogin
{
    public class LeadSquaredLoginHandler : BaseHandler, IRequestHandler<LeadSquaredLoginReq, ResponseData<LeadSquaredLoginRes>>
    {
        IServiceContext _serviceContext;
        public LeadSquaredLoginHandler(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public async Task<ResponseData<LeadSquaredLoginRes>> Handle(LeadSquaredLoginReq request, CancellationToken cancellationToken)
        {
            var claims = new Claim[]
            {
                new Claim("UserId", "b7924f85-e274-472f-a21f-fe74a74a76bc"),
                new Claim("Name","LeadSquared"),
                new Claim("Email", "crm@leadsquared.com"),
                new Claim("Role", "Service"),
                new Claim("RoleId",JWTUserRolesEnum.Service.ToString()),

            };
            var token = this._serviceContext.jwtService.GenerateTokens(JWTUserTypeEnum.Backend, claims, DateTime.Now);

            var response = new LeadSquaredLoginRes()
            {
                Token = token,
            };
            var data = new ResponseData<LeadSquaredLoginRes>(response);
            return await Task.FromResult(data);
        }
    }
}
