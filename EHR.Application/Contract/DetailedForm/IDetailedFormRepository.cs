using Amazon.DynamoDBv2.Model;
using EHR.Application.Feature.DetailedForm.GetFormData;
using EHR.Application.Feature.Identity.Login;
using EHR.Application.Feature.Identity.Refresh;
using EHR.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Contract.DetailedForm
{
    internal interface IDetailedFormRepository
    {
       

        public Task<Dictionary<string,Object>> GetFormData(GetFormDataReq req);
        /*
           1. use csrf token to lookup leadId
           2. use leadId to fetch all saved fields from leadsquared
           3. return formData to form

       */

        //public Task<Object> SaveFormData(SaveFormDataReq req)

    }
}
