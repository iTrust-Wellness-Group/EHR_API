using EHR.Application.Contract.ReferralSystem.Office;
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
    public class OfficeHandler : BaseHandler, IRequestHandler<OfficeReq, ResponseData<List<OfficeRes>>>
    {
        IServiceContext _serviceContext;
        public OfficeHandler(IServiceContext serviceContext)
        {
            this._serviceContext = serviceContext;
        }

        public async Task<ResponseData<List<OfficeRes>>> Handle(OfficeReq request, CancellationToken cancellationToken)
        {

            var list = await this._serviceContext.office.GetAllAsync();
            List<OfficeRes> response = list.Select(x => new OfficeRes
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            var data = new ResponseData<List<OfficeRes>>(response);
            return await Task.FromResult(data);
        }
    }
}
