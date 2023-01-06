using AutoMapper;
using EHR.Application.Contract.CRM.Office;
using EHR.Application.Feature.Leadsquared.PostContactFormScript;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Leadsquared.PostDetailedFormScript
{
    public class PostDetailedFormScriptHandler : BaseHandler, IRequestHandler<PostDetailedFormScriptReq, ResponseData<PostDetailedFormScriptRes>>
    {
        IServiceContext _serviceContext;
        public PostDetailedFormScriptHandler(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public async Task<ResponseData<PostDetailedFormScriptRes>> Handle(PostDetailedFormScriptReq request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new ResponseData<PostDetailedFormScriptRes>(new PostDetailedFormScriptRes()));

        }
    }
}
