using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.ReferralSystem.Office.Query
{
    public class OfficeReq:IRequest<ResponseData<List<OfficeRes>>>
    {
        public String Name { get; set; }
    }
}
