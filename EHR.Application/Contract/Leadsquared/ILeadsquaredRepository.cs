using EHR.Application.Feature.Identity.Login;
using EHR.Application.Feature.Identity.Refresh;
using EHR.Application.Feature.Leadsquared.PostContactFormScript;
using EHR.Application.Feature.Leadsquared.PostDetailedFormScript;
using EHR.Application.Feature.Leadsquared.ResumeDetailForm;
using EHR.Application.Models;
using EHR.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Contract.Leadsquared
{
    public interface ILeadsquaredRepository
    {

        #region API for leadsqaured's lapp
        public Task<bool> PostContactFormScript(PostContactFormScriptReq req);
        /*
            1. Generate csrf_token associated with lead's lsq_id
            2. Send link to detailed form + csrf_token
            3. Call leadsquared API to update lead's status 
         
        */
        public Task<bool> PostDetailFormScript(PostDetailedFormScriptReq req);
        /*
            1. Create DrChrono Profile
            2. Create iTrust account
            3. Create Appointment
            4. Call leadsquared's API to update lead's status
         */

        public Task<bool> ResumeDetailedForm(ResumeDetailFormReq req);
        /*
            1. Lookup csrf_token table to find the form
            2. Update the csrf_token if it's expired
            3. Send an email with the form_url + renewed csrf_token to the patient
         */
        #endregion
    }
}
