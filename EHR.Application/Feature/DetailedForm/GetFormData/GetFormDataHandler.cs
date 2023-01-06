using AutoMapper;
using EHR.Application.Contract.CRM.Office;
using EHR.Application.Feature.Identity.Login;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using EHR.Context.CRM;
using EHR.Database.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.DetailedForm.GetFormData
{
    public class GetFormDataHandler : DetailedFormBaseHandler, IRequestHandler<GetFormDataReq, ResponseData<GetFormDataRes>>
    {
        IServiceContext _serviceContext;
        LeadsquaredContext _leadsquaredContext;
       
        public GetFormDataHandler(IServiceContext serviceContext, LeadsquaredContext leadsquaredContext, DatabaseContext databaseContext) : base(databaseContext)
        {
            _serviceContext = serviceContext;
            _leadsquaredContext = leadsquaredContext;
            
        }

        public async Task<ResponseData<GetFormDataRes>> Handle(GetFormDataReq request, CancellationToken cancellationToken)
        {
            String leadId = LookupCsrfToken(request.csrfToken);
            List<FormDataModel> leadData = await _leadsquaredContext.Leads.getLeadById<List<FormDataModel>>(leadId);

            GetFormDataRes data = new GetFormDataRes()
            {
                formData = leadData[0],
            };
        
            return await Task.FromResult(new ResponseData<GetFormDataRes>(data));
        }
    }
}
