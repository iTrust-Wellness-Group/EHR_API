using AutoMapper;
using EHR.Application.Contract.CRM.Office;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.CRM.Office.QueryOffice
{
    public class QueryOfficeHandler : BaseHandler, IRequestHandler<QueryOfficeReq, ResponseData<List<QueryOfficeRes>>>
    {
        IServiceContext _serviceContext;
        public QueryOfficeHandler(IServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public async Task<ResponseData<List<QueryOfficeRes>>> Handle(QueryOfficeReq request, CancellationToken cancellationToken)
        {

            var list = _serviceContext.office.getOfficeList();

  
            var officeDTO = _serviceContext.mapper.Map<List<QueryOfficeRes>>(list);
            var data = new ResponseData<List<QueryOfficeRes>>(officeDTO);
            return await Task.FromResult(data);
        }
    }
}
