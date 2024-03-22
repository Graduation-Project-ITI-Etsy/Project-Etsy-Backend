using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Contract
{
    public interface IRepo<T, TID>
    {
        Task<IQueryable<T>> GetAllEntity();

        Task<T> GetEntitybyId(TID id);

        Task<T> CreateEntity(T Entity);

        Task<T> UpdateEntity(T Entity);

        Task<T> DeleteEntity(TID id);

        Task<int> Save();

    }
}
