/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         ProcessStepInfo.cs
// 文件功能描述：   工序显示
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

using System;
using System.Collections.Generic;
using MES.BllService;
using MES.Entity;
using MES.Enum;

namespace MES.Execute.Controls
{
    /// <summary>
    /// 工序显示
    /// </summary>
    public class ProcessStepInfo
    {
        private readonly List<ProcessStepInfoDetail> _details = new List<ProcessStepInfoDetail>();

        /// <summary>
        /// 提示
        /// </summary>
        public string Notice { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status
        {
            get
            {
                if (ProcessStep == null)
                    return "未完成";

                // 显示不同状态的中文名
                switch (ProcessStep.Status)
                {
                    case ItemProcessStepStatus.UnProcess:
                        return "未完成";
                    case ItemProcessStepStatus.Processing:
                        return "处理中";
                    case ItemProcessStepStatus.Processed:
                        return "已完成";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// 工步信息明细
        /// </summary>
        public List<ProcessStepInfoDetail> Details
        {
            get { return _details; }
        }

        /// <summary>
        /// 工步Id
        /// </summary>
        public int ProcessStepId { get; set; }

        /// <summary>
        /// 工步
        /// </summary>
        public ItemProcessStep ProcessStep { get; set; }

        /// <summary>
        /// 设置工序状态
        /// </summary>
        /// <param name="status"></param>
        /// <param name="itemProcessId"></param>
        public void SetStatus(ItemProcessStepStatus status, int itemProcessId)
        {
            // 如果工步不存在则新建
            if (ProcessStep == null)
                ProcessStep = new ItemProcessStep {ItemProcessId = itemProcessId, ProcessStepId = ProcessStepId};

            ProcessStep.Status = status;
            int itemProcessStepId = ProcessStep.Save();
            if (ProcessStep.ItemProcessStepId == 0)
            {
                ProcessStep.ItemProcessStepId = itemProcessStepId;
            }
        }

        /// <summary>
        /// 重新绑定
        /// </summary>
        /// <returns></returns>
        public bool RebindItem()
        {
            foreach (ItemProcessStepDetail itemProcessStepDetail in ProcessStep.Details)
            {
                ItemProcessStepDetail detail = itemProcessStepDetail;
                _details.Find(c => c.SkuId == detail.SkuId).DoneQuantity++;
            }
            return ProcessStep.Status == ItemProcessStepStatus.Processed;
        }
    }
}