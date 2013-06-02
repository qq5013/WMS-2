namespace Business.Common.Exception.ExceptionCode
{
    /// <summary>
    /// 应用层错误描述
    /// </summary>
    public static class ApplicationExceptionCodeHelper
    {
        /// <summary>
        /// 登录的用户账户不存在
        /// </summary>
        public const string NotFoundUserAccount = "USER_NOTFOUND";

        /// <summary>
        /// 从用户组中移出用户失败
        /// </summary>       
        public const string RemoveUserFailedFromUserGroup = "GROUP_REMOVEUSER_FAILED";

        /// <summary>
        /// 从角色中移出用户失败
        /// </summary>
        public const string RemoveUserFailedFromRoleList = "ROLE_REMOVEUSER_FAILED";

        /// <summary>
        /// 删除系统用户失败
        /// </summary>
        public const string DeleteUserFailed = "USER_DELETE_FAILED";

        /// <summary>
        /// 登录用户口令不正确
        /// </summary>
        public const string ValidateUserPasswordFailed = "USER_PASSWORD_ERROR";

        /// <summary>
        /// 用户号已经存在
        /// </summary>
        public const string UserNumberExist = "USERCODE_EXISTS";

        /// <summary>
        /// 角色名称已经存在
        /// </summary>
        public const string RoleNameExist = "ROLECODE_EXISTS";

        /// <summary>
        /// 权限代码已经存在
        /// </summary>
        public const string AuthorityCodeExist = "FUNCTIONCODE_EXISTS";

        /// <summary>
        /// 参数名称已经存在
        /// </summary>
        public const string ParameterNameExist = "PARAMETRCODE_EXISTS";

        /// <summary>
        /// 数据字典编码已存在
        /// </summary>
        public const string DictionaryCodeExist = "DICTIONARYCODE_EXISTS";

        /// <summary>
        /// 用户组名称已经存在
        /// </summary>
        public const string UserGroupNameExist = "GROUPCODE_EXISTS";

        /// <summary>
        /// 用户已经存在于该用户组
        /// </summary>
        public const string UserHasBeenAddedInGroup = "GROUP_HAS_USER";

        /// <summary>
        /// 登录的用户账户被禁用
        /// </summary>
        public const string UserAccountDisabled = "USER_DISABLED";

        /// <summary>
        /// 应用程序代码已经存在
        /// </summary>
        public const string ApplicationCodeExist = "APPLICATION_EXISTS";

        /// <summary>
        /// 应用程序不存在
        /// </summary>
        public const string ApplicationNotExist = "APPLICATION_NOTFOUND";
    }
}