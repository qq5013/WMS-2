/*----------------------------------------------------------------
// Copyright (C) 2010 ���޹�˾
// ��Ȩ���С� 
//
// �ļ�����         SkuInfoData.cs
// �ļ�����������   ������Ϣ����
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

using System.Collections.Generic;
using System.ComponentModel;
using Frame.Utils.RelaAndCondition;
using Frame.Utils.Service;

namespace MES.BllService.Data
{
    /// <summary>
    ///     ������Ϣ����
    /// </summary>
    public class SkuInfoData
    {
        public List<SkuInfo> Select()
        {
            IEntityQuery<SkuInfo> service = ServiceBloker.GetQuery<SkuInfo>();
            //t => t.IsMateriel == true, new ListSortDescriptionCollection(new ListSortDescription[] { new ListSortDescription(PropertyDescriptor.("Code",null),ListSortDirection.Ascending), })
            return
                service.GetAll(new QueryInfo
                    {
                        Condition = new EntityColumn("t.IsMateriel") == true,
                        CompositorList =
                            new List<Compositor>
                                {
                                    new Compositor
                                        {
                                            Column = new EntityColumn("t.Code"),
                                            SortDirection = ListSortDirection.Ascending
                                        }
                                }
                    });
        }
    }
}