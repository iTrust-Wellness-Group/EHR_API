using AutoMapper;
using EHR.Application.Contract.CRM.Office;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using EHR.Context.Drchrono;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Drchrono.getOnpatientAccess
{
    public class GetOnpatientAccessHandler : BaseHandler, IRequestHandler<GetOnpatientAccessReq, ResponseData<GetOnpatientAccessRes>>
    {
        IServiceContext _serviceContext;
        DrchronoContext _drchronotext;
        public GetOnpatientAccessHandler(IServiceContext serviceContext, DrchronoContext drchronotext)
        {
            _serviceContext = serviceContext;
            _drchronotext = drchronotext;
        }

        public async Task<ResponseData<GetOnpatientAccessRes>> Handle(GetOnpatientAccessReq request, CancellationToken cancellationToken)
        {
            var onpatientAccess = await _drchronotext.Patient.getOnpatientAccess<GetOnpatientAccessRes>();
            return await Task.FromResult(new ResponseData<GetOnpatientAccessRes>(onpatientAccess));
        }
    }
}
