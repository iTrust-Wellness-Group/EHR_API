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
        public void getPatient(string patientId)
        {

        }

        public Task<T> createPatient<T>(object data)
        {
            return this.request.PostAsync<T>("patients",data);
        }
    }
}
