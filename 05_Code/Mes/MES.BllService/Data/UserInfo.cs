/*----------------------------------------------------------------
// Copyright (C) 2010 ���޹�˾
// ��Ȩ���С� 
//
// �ļ�����         UserInfo.cs
// �ļ�����������   �û���Ϣ
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
using MES.Entity;

namespace MES.BllService.Data
{
    /// <summary>
    ///     �û���Ϣ
    /// </summary>
    public class UserInfo
    {
        private readonly List<Permission> _authorities = new List<Permission>();
        private readonly List<Role> _roles = new List<Role>();
        private User _user;

        /// <summary>
        ///     ����
        /// </summary>
        public string Name
        {
            get { return User.Name; }
        }

        /// <summary>
        ///     �û�Id
        /// </summary>
        public int UserId
        {
            get { return User.UserId; }
        }

        /// <summary>
        ///     ��¼��
        /// </summary>
        public string LogInName
        {
            get { return User.LogInName; }
        }

        /// <summary>
        ///     ����
        /// </summary>
        public string Password
        {
            get { return User.Password; }
        }

        /// <summary>
        ///     ����ʱ��
        /// </summary>
        public DateTime CreateTime
        {
            get { return User.CreateTime; }
        }

        /// <summary>
        ///     �ϴε�¼ʱ��
        /// </summary>
        public DateTime LastLoggingTime
        {
            get { return User.LastLoggingTime; }
        }

        /// <summary>
        ///     �Ƿ���Ч
        /// </summary>
        public bool IsDeactivated
        {
            get { return User.IsDeactivated; }
        }

        /// <summary>
        ///     ����
        /// </summary>
        public string Description
        {
            get { return User.Description; }
        }

        /// <summary>
        ///     �û�
        /// </summary>
        public User User
        {
            get { return _user ?? new User(); }
            set { _user = value; }
        }

        /// <summary>
        ///     ��ɫ
        /// </summary>
        public List<Role> Roles
        {
            get { return _roles; }
        }

        /// <summary>
        ///     Ȩ��
        /// </summary>
        public List<Permission> Authorities
        {
            get { return _authorities; }
        }
    }
}