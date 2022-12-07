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

namespace EHR.Application.Feature.Drchrono.updatePatient
{
    public class UpdatePatientHandler : BaseHandler, IRequestHandler<UpdatePatientReq, ResponseData<UpdatePatientRes>>
    {
        IServiceContext _serviceContext;
        DrchronoContext _context;
        public UpdatePatientHandler(IServiceContext serviceContext, DrchronoContext context)
        {
            _serviceContext = serviceContext;
            _context = context;
        }

        public async Task<ResponseData<UpdatePatientRes>> Handle(UpdatePatientReq request, CancellationToken cancellationToken)
        {
            UpdatePatientRes response = await this._context.Patient.updatePatient<UpdatePatientRes>(request);
            return await Task.FromResult(new ResponseData<UpdatePatientRes>(response));
        }
    }
}
