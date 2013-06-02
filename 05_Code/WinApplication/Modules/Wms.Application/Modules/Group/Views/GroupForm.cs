using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Framework.UI.Template.Others;
using Microsoft.Practices.CompositeUI.SmartParts;
using DevExpress.XtraTreeList.Nodes;
using Business.Common.QueryModel;
using Business.Domain.Application;
using Framework.UI.Template.Common;
using Wms.Common;
using Business.Common.Exception;
using System.ServiceModel;

namespace Modules.GroupModule.Views
{
    [SmartPart]
    public partial class GroupForm : TreeListForm
    {
        /// <summary>
        /// 全部数据字典缓存
        /// </summary>
        private List<Group> DataCache { get; set; }

        public GroupForm ()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            base.InitForm();

            this.TreeListName = "所有用户组";
            this.TreeListFieldName = "GroupName";

            InitAllUser();
        }

        public override void InitButtonAuthority()
        {
            btnInsert.Tag = "GROUP_INSERT";
            btnUpdate.Tag = "GROUP_EDIT";
            btnDelete.Tag = "GROUP_DELETE";
        }

        private Group GetGroupnById(int groupId)
        {
            foreach (var item in DataCache)
                if (item.GroupId == groupId)
                    return item;

            return null;
        }

        public override void LoadData()
        {
            Query query = new Query();
            query.Criteria.Add(new Criterion("GroupId", CriteriaOperator.GreaterThan, 0));
            query.OrderClauses.Add(new OrderClause("GroupLevel", OrderClause.OrderClauseCriteria.Ascending));
            query.OrderClauses.Add(new OrderClause("GroupCode", OrderClause.OrderClauseCriteria.Ascending));
            List<Group> list = ServiceHelper.ApplicationService.GetGroupByQuery(query);
            DataCache = list;

            // add DataDictionary nodes
            foreach (Group group in list)
            {
                int level = group.GroupLevel;
                string value = group.GroupName;
                int id = group.GroupId;
                int parentID = group.ParentId;
                TreeListNode parentNode = null;
                if (level != 1)
                {
                    FindTreeNode(DataTree.Nodes, parentID, ref parentNode);
                    if (parentNode != null)
                    {
                        TreeListNode newNode = DataTree.AppendNode(new object[] { value }, parentNode, group);
                    }
                }
                else
                {
                    TreeListNode newNode = DataTree.AppendNode(new object[] { value }, null, group);
                    newNode.HasChildren = true;
                }
            }
        }

        private void InitAllUser()
        {
            lbGroupUser.Items.Clear();
            lbGroupUser.ValueMember = "UserId";
            lbGroupUser.DisplayMember = "UserName";
            List<User> users = ServiceHelper.ApplicationService.GetAllUser();
            lbGroupUser.DataSource = users;
        }

