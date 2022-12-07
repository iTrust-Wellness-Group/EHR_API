using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Drchrono.getOnpatientAccess
{
    public class GetOnpatientAccessReq : IRequest<ResponseData<GetOnpatientAccessRes>>
    {

    }
}
