using System;
using System.Collections.Generic;
using System.Linq;
using Framework.UI.Template.Others;
using Microsoft.Practices.CompositeUI.SmartParts;
using DevExpress.XtraTreeList.Nodes;
using Business.Common.QueryModel;
using Business.Domain.Application;
using Framework.UI.Template.Common;
using Wms.Common;
using Business.Common.Exception;
using System.ServiceModel;

namespace Modules.DataDictionaryModule.Views
{
    [SmartPart]
    public partial class DataDictionaryForm : TreeListForm
    {
        /// <summary>
        /// 全部数据字典缓存
        /// </summary>
        private List<DataDictionary> _dataCache;

        public DataDictionaryForm()
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            //base.InitForm();

            TreeListName = "所有数据字典";
            TreeListFieldName = "DictionaryValue";
        }

        public override void InitButtonAuthority()
        {
            btnInsert.Tag = "DATADICTIONARY_INSERT";
            btnUpdate.Tag = "DATADICTIONARY_EDIT";
            btnDelete.Tag = "DATADICTIONARY_DELETE";
        }

        private DataDictionary GetDictionaryById(int dictionaryId)
        {
            return _dataCache.FirstOrDefault(item => item.DictionaryId == dictionaryId);
        }

        public override void LoadData()
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("DictionaryId", CriteriaOperator.GreaterThan, 0));
            query.OrderClauses.Add(new OrderClause("DictionaryLevel", OrderClause.OrderClauseCriteria.Ascending));
            query.OrderClauses.Add(new OrderClause("DictionaryCode", OrderClause.OrderClauseCriteria.Ascending));
            var list = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            _dataCache = list;

            // add DataDictionary nodes
            foreach (var dataDictionary in list)
            {
                var level = dataDictionary.DictionaryLevel;
                var value = dataDictionary.DictionaryValue;
                var parentId = dataDictionary.ParentId;
                TreeListNode parentNode = null;
                if (level != 1)
                {
                    FindTreeNode(DataTree.Nodes, parentId, ref parentNode);
                    if (parentNode != null)
                    {
                        DataTree.AppendNode(new object[] { value }, parentNode, dataDictionary);
                    }
                    else
                    {
                        FormHelper.ShowErrorDialog("确定父级节点失败。");
                        return;
                    }
                }
                else
                {
                    var newNode = DataTree.AppendNode(new object[] { value }, null, dataDictionary);
                    newNode.HasChildren = true;
                }
            }
        }

        private void FindTreeNode(TreeListNodes nodes, int dictionaryId, ref TreeListNode findedNode)
        {
            if (findedNode == null)
                foreach (TreeListNode node in nodes)
                {
                    var dictionary = node.Tag as DataDictionary;
                    if (dictionary != null)
                    {
                        if (dictionary.DictionaryId == dictionaryId)
                        {
                            findedNode = node;
                            return;
                        }
                    }

                    if (node.HasChildren)
                    {
                        FindTreeNode(node.Nodes, dictionaryId, ref findedNode);
                    }
                }
        }

        public override void ClearFormData()
        {
            txtDataDictionaryLevel.Text = string.Empty;
            txtParentID.Text = string.Empty;
            txtCategory.Text = string.Empty;
            txtDataDictionaryCode.Text = string.Empty;
            txtDictionaryValue.Text = string.Empty;
            txtRemark.Text = string.Empty;
            cbIsActive.SelectedIndex = 0;
        }

        public override void SetInputStatus(bool isReadOnly)
        {
            txtDataDictionaryLevel.Properties.ReadOnly = true;
            txtParentID.Properties.ReadOnly = true;
            txtCategory.Properties.ReadOnly = isReadOnly;
            txtDataDictionaryCode.Properties.ReadOnly = isReadOnly;
            txtDictionaryValue.Properties.ReadOnly = isReadOnly;
            txtRemark.Properties.ReadOnly = isReadOnly;
            cbIsActive.Properties.ReadOnly = isReadOnly;
        }

        public override void CreateData()
        {
            ClearFormData();
            SetInputStatus(false);

            var parentNode = DataTree.FocusedNode;
            if (parentNode != null)
            {
                var dataDictionary = DataTree.FocusedNode.Tag as DataDictionary;
                if (dataDictionary != null)
                {
                    if (dataDictionary.DictionaryLevel == 1)
                    {
                        txtCategory.Text = dataDictionary.Category;
                    }
                    else
                    {
                        txtCategory.Properties.ReadOnly = false;
                    }
                }
            }

            CurrentDataState = DataState.Create;
            SetButtonStatus();
        }

        public override void UpdateData()
        {
            var currentNode = DataTree.FocusedNode;
            if (currentNode == null || currentNode.Tag == null) return;

            var dataDictionary = currentNode.Tag as DataDictionary;
            if (dataDictionary != null)
            {
                txtDataDictionaryLevel.Text = dataDictionary.DictionaryLevel.ToString();
                var parentDictionary = GetDictionaryById(dataDictionary.ParentId);
                txtParentID.Text = parentDictionary != null ? parentDictionary.DictionaryValue : string.Empty;
                txtCategory.Text = dataDictionary.Category;
                txtDataDictionaryCode.Text = dataDictionary.DictionaryCode;
                txtDictionaryValue.Text = dataDictionary.DictionaryValue;
                txtRemark.Text = dataDictionary.Remark;

                cbIsActive.SelectedIndex = dataDictionary.IsActive ? 0 : 1;
            }

            SetInputStatus(false);

            CurrentDataState = DataState.Update;
            SetButtonStatus();
        }

        public override void DeleteData()
        {
            var currentNode = DataTree.FocusedNode;
            if (currentNode ==null || currentNode.Tag == null) return;

            var dataDictionary = currentNode.Tag as DataDictionary;
            if (dataDictionary != null)
            {
                bool deleteResult = ServiceHelper.ApplicationService.DeleteDataDictionary(dataDictionary.DictionaryId);

                if (deleteResult)
                {
                    DataTree.DeleteNode(currentNode);
                    //FormHelper.ShowInformationDialog("成功删除数据字典。");
                }
                else
                {
                    FormHelper.ShowWarningDialog("删除数据字典失败。");
                }
            }
        }

        public override void SaveData()
        {
            if (ValidateData())
            {
                DataDictionary dataDictionary;
                #region save new data
                if (CurrentDataState == DataState.Create)
                {
                    var parentNode = DataTree.FocusedNode;
                    dataDictionary = new DataDictionary();
                    if (parentNode == null)
                    {
                        dataDictionary.ApplicationId = GlobalState.CurrentApplication.ApplicationId;
                        dataDictionary.DictionaryLevel = 1;
                        dataDictionary.ParentId = 0;
                        dataDictionary.Category = txtCategory.Text.Trim();
                        dataDictionary.DictionaryCode = txtDataDictionaryCode.Text.Trim();
                        dataDictionary.DictionaryValue = txtDictionaryValue.Text.Trim();
                        dataDictionary.Remark = txtRemark.Text.Trim();
                        dataDictionary.IsActive = cbIsActive.SelectedIndex == 0;
                    }
                    else
                    {
                        var parentDataDictionary = parentNode.Tag as DataDictionary;
                        if (parentDataDictionary != null)
                        {
                            dataDictionary.ApplicationId = parentDataDictionary.ApplicationId;
                            dataDictionary.DictionaryLevel = parentDataDictionary.DictionaryLevel + 1;
                            dataDictionary.ParentId = parentDataDictionary.DictionaryId;
                            dataDictionary.Category = parentDataDictionary.Category;
                            dataDictionary.DictionaryCode = txtDataDictionaryCode.Text.Trim();
                            dataDictionary.DictionaryValue = txtDictionaryValue.Text.Trim();
                            dataDictionary.Remark = txtRemark.Text.Trim();
                            dataDictionary.IsActive = cbIsActive.SelectedIndex == 0;
                        }
                    }

                    try
                    {
                        dataDictionary.DictionaryId = ServiceHelper.ApplicationService.CreateDataDictionary(dataDictionary);
                        
                        // add new node
                        var newNode = DataTree.AppendNode(new object[] { dataDictionary.DictionaryValue }, parentNode, dataDictionary);
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
                        FormHelper.ShowErrorDialog("创建数据字典信息失败。");
                        throw ex;
                    }
                }
                #endregion

                #region save update data
                if (CurrentDataState == DataState.Update)
                {
                    var currentNode = DataTree.FocusedNode;
                    dataDictionary = currentNode.Tag as DataDictionary;
                    if (dataDictionary == null)
                    {
                        FormHelper.ShowErrorDialog("创建数据字典信息失败。");
                    }

                    if (dataDictionary != null)
                    {
                        dataDictionary.DictionaryCode = txtDataDictionaryCode.Text.Trim();
                        dataDictionary.DictionaryValue = txtDictionaryValue.Text.Trim();
                        dataDictionary.Remark = txtRemark.Text.Trim();
                        dataDictionary.IsActive = cbIsActive.SelectedIndex == 0;
                    }

                    try
                    {
                        bool updateResult = ServiceHelper.ApplicationService.UpdateDataDictionary(dataDictionary);

                        if (updateResult)
                        {
                            DataDictionary newDataDictionary = ServiceHelper.ApplicationService.GetDataDictionaryByCode(GlobalState.CurrentApplication.ApplicationCode, dataDictionary.DictionaryCode);
                            currentNode.Tag = newDataDictionary;
                            currentNode.SetValue(NodeValueColumn, dataDictionary.DictionaryValue);
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
                    }
                    catch (Exception ex)
                    {
                        FormHelper.ShowErrorDialog("更新数据字典信息失败。");
                        throw ex;
                    }
                }
                #endregion
            }
        }

        public override  bool ValidateData()
        {
            Validator.Clear();

            bool result = true;
            string tip;
            if (txtCategory.Text.Trim() == "")
            {
                tip = "请填写字典分类。";
                Validator.SetError(txtCategory, tip);
                result = false;
            }

            if (txtDataDictionaryCode.Text.Trim() == "")
            {
                tip = "请填写字典代码。";
                Validator.SetError(txtDataDictionaryCode, tip);
                result = false;
            }

            if (txtDictionaryValue.Text.Trim() == "")
            {
                tip = "请填写字典值。";
                Validator.SetError(txtDictionaryValue, tip);
                result = false;
            }

            if (cbIsActive.SelectedIndex == -1)
            {
                tip = "请选择是否可用。";
                Validator.SetError(cbIsActive, tip);
                result = false;
            }

            return result;
        }

        public override void ReloadData()
        {
            var currentNode = DataTree.FocusedNode;

            if (currentNode != null && currentNode.Tag != null)
            {
                var dataDictionary = currentNode.Tag as DataDictionary;
                if (dataDictionary != null)
                {
                    txtDataDictionaryLevel.Text = dataDictionary.DictionaryLevel.ToString();
                    var parentDictionary = GetDictionaryById(dataDictionary.ParentId);
                    txtParentID.Text = parentDictionary != null ? parentDictionary.DictionaryValue : string.Empty;
                    txtCategory.Text = dataDictionary.Category;
                    txtDataDictionaryCode.Text = dataDictionary.DictionaryCode;
                    txtDictionaryValue.Text = dataDictionary.DictionaryValue;
                    txtRemark.Text = dataDictionary.Remark;

                    cbIsActive.SelectedIndex = dataDictionary.IsActive ? 0 : 1;
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

            var currentNode = DataTree.FocusedNode;
            if (currentNode != null && currentNode.Tag != null)
            {
                var dataDictionary = currentNode.Tag as DataDictionary;
                if (dataDictionary != null)
                {
                    btnInsert.Enabled = dataDictionary.DictionaryLevel == 1;

                    if (!currentNode.HasChildren || dataDictionary.DictionaryLevel == 2)
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
