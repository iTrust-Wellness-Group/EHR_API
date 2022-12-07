using AutoMapper;
using EHR.Application.Contract.CRM.Office;
using EHR.Application.Feature.Drchrono.updatePatient;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using EHR.Context.Drchrono;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Drchrono.updatePatientsSummary
{
    public class UpdatePatientsSummaryHandler : BaseHandler, IRequestHandler<UpdatePatientsSummaryReq, ResponseData<UpdatePatientsSummaryRes>>
    {
        IServiceContext _serviceContext;
        DrchronoContext _context;
        public UpdatePatientsSummaryHandler(IServiceContext serviceContext, DrchronoContext context)
        {
            _serviceContext = serviceContext;
            _context = context;
        }

        public async Task<ResponseData<UpdatePatientsSummaryRes>> Handle(UpdatePatientsSummaryReq request, CancellationToken cancellationToken)
        {
            UpdatePatientsSummaryRes response = await this._context.Patient.UpdatePatientsSummary<UpdatePatientsSummaryRes>(request);
            return await Task.FromResult(new ResponseData<UpdatePatientsSummaryRes>(response));
        }
    }
}
