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
using System.Diagnostics;

namespace Modules.RoleModule.Views
{
    [SmartPart]
    public partial class RoleForm : TreeListForm
    {
        /// <summary>
        /// 全部数据字典缓存
        /// </summary>
        private List<Role> DataCache { get; set; }

        public RoleForm ()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            base.InitForm();

            this.TreeListName = "所有角色组";
            this.TreeListFieldName = "RoleName";

            InitAllUser();
            InitAllGroup();
            InitAllFunction();
        }

        public override void InitButtonAuthority()
        {
            btnInsert.Tag = "ROLE_INSERT";
            btnUpdate.Tag = "ROLE_EDIT";
            btnDelete.Tag = "ROLE_DELETE";
        }

        private Role GetRolenById(int RoleId)
        {
            foreach (var item in DataCache)
                if (item.RoleId == RoleId)
                    return item;

            return null;
        }

        public override void LoadData()
        {
            Query query = new Query();
            query.Criteria.Add(new Criterion("RoleId", CriteriaOperator.GreaterThan, 0));
            query.OrderClauses.Add(new OrderClause("RoleName", OrderClause.OrderClauseCriteria.Ascending));
            List<Role> list = ServiceHelper.ApplicationService.GetRoleByQuery(query);
            DataCache = list;

            // add DataDictionary nodes
            foreach (Role role in list)
            {
                string value = role.RoleName;
                int id = role.RoleId;

                TreeListNode newNode = DataTree.AppendNode(new object[] { value }, null, role);
                newNode.HasChildren = false;
            }
        }

        private void InitAllUser()
        {
            lbRoleUser.Items.Clear();
            lbRoleUser.ValueMember = "UserId";
            lbRoleUser.DisplayMember = "UserName";
            List<User> users = ServiceHelper.ApplicationService.GetAllUser();
            lbRoleUser.DataSource = users;
        }

