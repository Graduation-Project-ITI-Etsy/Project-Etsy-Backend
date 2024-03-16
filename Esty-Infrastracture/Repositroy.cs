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
        public Repository(EtsyDbContext _etsyDbContext)
        {
            etsyDbContext = _etsyDbContext;

        }
        public List<T> GetAllEntity()
        {
            var QueryAllEntity = etsyDbContext!.Set<T>();
            return QueryAllEntity.ToList();
        }

        public T GetEntitybyId(TID id)
        {
            var QueryIdEntity = etsyDbContext!.Set<T>().Find(id);
            return QueryIdEntity!;
        }

        public T CreateEntity(T Entity)
        {
            var QueryCreateEntity = etsyDbContext!.Set<T>().Add(Entity).Entity;
            return QueryCreateEntity;
        }

        public T UpdateEntity(T Entity)
        {
            return etsyDbContext!.Set<T>().Update(Entity).Entity;
        }

        public T DeleteEntity(TID id)
        {
            var EntityToDelete = etsyDbContext!.Set<T>().Find(id);
            if (EntityToDelete != null)
            {
                etsyDbContext.Set<T>().Remove(EntityToDelete);
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
