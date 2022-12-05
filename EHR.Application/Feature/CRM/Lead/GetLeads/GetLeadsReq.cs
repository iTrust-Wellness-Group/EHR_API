using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.CRM.Lead.GetLeads
{
    public class GetLeadsReq : IRequest<ResponseData<GetLeadsRes>>
    {
        
    }
}
