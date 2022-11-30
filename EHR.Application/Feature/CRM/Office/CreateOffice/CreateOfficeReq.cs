using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.CRM.Office.CreateOffice
{
    public class CreateOfficeReq : IRequest<Response>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public bool? IsDelete { get; set; }
    }
}
