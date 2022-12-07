using AutoMapper;
using EHR.Application.Contract.CRM.Office;
using EHR.Application.Feature.Drchrono.GetPatiens;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using EHR.Context.Drchrono;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Drchrono.getPatientsSummary
{
    public class GetPatientsSummaryHandler : BaseHandler, IRequestHandler<GetPatientsSummaryReq, ResponseData<GetPatientsSummaryRes>>
    {
        IServiceContext _serviceContext;
        DrchronoContext _drchronotext;
        public GetPatientsSummaryHandler(IServiceContext serviceContext, DrchronoContext drchronotext)
        {
            _serviceContext = serviceContext;
            _drchronotext = drchronotext;
        }

        public async Task<ResponseData<GetPatientsSummaryRes>> Handle(GetPatientsSummaryReq request, CancellationToken cancellationToken)
        {
            var patients = await _drchronotext.Patient.getPatients<GetPatientsSummaryRes>();
            return await Task.FromResult(new ResponseData<GetPatientsSummaryRes>(patients));
        }
    }
}
