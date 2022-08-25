using EHR.Application.Contract.ReferralSystem.Office;
using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.ReferralSystem.Office.Command
{
    internal class OfficeCommandHandler : BaseHandler, IRequestHandler<CreateOfficeReq, Response>
    {
        IOfficeCommandRepository service;
        public OfficeCommandHandler(IOfficeCommandRepository service)
        {
            this.service = service;
        }

        public async Task<Response> Handle(CreateOfficeReq request, CancellationToken cancellationToken)
        {
            bool isSuccess = await this.service.createOffice(request.Name);
            if (isSuccess)
                return await Task.FromResult(new Response(200, true));
            else
                return await Task.FromResult(new Response(500, false));
        }
    }
}
