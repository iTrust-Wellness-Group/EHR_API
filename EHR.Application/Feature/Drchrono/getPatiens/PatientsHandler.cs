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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EHR.Application.Feature.Drchrono.getPatiens
{
    public class PatientsHandler : BaseHandler, IRequestHandler<PatientsHandlerReq, ResponseData<PatientsHandlerRes>>
    {
        IServiceContext _serviceContext;
        DrchronoContext _drchronotext;
        public PatientsHandler(IServiceContext serviceContext, DrchronoContext drchronotext)
        {
            _serviceContext = serviceContext;
            _drchronotext = drchronotext;

        }

        public async Task<ResponseData<PatientsHandlerRes>> Handle(PatientsHandlerReq request, CancellationToken cancellationToken)
        {
            var patients = await _drchronotext.Patient.getPatients<PatientsHandlerRes>();
            return await Task.FromResult(new ResponseData<PatientsHandlerRes>(patients));
        }
    }
}
