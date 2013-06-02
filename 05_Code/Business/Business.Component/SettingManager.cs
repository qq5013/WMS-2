using System;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Common.Toolkit;
using Business.DataAccess.Repository.Warehouse;
using Business.Domain.Warehouse;

namespace Business.Component
{
    /// <summary>
    /// 仓库设置管理器
    /// </summary>
    public class SettingManager
    {
        /// <summary>
        /// 获取仓库设置
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="settingCode">设置代码</param>
        /// <returns>成功返回设置对象，否则返回null</returns>
        public static Setting GetSetting(int warehouseId, string settingCode)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("SettingCode", CriteriaOperator.Equal, settingCode));

            var settingRepository = new SettingRepository();
            return settingRepository.GetByQuery(query);
        }

        /// <summary>
        /// 创建仓库设置
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="settingCode">设置代码</param>
        /// <param name="valueType">值类型</param>
        /// <param name="settingValue">设置值</param>
        /// <param name="remark">备注</param>
        /// <param name="userId">创建用户编号</param>
        /// <returns>成功返回创建的设置对象，否则返回null</returns>
        public static Setting CreateSetting(int warehouseId, string settingCode, string valueType, string settingValue,
                                            string remark, int userId)
        {
            var setting = new Setting
                              {
                                  WarehouseId = warehouseId,
                                  SettingCode = settingCode,
                                  SettingValue = settingValue,
                                  ValueType = valueType,
                                  Remark = remark,
                                  CreateUser = userId,
                                  CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now),
                                  IsActive = true
                              };

            var settingRepository = new SettingRepository();
            int insertResult = settingRepository.Create(setting);

            if (insertResult > 0)
                return setting;
            else
                BusinessExceptionHelper.ThrowBusinessException("SETTING_CREATE_ERROR");

            return null;
        }

        /// <summary>
        /// 更新仓库设置
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="settingCode">设置代码</param>
        /// <param name="settingValue">设置值</param>
        /// <param name="remark">备注</param>
        /// <param name="userId">更新用户编号</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool UpdateSetting(int warehouseId, string settingCode, string settingValue, string remark,
                                         int userId)
        {
            Setting setting = GetSetting(warehouseId, settingCode);

            if (setting != null)
            {
                setting.SettingValue = settingValue;
                setting.Remark = remark;
                setting.EditUser = userId;
                setting.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);

                var settingRepository = new SettingRepository();
                return settingRepository.Update(setting);
            }

            return false;
        }

        /// <summary>
        /// 激活仓库设置
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="settingCode">设置代码</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool EnableSetting(int warehouseId, string settingCode)
        {
            Setting setting = GetSetting(warehouseId, settingCode);

            if (setting != null)
            {
                setting.IsActive = true;
                var settingRepository = new SettingRepository();
                return settingRepository.Update(setting);
            }

            return false;
        }

        /// <summary>
        /// 禁用仓库设置
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="settingCode">设置代码</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool DisableSetting(int warehouseId, string settingCode)
        {
            Setting setting = GetSetting(warehouseId, settingCode);

            if (setting != null)
            {
                setting.IsActive = false;
                var settingRepository = new SettingRepository();
                return settingRepository.Update(setting);
            }

            return false;
        }

        /// <summary>
        /// 仓库是否自动审核入库单
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <returns>自动审核返回true，否则返回false</returns>
        public static bool IsAutoConfirmIB(int warehouseId)
        {
            Setting setting = GetSetting(warehouseId, "AUTO_CONFIRM_INBOUNDBILL");
            if (setting == null)
            {
                setting = CreateSetting(warehouseId, "AUTO_CONFIRM_INBOUNDBILL", "Bool", "TRUE","", 0);
            }

            if (setting.SettingValue.ToLower() == true.ToString().ToLower())
                return true;

            return false;
        }

        /// <summary>
        /// 仓库是否自动审核出库单
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <returns>自动审核返回true，否则返回false</returns>
        public static bool IsAutoConfirmOB(int warehouseId)
        {
            Setting setting = GetSetting(warehouseId, "AUTO_CONFIRM_OUTBOUNDBILL");
            if (setting == null)
            {
                setting = CreateSetting(warehouseId, "AUTO_CONFIRM_OUTBOUNDBILL", "Bool", "TRUE", "", 0);
            }

            if (setting.SettingValue.ToLower() == true.ToString().ToLower())
                return true;

            return false;
        }

        /// <summary>
        /// 仓库是否自动审核移货单
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <returns>自动审核返回true，否则返回false</returns>
        public static bool IsAutoConfirmTB(int warehouseId)
        {
            Setting setting = GetSetting(warehouseId, "AUTO_CONFIRM_TRANSFERBILL");
            if (setting == null)
            {
                setting = CreateSetting(warehouseId, "AUTO_CONFIRM_TRANSFERBILL", "Bool", "TRUE", "", 0);
            }

            if (setting.SettingValue.ToLower() == true.ToString().ToLower())
                return true;

            return false;
        }
    }
}