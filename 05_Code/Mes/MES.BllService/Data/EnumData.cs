/*----------------------------------------------------------------
// Copyright (C) 2010 ���޹�˾
// ��Ȩ���С� 
//
// �ļ�����         EnumData.cs
// �ļ�����������   ö������
//
// 
// ������ʶ��
//
// �޸ı�ʶ��
// �޸�������
//
// �޸ı�ʶ��
// �޸�������
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using Frame.Utils.MetaDB;

namespace MES.BllService.Data
{
    /// <summary>
    ///     ��ȡ��������
    /// </summary>
    public class EnumData
    {
        private static List<EnumItem> _service;

        private static List<EnumItem> _typeService;

        private static List<EnumItem> _statusService;

        private static List<EnumItem> Service
        {
            get { return _service ?? (_service = ServiceBloker.GetEnumQuery(null)); }
        }

        private static List<EnumItem> TypeService
        {
            get { return _typeService ?? (_typeService = ServiceBloker.GetEnumQuery("Type")); }
        }

        private static List<EnumItem> StatusService
        {
            get { return _statusService ?? (_statusService = ServiceBloker.GetEnumQuery("Status")); }
        }

        /// <summary>
        ///     ��ȡö��ֵ
        /// </summary>
        /// <param name="enumName"></param>
        /// <returns></returns>
        public List<EnumItemInfo> Select(string enumName)
        {
            List<EnumItem> items = ServiceBloker.GetEnumQuery(enumName);
            //if (enumName.EndsWith("Type"))
            //{
            //    items = TypeService.FindAll(t => t.EnumName == enumName.Substring(0, enumName.Length - 4));
            //}
            //else if (enumName.EndsWith("Status"))
            //{
            //    items = StatusService.FindAll(t => t.EnumName == enumName.Substring(0, enumName.Length - 6));
            //}
            //else
            //{
            //    items = Service.FindAll(t => t.EnumName == enumName);
            //}

            Type conversionType = Type.GetType(string.Format("MES.Entity.{0},MES.Entity", enumName));

            return items.Select(enumItem =>
                {
                    var enumItemInfo = new EnumItemInfo
                        {
                            Code = enumItem.Code,
                            Description = enumItem.Description,
                            EnumName = enumItem.EnumName,
                            Name = enumItem.Name,
                            Value = enumItem.Value
                        };
                    try
                    {
                     //   enumItemInfo.EnumValue = Enum.ToObject(conversionType, enumItem.Value);
                    }
                    catch (Exception)
                    {
                    }
                    return enumItemInfo;
                }).ToList();
        }
    }
}