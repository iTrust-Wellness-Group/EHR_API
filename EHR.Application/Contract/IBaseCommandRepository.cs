using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Application.Contract
{
    public interface IBaseCommandRepository<TEntity> where TEntity : class
    {
        public IDbContextTransaction BeginTransaction();
        public Task<IDbContextTransaction> BeginTransactionAsync();
        public Task<TEntity> CreateAsync(TEntity instance);
        public Task<bool> DeleteAsync(TEntity instance);
        public Task<int> UpdateAsync(TEntity instance);

    }
}
