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

namespace EHR.Application.Feature.Drchrono.deleteOnpatientAccess
{
    public class DeleteOnpatientAccessHandler : BaseHandler, IRequestHandler<DeleteOnpatientAccessReq, ResponseData<DeleteOnpatientAccessRes>>
    {
        IServiceContext _serviceContext;
        DrchronoContext _context;
        public DeleteOnpatientAccessHandler(IServiceContext serviceContext, DrchronoContext context)
        {
            _serviceContext = serviceContext;
            _context = context;
        }

        public async Task<ResponseData<DeleteOnpatientAccessRes>> Handle(DeleteOnpatientAccessReq request, CancellationToken cancellationToken)
        {
            DeleteOnpatientAccessRes response = await this._context.Patient.DeleteOnpatientAccess<DeleteOnpatientAccessRes>(request);
            return await Task.FromResult(new ResponseData<DeleteOnpatientAccessRes>(response));
        }
    }
}
