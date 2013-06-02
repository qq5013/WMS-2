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

namespace Modules.FunctionModule.Views
{
    [SmartPart]
    public partial class FunctionForm : TreeListForm
    {
        /// <summary>
        /// 全部数据字典缓存
        /// </summary>
        private List<Function> DataCache { get; set; }

        public FunctionForm ()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            base.InitForm();

            this.TreeListName = "所有功能";
            this.TreeListFieldName = "FunctionName";
        }

        public override void InitButtonAuthority()
        {
            btnInsert.Tag = "FUNCTION_INSERT";
            btnUpdate.Tag = "FUNCTION_EDIT";
            btnDelete.Tag = "FUNCTION_DELETE";
        }

        private Function GetFunctionById(int functionId)
        {
            foreach (var item in DataCache)
                if (item.FunctionId == functionId)
                    return item;

            return null;
        }

        public override void LoadData()
        {
            Query query = new Query();
            query.Criteria.Add(new Criterion("FunctionId", CriteriaOperator.GreaterThan, 0));
            query.OrderClauses.Add(new OrderClause("FunctionLevel", OrderClause.OrderClauseCriteria.Ascending));
            query.OrderClauses.Add(new OrderClause("FunctionCode", OrderClause.OrderClauseCriteria.Ascending));
            List<Function> list = ServiceHelper.ApplicationService.GetFunctionByQuery(query);
            DataCache = list;

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
                    FindTreeNode(DataTree.Nodes, parentID, ref parentNode);
                    if (parentNode != null)
                    {
                        TreeListNode newNode = DataTree.AppendNode(new object[] { value }, parentNode, function);
                    }
                }
                else
                {
                    TreeListNode newNode = DataTree.AppendNode(new object[] { value }, null, function);
                    newNode.HasChildren = true;
                }
            }
        }

        private void FindTreeNode(TreeListNodes nodes, int functionId, ref TreeListNode findedNode)
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
                        FindTreeNode(node.Nodes, functionId, ref findedNode);
                    }
                }
        }

        public override void ClearFormData()
        {
            txtFunctionLevel.Text = string.Empty;
            txtParentID.Text = string.Empty;
            txtFunctionCode.Text = string.Empty;
            txtFunctionName.Text = string.Empty;
            txtResourceIdentifier.Text = string.Empty;
            txtRemark.Text = string.Empty;
            cbIsActive.SelectedIndex = 0;
        }

        public override void SetInputStatus(bool isReadOnly)
        {
            txtFunctionLevel.Properties.ReadOnly = true;
            txtParentID.Properties.ReadOnly = true;
            txtFunctionCode.Properties.ReadOnly = isReadOnly;
            txtFunctionName.Properties.ReadOnly = isReadOnly;
            txtResourceIdentifier.Properties.ReadOnly = isReadOnly;
            txtRemark.Properties.ReadOnly = isReadOnly;
            cbIsActive.Properties.ReadOnly = isReadOnly;
        }

        public override void CreateData()
        {
            ClearFormData();
            SetInputStatus(false);

            CurrentDataState = DataState.Create;
            SetButtonStatus();
        }

        public override void UpdateData()
        {
            TreeListNode currentNode = DataTree.FocusedNode;
            if (currentNode ==null || currentNode.Tag == null) return;

            Function function = currentNode.Tag as Function;
            if (function != null)
            {
                txtFunctionLevel.Text = function.FunctionLevel.ToString();
                Function parentDictionary = GetFunctionById(function.ParentId);
                if (parentDictionary != null)
                    txtParentID.Text = parentDictionary.FunctionName;
                else
                    txtParentID.Text = string.Empty;
                txtFunctionCode.Text = function.FunctionCode;
                txtFunctionName.Text = function.FunctionName;
                txtResourceIdentifier.Text = function.ResourceIdentifier;
                txtRemark.Text = function.Remark;

                if (function.IsActive)
                    cbIsActive.SelectedIndex = 0;
                else
                    cbIsActive.SelectedIndex = 1;
            }

            SetInputStatus(false);

            CurrentDataState = DataState.Update;
            SetButtonStatus();
        }

        public override void DeleteData()
        {
            TreeListNode currentNode = DataTree.FocusedNode;
            if (currentNode ==null || currentNode.Tag == null) return;

            Function function = currentNode.Tag as Function;
            if (function != null)
            {
                bool deleteResult = ServiceHelper.ApplicationService.DeleteFunction(function.FunctionId);

                if (deleteResult)
                {
                    DataTree.DeleteNode(currentNode);
                    //FormHelper.ShowInformationDialog("成功删除功能。");
                }
                else
                {
                    FormHelper.ShowWarningDialog("删除功能失败。");
                }
            }
        }

        public override void SaveData()
        {
            Function function;
            
            if (ValidateData())
            {
                if (CurrentDataState == DataState.Create)
                {
                    TreeListNode parentNode = DataTree.FocusedNode;
                    function = new Function();
                    if (parentNode == null)
                    {
                        function.ApplicationId = GlobalState.CurrentApplication.ApplicationId;
                        function.FunctionLevel = 1;
                        function.ParentId = 0;
                        function.FunctionCode = txtFunctionCode.Text.Trim();
                        function.FunctionName = txtFunctionName.Text.Trim();
                        function.ResourceIdentifier = txtResourceIdentifier.Text.Trim();
                        function.Remark = txtRemark.Text.Trim();
                        function.IsActive = cbIsActive.SelectedIndex == 0;
                    }
                    else
                    {
                        Function parentFunction = parentNode.Tag as Function;
                        if (parentFunction != null)
                        {
                            function.ApplicationId = parentFunction.ApplicationId;
                            function.FunctionLevel = parentFunction.FunctionLevel + 1;
                            function.ParentId = parentFunction.FunctionId;
                            function.FunctionCode = txtFunctionCode.Text.Trim();
                            function.FunctionName = txtFunctionName.Text.Trim();
                            function.ResourceIdentifier = txtResourceIdentifier.Text.Trim();
                            function.Remark = txtRemark.Text.Trim();
                            function.IsActive = cbIsActive.SelectedIndex == 0;
                        }
                    }

                    try
                    {
                        function.FunctionId = ServiceHelper.ApplicationService.CreateFunction(function);
                        
                        // add new node
                        TreeListNode newNode = DataTree.AppendNode(new object[] { function.FunctionName }, parentNode, function);
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
                        FormHelper.ShowErrorDialog("创建功能信息失败。");
                        throw ex;
                    }
                }

                if (CurrentDataState == DataState.Update)
                {
                    TreeListNode currentNode = DataTree.FocusedNode;
                    function = currentNode.Tag as Function;
                    if (function != null)
                    {
                        function.FunctionCode = txtFunctionCode.Text.Trim();
                        function.FunctionName = txtFunctionName.Text.Trim();
                        function.ResourceIdentifier = txtResourceIdentifier.Text.Trim();
                        function.Remark = txtRemark.Text.Trim();
                        function.IsActive = cbIsActive.SelectedIndex == 0;
                    }

                    try
                    {
                        bool updateResult = ServiceHelper.ApplicationService.UpdateFunction(function);

                        if (updateResult)
                        {
                            Function newFunction = ServiceHelper.ApplicationService.GetFunctionByCode(GlobalState.CurrentApplication.ApplicationCode, function.FunctionCode);
                            currentNode.Tag = newFunction;
                            currentNode.SetValue(NodeValueColumn, function.FunctionName);
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
                        FormHelper.ShowErrorDialog("更新功能信息失败。");
                        throw ex;
                    }
                }
            }
        }

        private bool ValidateData()
        {
            Validator.Clear();

            bool result = true;

            if (txtFunctionCode.Text.Trim() == "")
            {
                string tipa = "请填写功能代码。";
                Validator.SetError(txtFunctionCode, tipa);
                result = false;
            }

            if (txtFunctionName.Text.Trim() == "")
            {
                string tipa = "请填写功能名称。";
                Validator.SetError(txtFunctionName, tipa);
                result = false;
            }

            if (txtResourceIdentifier.Text.Trim() == "")
            {
                string tipa = "请填写资源标示符。";
                Validator.SetError(txtResourceIdentifier, tipa);
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
                Function function = currentNode.Tag as Function;
                if (function != null)
                {
                    txtFunctionLevel.Text = function.FunctionLevel.ToString();
                    Function parentFunction = GetFunctionById(function.ParentId);
                    if (parentFunction != null)
                        txtParentID.Text = parentFunction.FunctionName;
                    else
                        txtParentID.Text = string.Empty;
                    txtFunctionCode.Text = function.FunctionCode;
                    txtFunctionName.Text = function.FunctionName;
                    txtResourceIdentifier.Text = function.ResourceIdentifier;
                    txtRemark.Text = function.Remark;

                    if (function.IsActive)
                        cbIsActive.SelectedIndex = 0;
                    else
                        cbIsActive.SelectedIndex = 1;
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
                Function function = currentNode.Tag as Function;
                if (function != null)
                {
                    if (function.FunctionLevel == 1 || function.FunctionLevel == 2)
                    {
                        btnInsert.Enabled = true;
                    }
                    else
                    {
                        btnInsert.Enabled = false;
                    }

                    if (!currentNode.HasChildren || function.FunctionLevel == 3)
                        btnDelete.Enabled = true;
                    else
                        btnDelete.Enabled = false;

                    btnUpdate.Enabled = true;
                    btnSave.Enabled = false;
                }
            }
        }
    }
}
