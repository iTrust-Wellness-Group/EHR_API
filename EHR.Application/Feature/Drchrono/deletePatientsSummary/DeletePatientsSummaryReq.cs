using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Drchrono.deletePatientsSummary
{
    public class DeletePatientsSummaryReq : IRequest<ResponseData<DeletePatientsSummaryRes>>
    {

    }
}
