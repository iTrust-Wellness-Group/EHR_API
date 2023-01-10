using EHR.Shared.Utils.Http;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Context.CRM
{
    public class File
    {
        IHttpRequest? request = null;
        public File(IHttpRequest request)
        {
            this.request = request;
        }

        public Task<T> getFile<T>()
        {
            return this.request!.GetAsync<T>("LeadManagement.svc/Leads.GetById?");
        }


        public Task<T> sendFile<T>(object data)
        {
            return this.request!.PostAsync<T>("FileMarketing.svc/SendFileToLead", data);
        }

        public Task<T> uploadImage<T>(string leadId, IFormFile formFile)
        {
            //Different subdomain for file related APIs
            this.request!.BaseUrl = "https://files-us11.leadsquared.com/";

            //Process Hexadecimal representation of Image
            

            MultipartFormDataContent formContent = new MultipartFormDataContent
            {
                {new StringContent("1"), "FileType"},
                {new StringContent("0"), "FileStorageType"},
                {new StringContent("0"), "Entity"},
                {new StringContent(leadId), "Id"},
                {new StringContent(this.request!.Token), "AccessKey"},
                {new StringContent(this.request!.SecretKey), "SecretKey"},
                {new StreamContent(formFile.OpenReadStream()), "uploadFiles", formFile.Name}
            };

            return this.request!.PostAsync<T>("File/Upload", formContent);
        }

 

    }
}
