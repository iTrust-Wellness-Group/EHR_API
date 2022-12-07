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

namespace EHR.Application.Feature.Drchrono.getPatientsCCDA
{
    public class GetPatientsCCDAHandler : BaseHandler, IRequestHandler<GetPatientsCCDAReq, ResponseData<GetPatientsCCDARes>>
    {
        IServiceContext _serviceContext;
        DrchronoContext _context;
        public GetPatientsCCDAHandler(IServiceContext serviceContext, DrchronoContext context)
        {
            _serviceContext = serviceContext;
            _context = context;
        }

        public async Task<ResponseData<GetPatientsCCDARes>> Handle(GetPatientsCCDAReq request, CancellationToken cancellationToken)
        {
            var patients = await _context.Patient.getPatientsCCDA<GetPatientsCCDARes>();
            return await Task.FromResult(new ResponseData<GetPatientsCCDARes>(patients));
        }
    }
}
