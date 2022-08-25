using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Models
{
    public class ResponseData<T>:Response
    {
        public T Data { get; set; }

        public ResponseData(T Data)
        {
            this.Data = Data;
        }
        public ResponseData(int code,T Data)
        {
            this.Code = code;
            this.Data = Data;
        }
    }
}
