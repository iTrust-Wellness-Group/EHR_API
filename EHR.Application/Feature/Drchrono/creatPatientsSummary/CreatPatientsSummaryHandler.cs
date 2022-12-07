using AutoMapper;
using EHR.Application.Contract.CRM.Office;
using EHR.Application.Feature.Drchrono.CreatePatient;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using EHR.Context.Drchrono;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Drchrono.creatPatientsSummary
{
    public class CreatPatientsSummaryHandler : BaseHandler, IRequestHandler<CreatPatientsSummaryReq, ResponseData<CreatPatientsSummaryRes>>
    {
        IServiceContext _serviceContext;
        DrchronoContext _context;
        public CreatPatientsSummaryHandler(IServiceContext serviceContext, DrchronoContext context)
        {
            _serviceContext = serviceContext;
            _context = context;
        }

        public async Task<ResponseData<CreatPatientsSummaryRes>> Handle(CreatPatientsSummaryReq request, CancellationToken cancellationToken)
        {
            CreatPatientsSummaryRes response = await this._context.Patient.CreatPatientsSummary<CreatPatientsSummaryRes>(request);
            return await Task.FromResult(new ResponseData<CreatPatientsSummaryRes>(response));
        }
    }
}
