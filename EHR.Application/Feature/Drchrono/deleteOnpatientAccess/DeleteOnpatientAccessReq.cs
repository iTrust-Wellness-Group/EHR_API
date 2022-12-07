using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Drchrono.deleteOnpatientAccess
{
    public class DeleteOnpatientAccessReq : IRequest<ResponseData<DeleteOnpatientAccessRes>>
    {

    }
}
