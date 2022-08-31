using EHR.Application.Contract.Identity;
using EHR.Application.Feature.Identity.Models;
using EHR.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Infrastructure.Repositories
{
    internal class IdentityRepository : IIdentityRepository
    {
        public Task<ResponseData<LoginResponseModel>> LoginAsync(LoginModel req)
        {
            throw new NotImplementedException();
        }

        public Task LoginO365Async()
        {
            throw new NotImplementedException();
        }
    }
}
