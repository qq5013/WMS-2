/*----------------------------------------------------------------
// Copyright (C) 2010 ���޹�˾
// ��Ȩ���С� 
//
// �ļ�����         BaseData.cs
// �ļ�����������   ��������
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
using Frame.Utils.Contract;
using Frame.Utils.Log;
using Frame.Utils.RelaAndCondition;
using Frame.Utils.Service;

namespace MES.BllService.Data
{
    /// <summary>
    ///     ��������
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseData<T> where T : class, IBaseEntity
    {
        private const int _userId = 1;

        /// <summary>
        ///     Html��־
        /// </summary>
        public ILogger Logger = new HtmlWriter();

        /// <summary>
        ///     ����
        /// </summary>
        public IEntityService<T> Service
        {
            get { return ServiceBloker.GetService<T>(); }
        }

        /// <summary>
        ///     �û�
        /// </summary>
        public int UserId
        {
            get { return _userId; }
        }

        /// <summary>
        ///     �û�����
        /// </summary>
        /// <param name="filedName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected Exception CustomError(string filedName, string message)
        {
            //HttpContext.Current.Session["CustomErrorText"] = message;
            return new Exception(message);
        }

        /// <summary>
        ///     �û�����
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        protected Exception CustomError(Exception exception)
        {
            //HttpContext.Current.Session["CustomErrorText"] = exception.Message;
            return exception;
        }

        /// <summary>
        ///     ��ҳ��ѯ
        /// </summary>
        /// <returns></returns>
        public List<T> SelectByPage()
        {
            var serviceList = new List<T>();
            return serviceList;
        }

        /// <summary>
        ///     ��ѯ
        /// </summary>
        /// <returns></returns>
        public List<T> Select()
        {
            var queryInfo = new QueryInfo();
            List<T> list = Service.GetAll(queryInfo);
            return list;
        }

        /// <summary>
        ///     ��ѯȫ��
        /// </summary>
        /// <returns></returns>
        public List<T> SelectAll()
        {
            return Service.GetAll();
        }
    }
}