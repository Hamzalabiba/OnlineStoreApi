using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repstory.Repostory
{
    public interface IRepstory<T> where T : class 
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        void Insert(T entity);
        void Update(int Id);
        void Delete(T entity);
    }
}
