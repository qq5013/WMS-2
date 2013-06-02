using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Component.Strategy
{
    /// <summary>
    /// 上架策略工厂类
    /// </summary>
    public class PickingStrategyFactory
    {
        /// <summary>
        /// 获取上架策略类
        /// </summary>
        /// <param name="strategyName">策略名称</param>
        /// <returns>返回上架策略类</returns>
        public static IPickingStrategy GetPickingStrategy(string strategyName)
        {
            switch (strategyName)
            {
                default:
                    return new DefaultPickingStrategy();
                    break;
            }
        }
    }
}
