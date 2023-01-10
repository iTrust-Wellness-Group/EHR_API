using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Feature.DetailedForm.SaveFormData
{
    public class FormDataModel
    {
        public Dictionary<string, object> formData { get; set; }
        public string formId { get; set; }
        public string csrfToken { get; set; }
        public string sharepointId { get; set; }
    }
}
