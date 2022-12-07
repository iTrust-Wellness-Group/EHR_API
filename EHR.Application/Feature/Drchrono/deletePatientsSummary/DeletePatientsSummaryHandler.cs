using AutoMapper;
using EHR.Application.Contract.CRM.Office;
using EHR.Application.Feature.Drchrono.deletePatient;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using EHR.Context.Drchrono;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Drchrono.deletePatientsSummary
{
    public class DeletePatientsSummaryHandler : BaseHandler, IRequestHandler<DeletePatientsSummaryReq, ResponseData<DeletePatientsSummaryRes>>
    {
        IServiceContext _serviceContext;
        DrchronoContext _context;
        public DeletePatientsSummaryHandler(IServiceContext serviceContext, DrchronoContext context)
        {
            _serviceContext = serviceContext;
            _context = context;
        }

        public async Task<ResponseData<DeletePatientsSummaryRes>> Handle(DeletePatientsSummaryReq request, CancellationToken cancellationToken)
        {
            DeletePatientsSummaryRes response = await this._context.Patient.DeletePatientsSummary<DeletePatientsSummaryRes>(request);
            return await Task.FromResult(new ResponseData<DeletePatientsSummaryRes>(response));
        }
    }
}
