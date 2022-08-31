using EHR.Application.Feature.Identity.Models;
using EHR.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Contract.Identity
{
    public interface IIdentityRepository
    {

        #region 基本系統登入
        public Task<ResponseData<LoginResponseModel>> LoginAsync(LoginModel req);
        #endregion

        #region 第三方登入
        public Task LoginO365Async();

        #endregion
    }
}
