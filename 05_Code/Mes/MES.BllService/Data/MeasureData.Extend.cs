/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         MeasureData.Extend.cs
// 文件功能描述：   单位数据扩展
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

using MES.Entity;

namespace MES.BllService.Data
{
    /// <summary>
    ///     单位数据扩展
    /// </summary>
    public partial class MeasureData : BaseData<Measure>
    {
        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateAdvance(Measure entity)
        {
            Measure measure = Service.GetById(entity.GetEntityId());
            measure.Code = entity.Code;
            measure.ConvertRate = entity.ConvertRate;
            measure.Description = entity.Description;
            measure.Name = entity.Name;
            measure.Type = entity.Type;
            Update(measure);
        }

        /// <summary>
        ///     插入
        /// </summary>
        /// <param name="entity"></param>
        public void InsertAdvance(Measure entity)
        {
            Insert(entity);
        }
    }
}