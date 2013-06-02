using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Application;
using Framework.UI.Template.Common;
using Microsoft.Practices.CompositeUI.SmartParts;
using Wms.Common;
using System.ServiceModel;
using System.Diagnostics;

namespace Modules.UserModule.Views
{
    [SmartPart]
    public partial class UserListForm : Framework.UI.Template.Single.SingleListForm
    {
        private List<Criterion> Criterions = new List<Criterion>();

        public UserListForm()
        {
            InitializeComponent();
        }

        public UserListForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            RegisterDetailForm("Modules.UserModule.Views.UserEditForm");
        }

        public override void InitButtonAuthority()
        {
            btnCopy.Tag = "USER_INSERT";
            btnInsert.Tag = "USER_INSERT";
            btnUpdate.Tag = "USER_EDIT";
            btnDelete.Tag = "USER_DELETE";
            btnSearch.Tag = "USER_QUERY";
        }

        public override void LoadData()
        {
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("User", "UserId", "*", "UserId",
                    OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, Criterions);

                int totalCount;
                DataList = ServiceHelper.ApplicationService.GetUserByPagerQuery(query, out totalCount);
                SetSplitPage(totalCount);
                BindData();
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }

        public override void CustomizeGrid()
        {
            int columnIndex = 0;

            FormHelper.SetGridColumn(MainGridView, "ApplicationId", "应用编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "UserId", "用户编号", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "UserCode", "用户代码", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "UserName", "用户名称", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Password", "口令", 150, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "CreateTime", "创建时间", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "LoginTime", "登录时间", 150, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "Remark", "描述", 200, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "IsActive", "是否可用", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, columnIndex++, false);
        }

        public override void SetQueryConditions()
        {
            Criterions.Clear();

            if (txtUserCode.Text.Trim() != "")
                Criterions.Add(new Criterion("UserCode", CriteriaOperator.Like, txtUserCode.Text.Trim() + "%"));
            if (txtUserName.Text.Trim() != "")
                Criterions.Add(new Criterion("UserName", CriteriaOperator.Like, txtUserName.Text.Trim() + "%"));

        }

        public override void DeleteData()
        {
            User user = CurrentData as User;
            if (user == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = ServiceHelper.ApplicationService.DeleteUser(user.UserId);
            }
            catch (ServiceException sex)
            {
                Console.WriteLine(sex.ToString());
            }

            if (!deleteResult)
                FormHelper.ShowInformationDialog("删除用户失败。");
        }
    }
}

