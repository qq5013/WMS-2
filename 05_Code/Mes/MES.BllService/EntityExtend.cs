/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         
// 文件功能描述：   
//
// 
// 创建标识：
//
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using Frame.Utils.Contract;
using Frame.Utils.Service;

namespace MES.BllService
{
    public static class EntityExtend
    {
        /// <summary>
        ///     扩展save方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int Save<T>(this T data) where T : class, IBaseEntity
        {
            IEntityService<T> entityService = ServiceBloker.GetService<T>();
            int save = entityService.Save(data);
            //if (data.GetEntityId() <= 0)
            //{
            //    data.SetPropertyValue(typeof (T).Name + "Id", save);
            //}
            return save;
        }

        // 扩展remove方法
        public static int Remove<T>(this T data) where T : class, IBaseEntity
        {
            IEntityService<T> entityService = ServiceBloker.GetService<T>();
            int id = data.GetEntityId();
            if (id > 0)
                return entityService.Delete(id);
            return 0;
        }
    }
}