using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Domain.Application;
using Business.DataAccess.Repository.Application;

namespace Business.Component
{
    /// <summary>
    /// 应用管理器
    /// </summary>
    public class ApplicationManager
    {
        public static Application GetApplication(int applicationId)
        {
            var applicationRepository = new ApplicationRepository();
            return applicationRepository.Get(applicationId);
        }

        public static string GetUserName(int userId)
        {
            var repository = new UserRepository();
            User user = repository.Get(userId);
            if (user != null)
                return user.UserName;

            return string.Empty;
        }
    }
}
