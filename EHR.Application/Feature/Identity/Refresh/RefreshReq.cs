using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Identity.Refresh
{
    public class RefreshReq : IRequest<ResponseData<RefreshRes>>
    {
        public Guid UserID { get; set; }
        public Guid RefreshToken { get; set; }
    }
}
