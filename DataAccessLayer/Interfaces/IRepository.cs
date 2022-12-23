using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetList();
        T GetItem(int ID);
        int Create(T item);
        void Update(T item);
        void Delete(int ID);
    }
}
