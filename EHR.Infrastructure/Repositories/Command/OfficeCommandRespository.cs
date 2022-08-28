using EHR.Application.Contract.ReferralSystem.Office;
using EHR.Database.Context;
using EHR.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EHR.Infrastructure.Repositories.Command
{
    internal class OfficeCommandRespository : BaseCommandRepository<Office>, IOfficeCommandRepository
    {
        public OfficeCommandRespository(DatabaseContext commandContext) : base(commandContext)
        {
        }



        public async Task<bool> createOffice(String Name)
        {
            try
            {
                Office office = new Office();
                office.Id = Guid.NewGuid();
                office.Name = Name;
                await CreateAsync(office);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
