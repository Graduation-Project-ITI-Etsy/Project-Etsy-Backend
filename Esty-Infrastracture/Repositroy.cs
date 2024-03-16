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
            etsyDbContext = _etsyDbContext;
            DbSetEntity = _etsyDbContext.Set<T>();
        }
        public List<T> GetAllEntity()
        {
            var QueryAllEntity = DbSetEntity;
            return QueryAllEntity.ToList();
        }

        public T GetEntitybyId(TID id)
        {
            var QueryIdEntity = DbSetEntity.Find(id);
            return QueryIdEntity!;
        }

        public T CreateEntity(T Entity)
        {
            var QueryCreateEntity = DbSetEntity.Add(Entity).Entity;
            return QueryCreateEntity;
        }

        public T UpdateEntity(T Entity)
        {
            return DbSetEntity.Update(Entity).Entity;
        }

        public T DeleteEntity(TID id)
        {
            var EntityToDelete = DbSetEntity.Find(id);
            if (EntityToDelete != null)
            {
                DbSetEntity.Remove(EntityToDelete);
                etsyDbContext.SaveChanges();
            }
            return EntityToDelete!;
        }

        public int Save()
        {
            return etsyDbContext!.SaveChanges();
        }
    }
}
