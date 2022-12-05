using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Drchrono.createPatient
{
    public class CreatePatientReq : IRequest<ResponseData<CreatePatientRes>>
    {
        public string gender { get; set; }
        public int doctor { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

    }
}
