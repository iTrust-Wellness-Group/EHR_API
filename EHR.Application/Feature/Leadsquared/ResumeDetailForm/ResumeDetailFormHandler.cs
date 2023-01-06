using AutoMapper;
using EHR.Application.Contract.CRM.Office;
using EHR.Application.Feature.Leadsquared.PostDetailedFormScript;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Leadsquared.ResumeDetailForm
{
    public class ResumeDetailFormHandler : BaseHandler, IRequestHandler<ResumeDetailFormReq, ResponseData<ResumeDetailFormRes>>
    {
        IServiceContext _serviceContext;
        public ResumeDetailFormHandler(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public async Task<ResponseData<ResumeDetailFormRes>> Handle(ResumeDetailFormReq request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new ResponseData<ResumeDetailFormRes>(new ResumeDetailFormRes()));

        }
    }
}
