using AutoMapper;
using EHR.Application.Contract.CRM.Office;
using EHR.Application.Feature.DetailedForm.SaveFormData;
using EHR.Application.Feature.Leadsquared.PostContactFormScript;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using EHR.Context.CRM;
using EHR.Database.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;


namespace EHR.Application.Feature.DetailedForm.SaveFormAttachments
{
    public class SaveFormAttachmentsHandler : DetailedFormBaseHandler, IRequestHandler<SaveFormAttachmentsReq, ResponseData<SaveFormAttachmentsRes>>
    {
        IServiceContext _serviceContext;
        LeadsquaredContext _leadsquaredContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SaveFormAttachmentsHandler(
            IServiceContext serviceContext, 
            LeadsquaredContext leadsquaredContext, 
            DatabaseContext databaseContext,
            IHttpContextAccessor httpContextAccessor) : base(databaseContext)
        {
            _serviceContext = serviceContext;
            _leadsquaredContext = leadsquaredContext;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task<ResponseData<SaveFormAttachmentsRes>> Handle(SaveFormAttachmentsReq request, CancellationToken cancellationToken)
        {
            string leadId = LookupCsrfToken(request.csrfToken);

            SaveFormAttachmentsRes resp = await _leadsquaredContext?.File.uploadImage<SaveFormAttachmentsRes>(leadId, request.File);
            

            return await Task.FromResult(new ResponseData<SaveFormAttachmentsRes>(resp));

        }
        
    }
}
