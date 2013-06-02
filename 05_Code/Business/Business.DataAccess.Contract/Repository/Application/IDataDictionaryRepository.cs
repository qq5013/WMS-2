using System.Collections.Generic;
using Business.Domain.Application;

namespace Business.DataAccess.Contract.Repository.Application
{
    public interface IDataDictionaryRepository : IRepository<DataDictionary>
    {
        IList<DataDictionary> GetByCategory(string applicationCode, string category);

        DataDictionary GetByCode(string applicationCode, string dataDictionaryCode);
    }
}