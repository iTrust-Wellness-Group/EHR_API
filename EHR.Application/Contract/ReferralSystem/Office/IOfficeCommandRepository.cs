using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.Database.Entities;
namespace EHR.Application.Contract.ReferralSystem.Office
{
    public interface IOfficeCommandRepository:IBaseCommandRepository<EHR.Database.Entities.Office>
    {
        Task<bool> createOffice(String Name);
    }
}
