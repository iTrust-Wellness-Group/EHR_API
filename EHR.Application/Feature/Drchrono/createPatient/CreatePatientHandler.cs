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

namespace EHR.Application.Feature.Drchrono.createPatient
{
    public class CreatePatientHandler : BaseHandler, IRequestHandler<CreatePatientReq, ResponseData<CreatePatientRes>>
    {
        IServiceContext _serviceContext;
        DrchronoContext _context;
        public CreatePatientHandler(IServiceContext serviceContext,DrchronoContext context)
        {
            _serviceContext = serviceContext;
            _context = context;
        }

        public async Task<ResponseData<CreatePatientRes>> Handle(CreatePatientReq request, CancellationToken cancellationToken)
        {
            CreatePatientRes response = await this._context.Patient.createPatient<CreatePatientRes>(request);
            return await Task.FromResult(new ResponseData<CreatePatientRes>(response));

        }
    }
}
