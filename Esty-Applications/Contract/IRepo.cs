using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Contract
{
    public interface IRepo<T, TID>
    {
        List<T> GetAllEntity();

        T GetEntitybyId(TID id);

        T CreateEntity(T Entity);

        T UpdateEntity(T Entity);

        T DeleteEntity(TID id);

        public int Save();
    }
}
