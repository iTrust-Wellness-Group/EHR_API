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

namespace EHR.Application.Feature.Drchrono.deletePatient
{
    public class DeletePatientHandler : BaseHandler, IRequestHandler<DeletePatientReq, ResponseData<DeletePatientRes>>
    {
        IServiceContext _serviceContext;
        DrchronoContext _context;
        public DeletePatientHandler(IServiceContext serviceContext,DrchronoContext context)
        {
            _serviceContext = serviceContext;
            _context = context;
        }

        public async Task<ResponseData<DeletePatientRes>> Handle(DeletePatientReq request, CancellationToken cancellationToken)
        {
            DeletePatientRes response = await this._context.Patient.deletePatient<DeletePatientRes>(request);
            return await Task.FromResult(new ResponseData<DeletePatientRes>(response));
        }
    }
}
