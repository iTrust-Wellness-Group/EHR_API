using AutoMapper;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EHR.Context.CRM;
using System.Threading.Tasks;


namespace EHR.Application.Feature.CRM.Lead.GetLeads
{
    public class GetLeadsHandler : BaseHandler, IRequestHandler<GetLeadsReq, ResponseData<GetLeadsRes>>
    {
        IServiceContext _serviceContext;
        LeadsquaredContext _crmContext;

        public GetLeadsHandler(IServiceContext serviceContext, LeadsquaredContext crmContext)
        {
            _serviceContext = serviceContext;
            _crmContext = crmContext;
        }

        public async Task<ResponseData<GetLeadsRes>> Handle(GetLeadsReq request, CancellationToken cancellationToken)
        {
            var patients = await _crmContext.Leads.getLeadMetdadata<GetLeadsRes>();
            return await Task.FromResult(new ResponseData<GetLeadsRes>(patients));
        }
    }
}
