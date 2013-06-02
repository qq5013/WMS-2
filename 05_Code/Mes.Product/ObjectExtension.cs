using System;
using System.Collections.Generic;
using System.Reflection;
using MES.BllService;
using MES.Common;
using MES.Entity;
using Mes.Product.Modules.MaterialRequisitionModel;
using Mes.Product.Modules.ProductionOrderModel;

namespace Mes.Product
{
    public static class ObjectExtension
    {
        public static T CopyTo<T>(this object obj) where T : new()
        {
            var info = new T();

            Type ts = obj.GetType();
            foreach (PropertyInfo propertyInfo in typeof (T).GetProperties())
            {
                PropertyInfo property = ts.GetProperty(propertyInfo.Name);
                try
                {
                    propertyInfo.SetValue(info, property.GetValue(info, null), null);
                }
                catch (Exception ex)
                {
                    ex.Process();
                }
            }
            return info;
        }

        public static void CopyTo<TFrom, TTo>(this IList<TFrom> fromList, IList<TTo> toList)
            where TTo : IDetailModel, new()
        {
            Type tfrom = typeof (TFrom);
            PropertyInfo[] propertyInfos = tfrom.GetProperties();

            Type tto = typeof (TTo);

            for (int c = 0, count = fromList.Count; c < count; c++)
            {
                var info = new TTo();

                for (int i = 0, j = propertyInfos.Length; i < j; i++)
                {
                    PropertyInfo propertyInfo = tto.GetProperty(propertyInfos[i].Name);
                    try
                    {
                        propertyInfo.SetValue(info, propertyInfos[i].GetValue(fromList[c], null), null);
                    }
                    catch (Exception ex)
                    {
                        ex.Process();
                    }
                }
                info.TempId = c;
                info.OperationName = "NONE";
                toList.Add(info);
            }
        }
    }
}