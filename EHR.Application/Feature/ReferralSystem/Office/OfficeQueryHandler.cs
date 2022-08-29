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
    public class OfficeQueryHandler : BaseHandler, IRequestHandler<OfficeSearchSearchModel, ResponseData<List<OfficeModel>>>
    {
        IServiceContext _serviceContext;
        public OfficeQueryHandler(IServiceContext serviceContext)
        {
            this._serviceContext = serviceContext;
        }

        public async Task<ResponseData<List<OfficeModel>>> Handle(OfficeSearchSearchModel request, CancellationToken cancellationToken)
        {

            var list = await this._serviceContext.office.GetAllAsync();
            List<OfficeModel> response = list.Select(x => new OfficeModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            var data = new ResponseData<List<OfficeModel>>(response);
            return await Task.FromResult(data);
        }
    }
}
