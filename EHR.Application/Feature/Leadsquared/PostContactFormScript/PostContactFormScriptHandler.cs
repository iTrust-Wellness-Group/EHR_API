using AutoMapper;
using EHR.Application.Contract.CRM.Office;
using EHR.Application.Feature.Identity.Login;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using MediatR;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Leadsquared.PostContactFormScript
{
    public class PostContactFormScriptHandler : BaseHandler, IRequestHandler<PostContactFormScriptReq, ResponseData<PostContactFormScriptRes>>
    {
        IServiceContext _serviceContext;
        public PostContactFormScriptHandler(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public async Task<ResponseData<PostContactFormScriptRes>> Handle(PostContactFormScriptReq request, CancellationToken cancellationToken)
        {

            return await Task.FromResult(new ResponseData<PostContactFormScriptRes>(new PostContactFormScriptRes()));
        }
    }
}
