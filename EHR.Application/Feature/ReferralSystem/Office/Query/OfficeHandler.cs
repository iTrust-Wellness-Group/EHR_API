using EHR.Application.Contract.ReferralSystem.Office;
using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.ReferralSystem.Office.Query
{
    public class OfficeHandler : BaseHandler,IRequestHandler<OfficeReq,ResponseData<List<OfficeRes>>>
    {
        IOfficeRepository service;
        public OfficeHandler(IOfficeRepository service)
        {
            this.service = service;
        }

        public async Task<ResponseData<List<OfficeRes>>> Handle(OfficeReq request, CancellationToken cancellationToken)
        {

            List<OfficeRes> list = this.service.getOfficeList(request.Name);
            var response = new ResponseData<List<OfficeRes>>(list);
            return await Task.FromResult(response);
        }
    }
}
