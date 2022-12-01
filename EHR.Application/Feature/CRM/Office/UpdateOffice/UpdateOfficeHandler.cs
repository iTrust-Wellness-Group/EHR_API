using AutoMapper;
using EHR.Application.Contract.CRM.Office;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.CRM.Office.UpdateOffice
{
    public class UpdateOfficeHandler : BaseHandler, IRequestHandler<UpdateOfficeReq, Response>
    {
        IServiceContext _serviceContext;
        public UpdateOfficeHandler(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public async Task<Response> Handle(UpdateOfficeReq request, CancellationToken cancellationToken)
        {
            var isSuccess = await this._serviceContext.office.updateOffice(request);
            if (isSuccess)
                return await Task.FromResult(new Response(200, isSuccess));
            else
                return await Task.FromResult(new Response(500, isSuccess));
        }
    }
}
