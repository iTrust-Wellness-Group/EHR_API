using AutoMapper;
using EHR.Application.Contract.CRM.Office;
using EHR.Application.Feature.Drchrono.updatePatientsSummary;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using EHR.Context.Drchrono;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Drchrono.updatePatientsSummaryPart
{
    public class UpdatePatientsSummaryPartHandler : BaseHandler, IRequestHandler<UpdatePatientsSummaryPartReq, ResponseData<UpdatePatientsSummaryPartRes>>
    {
        IServiceContext _serviceContext;
        DrchronoContext _context;
        public UpdatePatientsSummaryPartHandler(IServiceContext serviceContext, DrchronoContext context)
        {
            _serviceContext = serviceContext;
            _context = context;
        }

        public async Task<ResponseData<UpdatePatientsSummaryPartRes>> Handle(UpdatePatientsSummaryPartReq request, CancellationToken cancellationToken)
        {
            UpdatePatientsSummaryPartRes response = await this._context.Patient.UpdatePatientsSummaryPart<UpdatePatientsSummaryPartRes>(request);
            return await Task.FromResult(new ResponseData<UpdatePatientsSummaryPartRes>(response));
        }
    }
}
