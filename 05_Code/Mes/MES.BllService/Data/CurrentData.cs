/*----------------------------------------------------------------
// Copyright (C) 2010 ���޹�˾
// ��Ȩ���С� 
//
// �ļ�����         CurrentData.cs
// �ļ�����������   ��ǰ�û�����
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
using System.Web;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.Web.Data
{
    /// <summary>
    /// ��ǰ�û�����
    /// </summary>
    public class CurrentData
    {
        /// <summary>
        /// ��ǰ�û�
        /// </summary>
        public static UserInfo CurrentUser
        {
            get
            {
                //var userInfo = HttpContext.Current.Items["UserInfo"] as UserInfo;
                return  new UserInfo();
            }
        }

        /// <summary>
        /// ��ȡ�û���Ϣ
        /// </summary>
        /// <returns></returns>
        public static string GetInfo()
        {
            string text = HttpContext.Current.Request.Url.ToString().ToLower();
            int lastIndexOf = text.LastIndexOf('/');
            const string logInPage = "~/Default.aspx";

            if (text.Substring(lastIndexOf).StartsWith(@"/default.aspx"))
            {
                return string.Empty;
            }
            HttpRequest request = HttpContext.Current.Request;
            try
            {
                string url = request.Url.ToString();
                int pageIndex = url.LastIndexOf("Page.aspx", StringComparison.OrdinalIgnoreCase);
                if (pageIndex <= 0)
                {
                    return string.Empty;
                }
                int pageStartIndex = url.LastIndexOf(@"/", StringComparison.OrdinalIgnoreCase);
                string fullFolder = url.Substring(0, pageStartIndex);
                int folderStartIndex = fullFolder.LastIndexOf(@"/", StringComparison.OrdinalIgnoreCase);
                string authorityCode = url.Substring(pageStartIndex + 1, pageIndex - pageStartIndex - 1);
                string folder = fullFolder.Substring(folderStartIndex + 1);


                string re = request.Cookies["MES_LOGON" + request.ServerVariables["REMOTE_ADDR"]].Value;

                string userName = re.Split(",".ToCharArray())[0];
                string passWord = re.Split(",".ToCharArray())[1];

                IEntityService<User> bll = ServiceHelper.GetService<User>();
                List<User> users = bll.FindAll(c => c.LogInName == userName && c.IsDeactivated == false, null);
                bool isExist = false;
                UserInfo userInfo = null;
                if (users.Count > 0)
                {
                    foreach (User info in users)
                    {
                        if (info.Password == passWord)
                        {
                            userInfo = new UserInfo {User = info};
                            isExist = true;
                            break;
                        }
                    }
                }

                string time = re.Split(",".ToCharArray())[2];
                if (isExist && DateTime.Now - DateTime.Parse(time) < new TimeSpan(23, 59, 59))
                {
                    var sessionCookie = new HttpCookie("MES_LOGON" + request.ServerVariables["REMOTE_ADDR"])
                                            {
                                                Path = "/",
                                                Value =
                                                    userName + "," + passWord + "," +
                                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                            };
                    HttpContext.Current.Response.Cookies.Add(sessionCookie);
                }
                else
                {
                    var sessionCookie = new HttpCookie("MES_LOGON" + request.ServerVariables["REMOTE_ADDR"])
                                            {
                                                Path = "/",
                                                Value =
                                                    "userName" + "," + "passWord" + "," +
                                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                            };
                    HttpContext.Current.Response.Cookies.Add(sessionCookie);
                    return logInPage;
                }
                List<int> roleIds =
                    ServiceHelper.GetService<UserInRole>().FindAll(c => c.UserId == userInfo.UserId, null).Select(
                        c => c.RoleId).ToList();


                List<Permission> authorities;
                if (string.Compare(folder, "Pages", true) == 0)
                {
                    List<int> permissionIds =
                        ServiceHelper.GetService<PermissionInRole>().FindAll(c => roleIds.Contains(c.RoleId), null).
                            Select(
                                c => c.PermissionId).ToList();

                    authorities =
                        ServiceHelper.GetService<Permission>().FindAll(
                            c => permissionIds.Contains(c.PermissionId) && c.Type == PermissionType.Normal, null);
                }
                else
                {
                    return logInPage;
                }
                if (roleIds.Count > 0)
                {
                    List<Role> roles = ServiceHelper.GetService<Role>().FindAll(c => roleIds.Contains(c.RoleId), null);
                    userInfo.Roles.AddRange(roles);
                    if (roles.Count > 0)
                    {
                        List<int> authorityIds =
                            ServiceHelper.GetService<PermissionInRole>().FindAll(c => roleIds.Contains(c.RoleId), null).
                                Select(
                                    c => c.PermissionId).ToList();
                        if (authorityIds.Count > 0)
                        {
                            List<Permission> list = authorities.FindAll(c => authorityIds.Contains(c.PermissionId));
                            userInfo.Authorities.AddRange(list);
                        }
                    }
                }

                HttpContext.Current.Items["UserInfo"] = userInfo;

                // ������ڸ�ҳ���Ȩ�ޣ������û�û�д�Ȩ��
                if (authorities.Exists(c => c.Code == authorityCode)
                    && !userInfo.Authorities.Exists(c => c.Code == authorityCode))
                {
                    return "MainPage.aspx";
                }

                return string.Empty;
            }
            catch
            {
                var sessionCookie = new HttpCookie("MES_LOGON" + request.ServerVariables["REMOTE_ADDR"])
                                        {
                                            Path = "/",
                                            Value =
                                                "userName" + "," + "passWord" + "," +
                                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                                        };
                HttpContext.Current.Response.Cookies.Add(sessionCookie);
                return logInPage;
            }
        }
    }
}