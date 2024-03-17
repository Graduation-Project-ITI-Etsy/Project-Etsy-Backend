using Esty_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esty_Applications.Contract
{
    public interface IBaseCategoryRepository : IRepo<BaseCategory , int>
    {
        BaseCategory SearchBaseCategoryByName(string name);
    }
}