        private void InitGroupUser(int groupId)
        {
            for (int i = 0; i <= lbGroupUser.ItemCount - 1; i++)
            {
                lbGroupUser.SetItemChecked(i, false);
            }

            List<User> users = ServiceHelper.ApplicationService.GetGroupUsers(groupId);
            for (int i = 0; i <= lbGroupUser.ItemCount - 1; i ++ )
            {
                var item = lbGroupUser.GetItem(i);
                foreach (var user in users)
                {
                    if (((User)item).UserId == user.UserId)
                    {
                        lbGroupUser.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void FindTreeNode(TreeListNodes nodes, int groupId, ref TreeListNode findedNode)
        {
            if (findedNode == null)
                foreach (TreeListNode node in nodes)
                {
                    Group group = node.Tag as Group;
                    if (group.GroupId == groupId)
                    {
                        findedNode = node;
                        return;
                    }

                    if (node.HasChildren)
                    {
                        FindTreeNode(node.Nodes, groupId, ref findedNode);
                    }
                }
        }

        public override void ClearFormData()
        {
            txtGroupLevel.Text = string.Empty;
            txtParentID.Text = string.Empty;
            txtGroupCode.Text = string.Empty;
            txtGroupName.Text = string.Empty;
            txtRemark.Text = string.Empty;
            cbIsActive.SelectedIndex = 0;
        }

        public override void SetInputStatus(bool isReadOnly)
        {
            txtGroupLevel.Properties.ReadOnly = true;
            txtParentID.Properties.ReadOnly = true;
            txtGroupCode.Properties.ReadOnly = isReadOnly;
            txtGroupName.Properties.ReadOnly = isReadOnly;
            txtRemark.Properties.ReadOnly = isReadOnly;
            cbIsActive.Properties.ReadOnly = isReadOnly;

            switch (CurrentDataState)
            {
                case DataState.Read:
                case DataState.Create:
                    {
                        lbGroupUser.Enabled = false;
                        break;
                    }
                case DataState.Update:
                    {
                        lbGroupUser.Enabled = true;
                        break;
                    }
            }
        }

        public override void CreateData()
        {
            ClearFormData();
            CurrentDataState = DataState.Create;
            SetInputStatus(false);
            SetButtonStatus();
        }

        public override void UpdateData()
        {
            TreeListNode currentNode = DataTree.FocusedNode;
            if (currentNode ==null || currentNode.Tag == null) return;

            Group group = currentNode.Tag as Group;
            if (group != null)
            {
                txtGroupLevel.Text = group.GroupLevel.ToString();
                Group parentDictionary = GetGroupnById(group.ParentId);
                if (parentDictionary != null)
                    txtParentID.Text = parentDictionary.GroupName;
                else
                    txtParentID.Text = string.Empty;
                txtGroupCode.Text = group.GroupCode;
                txtGroupName.Text = group.GroupName;
                txtRemark.Text = group.Remark;

                if (group.IsActive)
                    cbIsActive.SelectedIndex = 0;
                else
                    cbIsActive.SelectedIndex = 1;
            }

            CurrentDataState = DataState.Update;
            SetInputStatus(false);
            SetButtonStatus();
        }

        public override void DeleteData()
        {
            TreeListNode currentNode = DataTree.FocusedNode;
            if (currentNode ==null || currentNode.Tag == null) return;

            Group group = currentNode.Tag as Group;
            if (group != null)
            {
                bool deleteResult = ServiceHelper.ApplicationService.DeleteGroup(group.GroupId);

                if (deleteResult)
                {
                    DataTree.DeleteNode(currentNode);
                    //FormHelper.ShowInformationDialog("成功删除用户组。");
                }
                else
                {
                    FormHelper.ShowWarningDialog("删除用户组失败。");
                }
            }
        }

        public override void SaveData()
        {
            Group group;
            
            if (ValidateData())
            {
                if (CurrentDataState == DataState.Create)
                {
                    TreeListNode parentNode = DataTree.FocusedNode;
                    group = new Group();
                    if (parentNode == null)
                    {
                        group.ApplicationId = GlobalState.CurrentApplication.ApplicationId;
                        group.GroupLevel = 1;
                        group.ParentId = 0;
                        group.GroupCode = txtGroupCode.Text.Trim();
                        group.GroupName = txtGroupName.Text.Trim();
                        group.Remark = txtRemark.Text.Trim();
                        group.IsActive = cbIsActive.SelectedIndex == 0;
                    }
                    else
                    {
                        Group parentFunction = parentNode.Tag as Group;
                        if (parentFunction != null)
                        {
                            group.ApplicationId = parentFunction.ApplicationId;
                            group.GroupLevel = parentFunction.GroupLevel + 1;
                            group.ParentId = parentFunction.GroupId;
                            group.GroupCode = txtGroupCode.Text.Trim();
                            group.GroupName = txtGroupName.Text.Trim();
                            group.Remark = txtRemark.Text.Trim();
                            group.IsActive = cbIsActive.SelectedIndex == 0;
                        }
                    }

                    try
                    {
                        group.GroupId = ServiceHelper.ApplicationService.CreateGroup(group);
                        
                        // add new node
                        TreeListNode newNode = DataTree.AppendNode(new object[] { group.GroupName }, parentNode, group);
                        if (parentNode != null)
                            parentNode.ExpandAll();

                        CurrentDataState = DataState.Read;
                        SetButtonStatus();
                        SetInputStatus(true);

                        tlData.FocusedNode = null;
                        tlData.FocusedNode = newNode;
                    }
                    catch (FaultException<ServiceError> sex)
                    {
                        if (sex.Detail != null)
                            FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                        return;
                    }
                    catch (Exception ex)
                    {
                        FormHelper.ShowErrorDialog("创建用户组信息失败。");
                        throw ex;
                    }
                }

                if (CurrentDataState == DataState.Update)
                {
                    TreeListNode currentNode = DataTree.FocusedNode;
                    group = currentNode.Tag as Group;
                    if (group != null)
                    {
                        group.GroupCode = txtGroupCode.Text.Trim();
                        group.GroupName = txtGroupName.Text.Trim();
                        group.Remark = txtRemark.Text.Trim();
                        group.IsActive = cbIsActive.SelectedIndex == 0;
                    }

                    try
                    {
                        bool updateResult = ServiceHelper.ApplicationService.UpdateGroup(group);

                        if (updateResult)
                        {
                            Group newGroup = ServiceHelper.ApplicationService.GetGroupByCode(GlobalState.CurrentApplication.ApplicationCode, group.GroupCode);
                            currentNode.Tag = newGroup;
                            currentNode.SetValue(NodeValueColumn, newGroup.GroupName);
                        }

                        CurrentDataState = DataState.Read;
                        SetButtonStatus();
                        SetInputStatus(true);

                        tlData.FocusedNode = null;
                        tlData.FocusedNode = currentNode;
                    }
                    catch (FaultException<ServiceError> sex)
                    {
                        if (sex.Detail != null)
                            FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                        return;
                    }
                    catch (Exception ex)
                    {
                        FormHelper.ShowErrorDialog("更新用户组信息失败。");
                        throw ex;
                    }
                }
            }
        }

        private bool ValidateData()
        {
            Validator.Clear();

            bool result = true;

            if (txtGroupCode.Text.Trim() == "")
            {
                string tipa = "请填写用户组代码。";
                Validator.SetError(txtGroupCode, tipa);
                result = false;
            }

            if (txtGroupName.Text.Trim() == "")
            {
                string tipa = "请填写用户组名称。";
                Validator.SetError(txtGroupName, tipa);
                result = false;
            }

            if (cbIsActive.SelectedIndex == -1)
            {
                string tipa = "请选择是否可用。";
                Validator.SetError(cbIsActive, tipa);
                result = false;
            }

            return result;
        }

        public override void ReloadData()
        {
            TreeListNode currentNode = DataTree.FocusedNode;

            if (currentNode != null && currentNode.Tag != null)
            {
                Group group = currentNode.Tag as Group;
                if (group != null)
                {
                    txtGroupLevel.Text = group.GroupLevel.ToString();
                    Group parentGroup = GetGroupnById(group.ParentId);
                    if (parentGroup != null)
                        txtParentID.Text = parentGroup.GroupName;
                    else
                        txtParentID.Text = string.Empty;
                    txtGroupCode.Text = group.GroupCode;
                    txtGroupName.Text = group.GroupName;
                    txtRemark.Text = group.Remark;

                    if (group.IsActive)
                        cbIsActive.SelectedIndex = 0;
                    else
                        cbIsActive.SelectedIndex = 1;
                }

                InitGroupUser(group.GroupId);
            }
        }

        public override void SetButtonStatus()
        {
            switch (CurrentDataState)
            {
                case DataState.Read:
                    {
                        btnInsert.Enabled = false;
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                        break;
                    }
                case DataState.Create:
                    {
                        btnInsert.Enabled = false;
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                        break;
                    }
                case DataState.Update:
                    {
                        btnInsert.Enabled = false;
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = true;
                        btnCancel.Enabled = true;
                        break;
                    }
            }
        }

        protected override void ColumnButtonClickEventHandler(object sender, EventArgs e)
        {
            DataTree.FocusedNode = null;
            ClearFormData();
            CurrentDataState = DataState.Read;
            SetButtonStatus();

            btnInsert.Enabled = true;
        }

        protected override void FocusedNodeChangedEventHandler(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            ReloadData();
            CurrentDataState = DataState.Read;

            TreeListNode currentNode = DataTree.FocusedNode;
            if (currentNode != null && currentNode.Tag != null)
            {
                Group group = currentNode.Tag as Group;
                if (group != null)
                {
                    if (group.GroupLevel == 1 || group.GroupLevel == 2)
                    {
                        btnInsert.Enabled = true;
                    }
                    else
                    {
                        btnInsert.Enabled = false;
                    }

                    if (!currentNode.HasChildren || group.GroupLevel == 3)
                        btnDelete.Enabled = true;
                    else
                        btnDelete.Enabled = false;

                    btnUpdate.Enabled = true;
                    btnSave.Enabled = false;
                }
            }
        }

        private void lbGroupUser_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            TreeListNode currentNode = DataTree.FocusedNode;
            Group group = currentNode.Tag as Group;
            if (group == null) return;

            int index = e.Index;
            CheckState state = e.State;

            var item = lbGroupUser.GetItem(index);
            if (item != null)
            {
                if (state == CheckState.Checked)
                    ServiceHelper.ApplicationService.AddGroupUser(group.GroupId, ((User)item).UserId);
                else
                    ServiceHelper.ApplicationService.RemoveGroupUser(group.GroupId, ((User)item).UserId);
            }

        }
    }
}
