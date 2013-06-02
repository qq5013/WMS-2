using System.Collections;

namespace Wms.Common
{
    public static class ClientCacheHelper
    {
        //public static Hashtable CacheVersion { get; set; }

        //public static Hashtable CacheData { get; set; }

        //static ClientCacheHelper()
        //{
        //    CacheVersion = new Hashtable();
        //    CacheData = new Hashtable();
        //}

        //private static void AddCache(CacheType cacheType, int version, ArrayList dataList)
        //{
        //    string cacheName = cacheType.ToString();

        //    if (!CacheVersion.ContainsKey(cacheName))
        //    {
        //        CacheVersion.Add(cacheName, version);
        //        CacheData.Add(cacheName, dataList);
        //    }
        //}

        //private static void UpdateCache(CacheType cacheType, int version, ArrayList dataList)
        //{
        //    string cacheName = cacheType.ToString();

        //    CacheVersion[cacheName] = version;
        //    CacheData[cacheName] = dataList;
        //}

        //public static void UpdateServerCache(CacheType cacheType)
        //{
        //    ServiceHelper.FacadeService.UpdateServerCache(cacheType.ToString());
        //}

        //public static ArrayList LoadCache(CacheType cacheType)
        //{
        //    string cacheName = cacheType.ToString();
        //    // communicate with server, transfer cache name and version to server
        //    // if server cache is newer than client, then transfer  to client
        //    // else server return null to client
        //    IBusinessFacade service = ServiceHelper.FacadeService;
        //    CacheInformation cache;
        //    if (CacheVersion.ContainsKey(cacheName))
        //    {
        //        // call bll LoadCache with client version
        //        int clientVersion = (int)CacheVersion[cacheName];
        //        cache = service.LoadCache(cacheName, clientVersion);
        //    }
        //    else
        //    {
        //        // call bll LoadCache with version 0
        //        cache = service.LoadCache(cacheName, 0);
        //    }

        //    // according to the return cache informartion, process the result
        //    if (CacheVersion.ContainsKey(cacheName))
        //    {
        //        if (cache.DataList != null)
        //        {
        //            UpdateCache(cacheType, cache.Version, cache.DataList);
        //        }
        //        else
        //        {
        //            cache.DataList = (ArrayList)CacheData[cacheName];
        //        }
        //    }
        //    else
        //    {
        //        AddCache(cacheType, cache.Version, cache.DataList);
        //    }

        //    return cache.DataList;
        //}


    }
}
