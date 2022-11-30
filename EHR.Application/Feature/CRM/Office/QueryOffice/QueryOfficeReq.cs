using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.CRM.Office.QueryOffice
{
    public class QueryOfficeReq : IRequest<ResponseData<List<QueryOfficeRes>>>
    {
        public String Name { get; set; }

    }
}
