using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Domain.Wms;
using Business.DataAccess.Repository.Wms;

namespace Business.Component
{
    public class CompanyManager
    {
        public static Company GetCompany(int companyId)
        {
            var repository = new CompanyRepository();
            return repository.Get(companyId);
        }
    }
}
