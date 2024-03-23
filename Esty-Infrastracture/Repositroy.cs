using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esty_Context;
using Microsoft.EntityFrameworkCore;

namespace Esty_Applications.Contract
{
    public class Repository<T, TID> : IRepo<T, TID> where T : class
    {

        EtsyDbContext? etsyDbContext { get; set; }
        DbSet<T> DbSetEntity;

        public Repository(EtsyDbContext _etsyDbContext)
        {

            etsyDbContext = _etsyDbContext ?? throw new ArgumentNullException(nameof(etsyDbContext));
            DbSetEntity = _etsyDbContext.Set<T>();
        }
       
       
        // Asynchronous versions implemented synchronously
        public async Task<IQueryable<T>> GetAllEntity()
        {
            return DbSetEntity.Select(s => s);
        }

        public async Task<T> GetEntitybyId(TID id)
        {
            return await DbSetEntity.FindAsync(id);
        }

        public async Task<T> CreateEntity(T Entity)
        {
            DbSetEntity.Add(Entity);
            await etsyDbContext.SaveChangesAsync();
            return Entity;
        }

        public async Task<T> UpdateEntity(T Entity)
        {
            DbSetEntity.Update(Entity);
            await etsyDbContext.SaveChangesAsync();
            return Entity;
        }

        public async Task<T> DeleteEntity(TID id)
        {
            var entityToDelete = await DbSetEntity.FindAsync(id);

            if (entityToDelete != null)
            {
                DbSetEntity.Remove(entityToDelete);
                await etsyDbContext.SaveChangesAsync();
            }

            return entityToDelete;
        }

        public Task<int> Save()
        {
            return  etsyDbContext.SaveChangesAsync();
        }

    }
}
