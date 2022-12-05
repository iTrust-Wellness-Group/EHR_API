using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.Drchrono.GetPatiens
{
    public class PatientsHandlerRes
    {

        public object previous { get; set; }
        public Result[] results { get; set; }
        public object next { get; set; }

        public class Result
        {
            public int id { get; set; }
            public string chart_id { get; set; }
            public string first_name { get; set; }
            public object middle_name { get; set; }
            public string last_name { get; set; }
            public string nick_name { get; set; }
            public string date_of_birth { get; set; }
            public string gender { get; set; }
            public string social_security_number { get; set; }
            public string race { get; set; }
            public string ethnicity { get; set; }
            public string preferred_language { get; set; }
            public object patient_photo { get; set; }
            public object patient_photo_date { get; set; }
            public string patient_payment_profile { get; set; }
            public string patient_status { get; set; }
            public string home_phone { get; set; }
            public string cell_phone { get; set; }
            public string office_phone { get; set; }
            public string email { get; set; }
            public string address { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string zip_code { get; set; }
            public string emergency_contact_name { get; set; }
            public string emergency_contact_phone { get; set; }
            public string emergency_contact_relation { get; set; }
            public string employer { get; set; }
            public string employer_address { get; set; }
            public string employer_city { get; set; }
            public string employer_state { get; set; }
            public string employer_zip_code { get; set; }
            public bool disable_sms_messages { get; set; }
            public int doctor { get; set; }
            public object primary_care_physician { get; set; }
            public object date_of_first_appointment { get; set; }
            public string date_of_last_appointment { get; set; }
            public int?[] offices { get; set; }
            public string default_pharmacy { get; set; }
            public string referring_source { get; set; }
            public string copay { get; set; }
            public string responsible_party_name { get; set; }
            public string responsible_party_relation { get; set; }
            public string responsible_party_phone { get; set; }
            public string responsible_party_email { get; set; }
            public DateTime updated_at { get; set; }
        }

    }
}
