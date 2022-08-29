using EHR.Application.Contract;
using EHR.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Infrastructure.Repositories.Command
{
    public class BaseRepository<TEntity> : IBaseCommandRepository<TEntity>
     where TEntity : class
    {
        protected readonly DatabaseContext CommandContext;

        public BaseRepository(DatabaseContext commandContext)
        {
            CommandContext = commandContext;
        }
        public IDbContextTransaction BeginTransaction()
        {
            var transaction = CommandContext.Database.BeginTransaction();
            return transaction;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            var transaction = await CommandContext.Database.BeginTransactionAsync();
            return transaction;
        }
        public async Task<TEntity> CreateAsync(TEntity instance)
        {
            try
            {
                if (instance == null)
                {
                    throw new ArgumentNullException("instance");
                }
                else
                {
                    CommandContext.Set<TEntity>().Add(instance);
                    await CommandContext.SaveChangesAsync();
                    return instance;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<int> UpdateAsync(TEntity instance)
        {
            try
            {
                if (instance == null)
                {
                    throw new ArgumentNullException("instance");
                }
                else
                {
                    CommandContext.Entry(instance).State = EntityState.Modified;
                    var i = await CommandContext.SaveChangesAsync();
                    return i;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteAsync(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                CommandContext.Entry(instance).State = EntityState.Deleted;
                await CommandContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<int> UpdateRangeAsync(IEnumerable<TEntity> instances)
        {
            if (instances.Any() == false)
            {
                return 0;
            }

            foreach (var instance in instances)
            {
                CommandContext.Entry(instance).State = EntityState.Modified;
            }

            return await CommandContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> CreateRangeAsync(List<TEntity> instances)
        {
            try
            {
                if (instances == null)
                {
                    throw new ArgumentNullException("instance");
                }
                else
                {
                    foreach (var instance in instances)
                    {
                        CommandContext.Set<TEntity>().Add(instance);
                    }
                    await CommandContext.SaveChangesAsync();
                    return instances;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<bool> DeleteRangeAsync(List<TEntity> instances)
        {
            if (instances == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                foreach (var instance in instances)
                {
                    CommandContext.Entry(instance).State = EntityState.Deleted;
                }
                await CommandContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
          return this.CommandContext.Set<TEntity>().ToList();
        }

        public ValueTask<TEntity?> GetAsync(Guid id)
        {
            return this.CommandContext.Set<TEntity>().FindAsync(id);
        }

        public ValueTask<TEntity?> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return CommandContext.Set<TEntity>().FindAsync(expression);
        }

        public Task<List<TEntity>> FindMultiAsync(Expression<Func<TEntity, bool>> expression)
        {
            return CommandContext.Set<TEntity>().Where(expression).ToListAsync();
        }
    }
}
