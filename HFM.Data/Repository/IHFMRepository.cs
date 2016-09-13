using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFM.Data.Repository
{
    public interface IHFMRepository<T>
    {
        IList<T> Get();
        T GetById(int id);
        T Add(T data);
        T Update(T data);
        void Delete(int id);
    }
}
