using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.CRM.Office.UpdateOffice
{
    public class UpdateOfficeReq : IRequest<Response>
    {
        public Guid id { get; set; }
        public String Name { get; set; }
    }
}
