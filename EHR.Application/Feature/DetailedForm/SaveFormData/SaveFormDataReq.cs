using EHR.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.DetailedForm.SaveFormData
{
    public class SaveFormDataReq : IRequest<ResponseData<SaveFormDataRes>>
    {
        public String csrfToken { get; set; }
        public String formData { get; set; }
    }
}
