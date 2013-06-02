using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Domain.Application;
using Business.Common.QueryModel;
using Business.Domain.Wms;
using Business.Domain.Inventory;
using Business.Domain.Warehouse;

namespace Wms.Common
{
    public static class CacheHelper
    {
        public static List<DataDictionary> DictionaryCache { get; set; }

        public static List<User> UserCache { get; set; }

        public static List<Company> CompanyCache { get; set; } 

        public static List<Warehouse> WarehouseCache { get; set; }

        public static List<Area> AreaCache { get; set; }

        public static List<ContainerType> ContainerTypeCache { get; set; }

        static CacheHelper()
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("ApplicationId", CriteriaOperator.Equal, GlobalState.CurrentApplication.ApplicationId));

            DictionaryCache = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);

            UserCache = ServiceHelper.ApplicationService.GetUserByQuery(query);

            CompanyCache = ServiceHelper.BasicDataService.GetAllCompany();

            WarehouseCache = ServiceHelper.WarehouseService.GetAllWarehouse();

            AreaCache = ServiceHelper.WarehouseService.GetAllArea();

            ContainerTypeCache = ServiceHelper.WarehouseService.GetAllContainerType();
        }

        public static IEnumerable<DataDictionary> GetDictionaryByCategory(string category)
        {
            var dictionaries = from dictionary in DictionaryCache
                                                where dictionary.Category == category
                                                where dictionary.DictionaryLevel == 2
                                                orderby dictionary.DictionaryCode
                                                select dictionary;
            return dictionaries;
        }

        public static string GetUserName(int userId)
        {
            if (userId > 0)
            {
                User user = UserCache.Where(u => u.UserId == userId).First();
                if (user != null)
                    return user.UserName;
            }

            return string.Empty;
        }

        public static string GetCompanyName(int companyId)
        {
            if (companyId > 0)
            {
                Company company = CompanyCache.Where(c => c.CompanyId == companyId).First();
                if (company != null)
                    return company.ShortName;
            }
            return string.Empty;
        }

        public static Company GetCompany(int companyId)
        {
            if (companyId > 0)
                return CompanyCache.Where(c => c.CompanyId == companyId).First();

            return null;
        }

        public static int GetParentCompanyId(int childCompanyId)
        {
            Company company = CompanyCache.Where(c => c.CompanyId == childCompanyId).First();
            if (company != null)
                return company.ParentId;

            return 0;
        }

        public static User GetUser(int userId)
        {
            if (userId > 0)
                return UserCache.Where(u => u.UserId == userId).First();
            return null;
        }

        public static int GetDictionaryId(int dictionaryCode)
        {
            string code = dictionaryCode.ToString();
            DataDictionary dictionary = DictionaryCache.Where(d => d.DictionaryCode == code).First();
            if (dictionary != null)
                return dictionary.DictionaryId;

            return 0;
        }

        public static Warehouse GetWarehouseName(int warehouseId)
        {
            if (warehouseId > 0)
                return WarehouseCache.Where(w => w.WarehouseId == warehouseId).First();
            return null;
        }
    }
}
