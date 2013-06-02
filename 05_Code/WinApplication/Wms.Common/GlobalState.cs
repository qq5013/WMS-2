using System;
using System.Collections;
using System.Collections.Generic;
using Business.Domain.Application;
using Business.Domain.Wms;
using Business.Common;
using Business.Common.Exception;
using System.ServiceModel;

namespace Wms.Common
{
    public class GlobalState
    {
        public static string ApplicationCode = ApplicationInformation.ApplicationCode;

        public static Application CurrentApplication;

        public static Warehouse CurrentWarehouse;

        /// <summary>
        /// 登录用户
        /// </summary>
        public static User CurrentUser;

        /// <summary>
        /// 登录用户权限列表
        /// </summary>
        public static List<string> CurrentAuthority;

        /// <summary>
        /// 多语言管理器
        /// </summary>
        //public static LanguageHelper LanguageHelper;

        /// <summary>
        /// 客户端打印机序号
        /// </summary>
        public static int PrintIndex;

        public static string SkuImagesPath;

        ///// <summary>
        ///// 缺省货主编号
        ///// </summary>
        //public static int DefaultOwnerId;

        ///// <summary>
        ///// 是否仓库操作员
        ///// </summary>
        //private static bool _isWarehouseUser;
        //public static bool IsWarehouseUser
        //{
        //    get
        //    {
               
        //        return _isWarehouseUser;
        //    }
        //    set { _isWarehouseUser = value; }
        //}

       
        static GlobalState()
        {
            //string languageCode = System.Configuration.ConfigurationManager.AppSettings["LanguageCode"];
            //if (languageCode == "")
            //    LanguageHelper = new MultiLanguageHelper("zh-CHS");
            //else
            //    LanguageHelper = new MultiLanguageHelper(languageCode);

            string printConfig = System.Configuration.ConfigurationManager.AppSettings["PrintIndex"];
            try
            {
                PrintIndex = Int32.Parse(printConfig);
            }
            catch (Exception)
            {
                PrintIndex = 0;
            }

            try
            {
                SkuImagesPath = System.Configuration.ConfigurationManager.AppSettings["ImagesPath"];
            }
            catch (Exception ex)
            {
                ;
            }


            try
            {
                CurrentApplication = ServiceHelper.ApplicationService.GetApplicationByCode(ApplicationCode);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    System.Windows.Forms.MessageBox.Show(sex.Detail.ErrorMessage);
            }

            //const string parameterName = "DEFAULT_OWNER_COMPANYCODE";
            //Parameter parameter = ServiceHelper.ApplicationService.GetParameterByCode(ApplicationCode, parameterName);
            //if (parameter != null)
            //{
            //    string companyCode = parameter.ParameterValue;
            //    //DefaultOwnerId = BusinessKit.GetCompanyId(companyCode);
            //}
        }
    }
}
