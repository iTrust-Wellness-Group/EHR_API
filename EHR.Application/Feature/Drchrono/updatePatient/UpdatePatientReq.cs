using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Drchrono.updatePatient
{
    public class UpdatePatientReq : IRequest<ResponseData<UpdatePatientRes>>
    {
        public string gender { get; set; }
        public int doctor { get; set; }
    }
}
