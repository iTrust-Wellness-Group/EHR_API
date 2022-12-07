using EHR.Shared.Utils.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Context.Drchrono
{
    public class Patient
    {
        IHttpRequest? request = null;
        public Patient(IHttpRequest request) {
            this.request = request;
        }

        public Task<T> getPatients<T>()
        {
           return this.request.GetAsync<T>("patients");
        }
        public Task<T> createPatient<T>(object data)
        {
            return this.request.PostAsync<T>("patients",data);
        }
        public Task<T> updatePatient<T>(object data)
        {
            return this.request.PostAsync<T>("patients", data);
        }
        public Task<T> deletePatient<T>(object data)
        {
            return this.request.PostAsync<T>("patients", data);
        }
        public Task<T> getPatientsCCDA<T>()
        {
            return this.request.GetAsync<T>("patients");
        }
        public Task<T> getOnpatientAccess<T>()
        {
            return this.request.GetAsync<T>("onpatientAccess");
        }
        public Task<T> CreateOnpatientAccess<T>(object data)
        {
            return this.request.PostAsync<T>("onpatientAccess", data);
        }
        public Task<T> DeleteOnpatientAccess<T>(object data)
        {
            return this.request.PostAsync<T>("onpatientAccess", data);
        }
        public Task<T> GetPatientsSummary<T>()
        {
            return this.request.GetAsync<T>("patientsSummary");
        }
        public Task<T> CreatPatientsSummary<T>(object data)
        {
            return this.request.PostAsync<T>("PatientsSummary", data);
        }
        public Task<T> UpdatePatientsSummary<T>(object data)
        {
            return this.request.PostAsync<T>("PatientsSummary", data);
        }
        public Task<T> UpdatePatientsSummaryPart<T>(object data)
        {
            return this.request.PostAsync<T>("PatientsSummary", data);
        }
        public Task<T> DeletePatientsSummary<T>(object data)
        {
            return this.request.PostAsync<T>("onpatientAccess", data);
        }
    }
}
