/*----------------------------------------------------------------
// Copyright (C) 2010 有限公司
// 版权所有。 
//
// 文件名：         CurrentUser.cs
// 文件功能描述：   当前用户信息
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
using MES.Web.Data;

namespace MES.Web
{
    /// <summary>
    /// 当前用户信息
    /// </summary>
    public class CurrentUser : ICurrentUser
    {
        #region ICurrentUser Members

        /// <summary>
        /// 当前用户Id
        /// </summary>
        /// <returns></returns>
        public int UserId()
        {
            return CurrentData.CurrentUser.UserId;
        }

        /// <summary>
        /// 当前用户名称
        /// </summary>
        /// <returns></returns>
        public string UserName()
        {
            return CurrentData.CurrentUser.Name;
        }

        #endregion
    }
}