using System.Collections.Generic;
using Business.Common.QueryModel;

namespace Business.DataAccess.Contract
{
    public interface IRepository<T>
    {
        int Create(T item);

        T Get(int id);

        T Get(long id);

        T GetByQuery(Query query);

        IList<T> GetAll();

        IList<T> GetListByQuery(Query query);

        bool Update(T item);

        bool Delete(int id);

        //bool Delete(long id);

        bool Delete(T item);

        bool DeleteAll();
    }
}