        private void InitAllGroup()
        {
            Query query = new Query();
            query.Criteria.Add(new Criterion("GroupId", CriteriaOperator.GreaterThan, 0));
            query.OrderClauses.Add(new OrderClause("GroupLevel", OrderClause.OrderClauseCriteria.Ascending));
            query.OrderClauses.Add(new OrderClause("GroupCode", OrderClause.OrderClauseCriteria.Ascending));
            List<Group> list = ServiceHelper.ApplicationService.GetGroupByQuery(query);

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
                    FindGroupTreeNode(tlGroup.Nodes, parentID, ref parentNode);
                    if (parentNode != null)
                    {
                        TreeListNode newNode = tlGroup.AppendNode(new object[] { value }, parentNode, group);
                    }
                }
                else
                {
                    TreeListNode newNode = tlGroup.AppendNode(new object[] { value }, null, group);
                    newNode.HasChildren = true;
                }
            }

            tlGroup.ExpandAll();
        }

        private void InitAllFunction()
        {
            Query query = new Query();
            query.Criteria.Add(new Criterion("FunctionId", CriteriaOperator.GreaterThan, 0));
            query.OrderClauses.Add(new OrderClause("FunctionLevel", OrderClause.OrderClauseCriteria.Ascending));
            query.OrderClauses.Add(new OrderClause("FunctionCode", OrderClause.OrderClauseCriteria.Ascending));
            List<Function> list = ServiceHelper.ApplicationService.GetFunctionByQuery(query);

            // add DataDictionary nodes
            foreach (Function function in list)
            {
                int level = function.FunctionLevel;
                string value = function.FunctionName;
                int id = function.FunctionId;
                int parentID = function.ParentId;
                TreeListNode parentNode = null;
                if (level != 1)
                {
                    FindFunctionTreeNode(tlFunction.Nodes, parentID, ref parentNode);
                    if (parentNode != null)
                    {
                        TreeListNode newNode = tlFunction.AppendNode(new object[] { value }, parentNode, function);
                    }
                }
                else
                {
                    TreeListNode newNode = tlFunction.AppendNode(new object[] { value }, null, function);
                    newNode.HasChildren = true;
                }
            }

            tlFunction.ExpandAll();
        }

        private void InitRoleUser(int RoleId)
        {
            lbRoleUser.UnCheckAll();

            List<User> users = ServiceHelper.ApplicationService.GetRoleUsers(RoleId);
            for (int i = 0; i <= lbRoleUser.ItemCount - 1; i ++ )
            {
                var item = lbRoleUser.GetItem(i);
                foreach (var user in users)
                {
                    if (((User)item).UserId == user.UserId)
                    {
                        lbRoleUser.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void InitRoleGroup(int RoleId)
        {
            tlGroup.UncheckAll();

            List<Group> groups = ServiceHelper.ApplicationService.GetRoleGroups(RoleId);
            foreach (var group in groups) 
            {
                for (int i = 0; i <= tlGroup.Nodes.Count - 1; i++)
                {
                    CheckGroupNode(tlGroup.Nodes[i], group.GroupId);
                }

            }
        }

        private void CheckGroupNode(TreeListNode parentNode, int groupId)
        {
            Group nodeGroup = parentNode.Tag as Group;
            if (nodeGroup.GroupId == groupId)
            {
                parentNode.Checked = true;
            }

            if (parentNode.HasChildren)
            {
                for (int i = 0; i <= parentNode.Nodes.Count - 1; i++)
                {
                    CheckGroupNode(parentNode.Nodes[i], groupId);
                }
            }
        }

        private void CheckFunctionNode(TreeListNode parentNode, int functionId)
        {
            Function nodeFunction = parentNode.Tag as Function;
            if (nodeFunction.FunctionId == functionId)
            {
                parentNode.Checked = true;
            }

            if (parentNode.HasChildren)
            {
                for (int i = 0; i <= parentNode.Nodes.Count - 1; i++)
                {
                    CheckFunctionNode(parentNode.Nodes[i], functionId);
                }
            }
        }

        private void InitRoleFunction(int RoleId)
        {
            tlFunction.UncheckAll();

            List<Function> functions = ServiceHelper.ApplicationService.GetRoleFunctions(RoleId);
            foreach (var function in functions)
            {
                for (int i = 0; i <= tlFunction.Nodes.Count - 1; i++)
                {
                    CheckFunctionNode(tlFunction.Nodes[i], function.FunctionId);
                }
            }
        }

        private TreeListNode FindTreeNode(int RoleId)
        {
            foreach (TreeListNode node in DataTree.Nodes)
            {
                if (node.Tag != null)
                    if (((Role)node.Tag).RoleId == RoleId)
                        return node;
            }

            return null;
        }

        private void FindGroupTreeNode(TreeListNodes nodes, int groupId, ref TreeListNode findedNode)
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
                        FindGroupTreeNode(node.Nodes, groupId, ref findedNode);
                    }
                }
        }

        private void FindFunctionTreeNode(TreeListNodes nodes, int functionId, ref TreeListNode findedNode)
        {
            if (findedNode == null)
                foreach (TreeListNode node in nodes)
                {
                    Function function = node.Tag as Function;
                    if (function.FunctionId == functionId)
                    {
                        findedNode = node;
                        return;
                    }

                    if (node.HasChildren)
                    {
                        FindFunctionTreeNode(node.Nodes, functionId, ref findedNode);
                    }
                }
        }

        public override void ClearFormData()
        {
            txtRoleCode.Text = string.Empty;
            txtRoleName.Text = string.Empty;
            txtRemark.Text = string.Empty;
            cbIsActive.SelectedIndex = 0;
        }

        public override void SetInputStatus(bool isReadOnly)
        {
            txtRoleCode.Properties.ReadOnly = isReadOnly;
            txtRoleName.Properties.ReadOnly = isReadOnly;
            txtRemark.Properties.ReadOnly = isReadOnly;
            cbIsActive.Properties.ReadOnly = isReadOnly;

            switch (CurrentDataState)
            {
                case DataState.Read:
                case DataState.Create:
                    {
                        lbRoleUser.Enabled = false;
                        tlGroup.Enabled = false;
                        tlFunction.Enabled = false;
                        break;
                    }
                case DataState.Update:
                    {
                        lbRoleUser.Enabled = true;
                        tlGroup.Enabled = true;
                        tlFunction.Enabled = true;
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

            Role role = currentNode.Tag as Role;
            if (role != null)
            {
                txtRoleCode.Text = role.RoleCode;
                txtRoleName.Text = role.RoleName;
                txtRemark.Text = role.Remark;

                if (role.IsActive)
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

            Role role = currentNode.Tag as Role;
            if (role != null)
            {
                bool deleteResult = ServiceHelper.ApplicationService.DeleteRole(role.RoleId);

                if (deleteResult)
                {
                    DataTree.DeleteNode(currentNode);
                    //FormHelper.ShowInformationDialog("成功删除角色。");
                }
                else
                {
                    FormHelper.ShowWarningDialog("删除角色失败。");
                }
            }
        }

        public override void SaveData()
        {
            Role role;
            
            if (ValidateData())
            {
                if (CurrentDataState == DataState.Create)
                {
                    TreeListNode parentNode = DataTree.FocusedNode;
                    role = new Role();
                    if (parentNode == null)
                    {
                        role.ApplicationId = GlobalState.CurrentApplication.ApplicationId;
                        role.RoleCode = txtRoleCode.Text.Trim();
                        role.RoleName = txtRoleName.Text.Trim();
                        role.Remark = txtRemark.Text.Trim();
                        role.IsActive = cbIsActive.SelectedIndex == 0;
                    }

                    try
                    {
                        role.RoleId = ServiceHelper.ApplicationService.CreateRole(role);
                        
                        // add new node
                        TreeListNode newNode = DataTree.AppendNode(new object[] { role.RoleName }, parentNode, role);
                        if (parentNode != null)
                            parentNode.ExpandAll();

                        CurrentDataState = DataState.Read;
                        SetButtonStatus();
                        SetInputStatus(true);
                    }
                    catch (FaultException<ServiceError> sex)
                    {
                        if (sex.Detail != null)
                            FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                        return;
                    }
                    catch (Exception ex)
                    {
                        FormHelper.ShowErrorDialog("创建角色信息失败。");
                        throw ex;
                    }
                }

                if (CurrentDataState == DataState.Update)
                {
                    TreeListNode currentNode = DataTree.FocusedNode;
                    role = currentNode.Tag as Role;
                    if (role != null)
                    {
                        role.RoleCode = txtRoleCode.Text.Trim();
                        role.RoleName = txtRoleName.Text.Trim();
                        role.Remark = txtRemark.Text.Trim();
                        role.IsActive = cbIsActive.SelectedIndex == 0;
                    }

                    try
                    {
                        bool updateResult = ServiceHelper.ApplicationService.UpdateRole(role);

                        if (updateResult)
                        {
                            Role newRole = ServiceHelper.ApplicationService.GetRoleByCode(GlobalState.CurrentApplication.ApplicationCode, role.RoleCode);
                            currentNode.Tag = newRole;
                            currentNode.SetValue(NodeValueColumn, newRole.RoleName);
                        }

                        CurrentDataState = DataState.Read;
                        SetButtonStatus();
                        SetInputStatus(true);
                    }
                    catch (FaultException<ServiceError> sex)
                    {
                        if (sex.Detail != null)
                            FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                        return;
                    }
                    catch (Exception ex)
                    {
                        FormHelper.ShowErrorDialog("更新角色信息失败。");
                        throw ex;
                    }
                }
            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();

            bool result = true;

            if (txtRoleCode.Text.Trim() == "")
            {
                string tipa = "请填写角色代码。";
                Validator.SetError(txtRoleCode, tipa);
                result = false;
            }

            if (txtRoleName.Text.Trim() == "")
            {
                string tipa = "请填写角色名称。";
                Validator.SetError(txtRoleName, tipa);
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
                Role role = currentNode.Tag as Role;
                if (role != null)
                {
                    txtRoleCode.Text = role.RoleCode;
                    txtRoleName.Text = role.RoleName;
                    txtRemark.Text = role.Remark;

                    if (role.IsActive)
                        cbIsActive.SelectedIndex = 0;
                    else
                        cbIsActive.SelectedIndex = 1;
                }

                try
                {
                    InitRoleUser(role.RoleId);
                    InitRoleGroup(role.RoleId);
                    InitRoleFunction(role.RoleId);
                }
                catch (FaultException<ServiceError> sex)
                {
                    if (sex.Detail != null)
                        FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                    return;
                }
                catch (Exception ex)
                {
                    FormHelper.ShowErrorDialog("获取角色相关信息失败。");
                    throw ex;
                }
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
                Role role = currentNode.Tag as Role;
                if (role != null)
                {
                    btnInsert.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = false;
                }
            }
        }

        private void lbRoleUser_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            TreeListNode currentNode = DataTree.FocusedNode;
            Role role = currentNode.Tag as Role;
            if (role == null) return;

            int index = e.Index;
            CheckState state = e.State;

            try
            {
                var item = lbRoleUser.GetItem(index);
                if (item != null)
                {
                    if (state == CheckState.Checked)
                        ServiceHelper.ApplicationService.AddRoleUser(role.RoleId, ((User)item).UserId);
                    else
                        ServiceHelper.ApplicationService.RemoveRoleUser(role.RoleId, ((User)item).UserId);
                }
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                return;
            }
            catch (Exception ex)
            {
                FormHelper.ShowErrorDialog("更新角色用户信息失败。");
                throw ex;
            }

        }

        private void tlGroup_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            TreeListNode roleNode = DataTree.FocusedNode;
            Role role = roleNode.Tag as Role;
            if (role == null) return;

            TreeListNode groupNode = e.Node;
            Group group = groupNode.Tag as Group;
            if (group == null) return;

            try
            {
                if (groupNode.Checked)
                {
                    ServiceHelper.ApplicationService.AddRoleGroup(role.RoleId, group.GroupId);
                }
                else
                {
                    ServiceHelper.ApplicationService.RemoveRoleGroup(role.RoleId, group.GroupId);
                }
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                return;
            }
            catch (Exception ex)
            {
                FormHelper.ShowErrorDialog("更新角色用户组信息失败。");
                throw ex;
            }
        }

        private void tlFunction_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            TreeListNode roleNode = DataTree.FocusedNode;
            Role role = roleNode.Tag as Role;
            if (role == null) return;

            TreeListNode groupNode = e.Node;
            Function function = groupNode.Tag as Function;
            if (function == null) return;

            try
            {
                if (groupNode.Checked)
                {
                    ServiceHelper.ApplicationService.AddRoleFunction(role.RoleId, function.FunctionId);
                }
                else
                {
                    ServiceHelper.ApplicationService.RemoveRoleFunction(role.RoleId, function.FunctionId);
                }
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                return;
            }
            catch (Exception ex)
            {
                FormHelper.ShowErrorDialog("更新角色功能信息失败。");
                throw ex;
            }

        }
    }
}
