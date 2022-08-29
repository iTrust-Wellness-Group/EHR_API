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

namespace EHR.Application.Feature.ReferralSystem.Office.Command
{
    internal class OfficeCreateHandler : BaseHandler, IRequestHandler<OfficeModel, Response>
    {
        IServiceContext _serviceContext;
        public OfficeCreateHandler(IServiceContext _serviceContext)
        {
            this._serviceContext = _serviceContext;
        }

        public async Task<Response> Handle(OfficeModel request, CancellationToken cancellationToken)
        {
            // TODO: use AutoMapper to map model and enitiy
            bool isSuccess = true; //await this._serviceContext.office.cre(request.Name);
            if (isSuccess)
                return await Task.FromResult(new Response(200, true));
            else
                return await Task.FromResult(new Response(500, false));
        }
    }
}
