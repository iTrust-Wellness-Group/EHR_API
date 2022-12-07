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

namespace EHR.Application.Feature.Drchrono.createOnpatientAccess
{
    public class CreateOnpatientAccessHandler : BaseHandler, IRequestHandler<CreateOnpatientAccessReq, ResponseData<CreateOnpatientAccessRes>>
    {
        IServiceContext _serviceContext;
        DrchronoContext _context;
        public CreateOnpatientAccessHandler(IServiceContext serviceContext, DrchronoContext context)
        {
            _serviceContext = serviceContext;
            _context = context;
        }

        public async Task<ResponseData<CreateOnpatientAccessRes>> Handle(CreateOnpatientAccessReq request, CancellationToken cancellationToken)
        {
            CreateOnpatientAccessRes response = await this._context.Patient.CreateOnpatientAccess<CreateOnpatientAccessRes>(request);
            return await Task.FromResult(new ResponseData<CreateOnpatientAccessRes>(response));
        }
    }
}
