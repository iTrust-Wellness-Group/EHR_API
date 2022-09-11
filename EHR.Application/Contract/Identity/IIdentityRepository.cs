using EHR.Application.Feature.Identity.Models;
using EHR.Application.Models;
using EHR.Database.Entities;
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
        public Task<Account> LoginAsync(LoginModel req);
        public bool RefreshTokenAsync(RefreshModel req);
        public bool RevokeToken(RefreshModel req);
        #endregion

        #region 第三方登入
        public Task LoginO365Async();

        #endregion
    }
}
