using EHR.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EHR.Application.Feature.DetailedForm.SaveFormAttachments
{
    public class SaveFormAttachmentsReq : IRequest<ResponseData<SaveFormAttachmentsRes>>
    {
        public string csrfToken { get; set; }
       
       
        public IFormFile File { get; set; }

    }
}
