using EHR.Application.Feature.Identity.Login;
using EHR.Application.Feature.Identity.Refresh;
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
        public Task<Account> LoginAsync(IdentityReq req);
        public bool RefreshTokenAsync(RefreshReq req);
        public bool RevokeToken(RefreshReq req);
        #endregion

        #region 第三方登入
        public Task LoginO365Async();

        #endregion
    }
}
