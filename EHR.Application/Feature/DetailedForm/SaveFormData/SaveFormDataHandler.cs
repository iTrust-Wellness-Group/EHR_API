using AutoMapper;
using EHR.Application.Contract.CRM.Office;
using EHR.Application.Feature.DetailedForm.GetFormData;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using EHR.Context.CRM;
using EHR.Database.Context;
using MediatR;
using MongoDB.Bson.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace EHR.Application.Feature.DetailedForm.SaveFormData
{
    public class SaveFormDataHandler : DetailedFormBaseHandler, IRequestHandler<SaveFormDataReq, ResponseData<SaveFormDataRes>>
    {
        IServiceContext _serviceContext;
        LeadsquaredContext _leadsquaredContext;


        public SaveFormDataHandler(IServiceContext serviceContext, LeadsquaredContext leadsquaredContext, DatabaseContext databaseContext) :base(databaseContext)
        {
            _serviceContext = serviceContext;
            _leadsquaredContext = leadsquaredContext;
        }

      

        public async Task<ResponseData<SaveFormDataRes>> Handle(SaveFormDataReq request, CancellationToken cancellationToken)
        {
            string leadId = LookupCsrfToken(request.csrfToken);

            Dictionary<string,object> jsonFormData = JsonSerializer.Deserialize<Dictionary<string, object>>(request.formData);
            
            string sectionKey = jsonFormData.Keys.First();
            
            List<AttributeValuePairModel> data = new List<AttributeValuePairModel>
            {
                new AttributeValuePairModel { Attribute = $"mx_Detailed_Form_{sectionKey}", Value = request.formData}
            };

        
            SaveFormDataRes response = await _leadsquaredContext.Leads.updateLead<SaveFormDataRes>(leadId, data);


      

            return await Task.FromResult(new ResponseData<SaveFormDataRes>(response));
        }
    }
}
