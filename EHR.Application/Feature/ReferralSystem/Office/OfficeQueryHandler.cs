using AutoMapper;
using EHR.Application.Contract.ReferralSystem.Office;
using EHR.Application.Feature.ReferralSystem.Office.Models;
using EHR.Application.Feature.UnitOfWork;
using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.ReferralSystem.Office.Query
{
    public class OfficeQueryHandler : BaseHandler, IRequestHandler<OfficeSearchModel, ResponseData<List<OfficeModel>>>
    {
        IServiceContext _serviceContext;
        public OfficeQueryHandler(IServiceContext serviceContext)
        {
            this._serviceContext = serviceContext;
        }

        public async Task<ResponseData<List<OfficeModel>>> Handle(OfficeSearchModel request, CancellationToken cancellationToken)
        {

            var list = this._serviceContext.office.getOfficeList();

            //List<OfficeModel> response = list.Select(x => new OfficeModel
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //}).ToList();
            var officeDTO = this._serviceContext.mapper.Map<List<OfficeModel>>(list);
            var data = new ResponseData<List<OfficeModel>>(officeDTO);
            return await Task.FromResult(data);
        }
    }
}
