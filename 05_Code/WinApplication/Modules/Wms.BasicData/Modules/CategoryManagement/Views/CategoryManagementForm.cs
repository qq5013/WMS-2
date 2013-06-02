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
using Business.Domain.Wms;
using Business.Domain.Application;
using Framework.UI.Template.Common;
using Wms.Common;
using Business.Common.Exception;
using System.ServiceModel;
using Business.Common.DataDictionary;
using DevExpress.XtraBars;
using Business.Common.Toolkit;

namespace Modules.CategoryManagementModule.Views
{
    [SmartPart]
    public partial class CategoryManagementForm : TreeListForm
    {
        /// <summary>
        /// 全部数据字典缓存
        /// </summary>
        private List<CategoryManagement> DataCache { get; set; }

        public CategoryManagementForm ()
        {
            InitializeComponent();
        }

        public CategoryManagementForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            base.InitForm();

            this.TreeListName = "所有管理分类";
            this.TreeListFieldName = "CategoryName";

            InitComboBox();

            btnCopy.Visibility = BarItemVisibility.Always;
            btnCopy.Caption = "设置批次属性";
        }

        public override void CopyData()
        {
            TreeListNode currentNode = DataTree.FocusedNode;
            if (currentNode ==null || currentNode.Tag == null) return;

            CategoryManagement category = currentNode.Tag as CategoryManagement;
            if (category == null) return;

            CategoryPropertyForm form = new CategoryPropertyForm(category);
            form.ShowDialog();
        }

        private void InitComboBox()
        {
            // abc type
            Query query = new Query();
            query.Criteria.Add(new Criterion("Category", CriteriaOperator.Equal, DictionaryEnum.ABC_TYPE.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));
            List<DataDictionary> abcTypes = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            leAbcType.Properties.DataSource = abcTypes;
            leAbcType.Properties.DisplayMember = "DictionaryValue";
            leAbcType.Properties.ValueMember = "DictionaryId";
            leAbcType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leAbcType.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));

            // storage condition
            query.Criteria.Clear();
            query.Criteria.Add(new Criterion("Category", CriteriaOperator.Equal, DictionaryEnum.STORAGE_CONDITION.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));
            List<DataDictionary> storageconditions = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            leStorageCondition.Properties.DataSource = storageconditions;
            leStorageCondition.Properties.DisplayMember = "DictionaryValue";
            leStorageCondition.Properties.ValueMember = "DictionaryId";
            leStorageCondition.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leStorageCondition.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));

            // pick rule
            query.Criteria.Clear();
            query.Criteria.Add(new Criterion("Category", CriteriaOperator.Equal, DictionaryEnum.PICK_RULE.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));
            List<DataDictionary> pickRules = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            lePickRule.Properties.DataSource = pickRules;
            lePickRule.Properties.DisplayMember = "DictionaryValue";
            lePickRule.Properties.ValueMember = "DictionaryId";
            lePickRule.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            lePickRule.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));

            // pick group
            query.Criteria.Clear();
            query.Criteria.Add(new Criterion("Category", CriteriaOperator.Equal, DictionaryEnum.PICK_GROUP.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));
            List<DataDictionary> pickGroups = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            lePickGroup.Properties.DataSource = pickGroups;
            lePickGroup.Properties.DisplayMember = "DictionaryValue";
            lePickGroup.Properties.ValueMember = "DictionaryId";
            lePickGroup.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            lePickGroup.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));

            // replenish group
            query.Criteria.Clear();
            query.Criteria.Add(new Criterion("Category", CriteriaOperator.Equal, DictionaryEnum.REPLENISH_GROUP.ToString()));
            query.Criteria.Add(new Criterion("DictionaryLevel", CriteriaOperator.Equal, 2));
            List<DataDictionary> replenishGroups = ServiceHelper.ApplicationService.GetDataDictionaryByQuery(query);
            leReplenishGroup.Properties.DataSource = replenishGroups;
            leReplenishGroup.Properties.DisplayMember = "DictionaryValue";
            leReplenishGroup.Properties.ValueMember = "DictionaryId";
            leReplenishGroup.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryCode", "代码"));
            leReplenishGroup.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DictionaryValue", "值"));
        }

        public override void InitButtonAuthority()
        {
            btnInsert.Tag = "CATEGORYMANAGEMENT_INSERT";
            btnUpdate.Tag = "CATEGORYMANAGEMENT_EDIT";
            btnDelete.Tag = "CATEGORYMANAGEMENT_DELETE";
        }

        private CategoryManagement GetCategoryById(int categoryId)
        {
            foreach (var item in DataCache)
                if (item.CategoryId == categoryId)
                    return item;

            return null;
        }

        public override void LoadData()
        {
            Query query = new Query();
            query.Criteria.Add(new Criterion("CategoryId", CriteriaOperator.GreaterThan, 0));
            query.OrderClauses.Add(new OrderClause("CategoryLevel", OrderClause.OrderClauseCriteria.Ascending));
            query.OrderClauses.Add(new OrderClause("CategoryCode", OrderClause.OrderClauseCriteria.Ascending));
            List<CategoryManagement> list = ServiceHelper.BasicDataService.GetCategoryManagementByQuery(query);
            DataCache = list;

            // add DataDictionary nodes
            foreach (CategoryManagement category in list)
            {
                int level = category.CategoryLevel;
                string value = category.CategoryName;
                int id = category.CategoryId;
                int parentID = category.ParentId;
                TreeListNode parentNode = null;
                if (level != 1)
                {
                    FindTreeNode(DataTree.Nodes, parentID, ref parentNode);
                    if (parentNode != null)
                    {
                        TreeListNode newNode = DataTree.AppendNode(new object[] { value }, parentNode, category);
                    }
                }
                else
                {
                    TreeListNode newNode = DataTree.AppendNode(new object[] { value }, null, category);
                    newNode.HasChildren = true;
                }
            }
        }

        private void FindTreeNode(TreeListNodes nodes, int categoryId, ref TreeListNode findedNode)
        {
            if (findedNode == null)
                foreach (TreeListNode node in nodes)
                {
                    CategoryManagement category = node.Tag as CategoryManagement;
                    if (category.CategoryId == categoryId)
                    {
                        findedNode = node;
                        return;
                    }

                    if (node.HasChildren)
                    {
                        FindTreeNode(node.Nodes, categoryId, ref findedNode);
                    }
                }
        }

        public override void ClearFormData()
        {
            txtCategoryLevel.Text = string.Empty;
            txtParentID.Text = string.Empty;
            txtCategoryCode.Text = string.Empty;
            txtCategoryName.Text = string.Empty;

            seQcPercent.Value = 0;

            leAbcType.EditValue = null;
            leStorageCondition.EditValue = null;
            lePickRule.EditValue = null;
            lePickGroup.EditValue = null;
            leReplenishGroup.EditValue = null;

            cbBatchManagement.SelectedIndex = 1;
            cbBarcodeManagement.SelectedIndex = 0;
            cbContainerManagement.SelectedIndex = 1;
            cbIsBigItem.SelectedIndex = 1;
            cbIsHeavyItem.SelectedIndex = 1;
            cbPieceManagement.SelectedIndex = 1;

            txtRemark.Text = string.Empty;
            cbIsActive.SelectedIndex = 0;
            txtCreateTime.Text = string.Empty;
            txtEditTime.Text = string.Empty;
            txtCreateUser.Text = string.Empty;
            txtEditUser.Text = string.Empty;
        }

        public override void SetInputStatus(bool isReadOnly)
        {
            txtCategoryLevel.Properties.ReadOnly = true;
            txtParentID.Properties.ReadOnly = true;
            txtCategoryCode.Properties.ReadOnly = isReadOnly;
            txtCategoryName.Properties.ReadOnly = isReadOnly;

            seQcPercent.Properties.ReadOnly = isReadOnly;

            leAbcType.Properties.ReadOnly = isReadOnly;
            leStorageCondition.Properties.ReadOnly = isReadOnly;
            lePickRule.Properties.ReadOnly = isReadOnly;
            lePickGroup.Properties.ReadOnly = isReadOnly;
            leReplenishGroup.Properties.ReadOnly = isReadOnly;

            cbBarcodeManagement.Properties.ReadOnly = isReadOnly;
            cbBatchManagement.Properties.ReadOnly = isReadOnly;
            cbContainerManagement.Properties.ReadOnly = isReadOnly;
            cbIsBigItem.Properties.ReadOnly = isReadOnly;
            cbIsHeavyItem.Properties.ReadOnly = isReadOnly;
            cbPieceManagement.Properties.ReadOnly = isReadOnly;

            txtRemark.Properties.ReadOnly = isReadOnly;
            cbIsActive.Properties.ReadOnly = isReadOnly;
            txtCreateTime.Properties.ReadOnly = isReadOnly;
            txtEditTime.Properties.ReadOnly = isReadOnly;
            txtCreateUser.Properties.ReadOnly = isReadOnly;
            txtEditUser.Properties.ReadOnly = isReadOnly;
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

            CategoryManagement category = currentNode.Tag as CategoryManagement;
            if (category != null)
            {
                txtCategoryLevel.Text = category.CategoryLevel.ToString();
                CategoryManagement parentCategory = GetCategoryById(category.ParentId);
                if (parentCategory != null)
                    txtParentID.Text = parentCategory.CategoryName;
                else
                    txtParentID.Text = string.Empty;
                txtCategoryCode.Text = category.CategoryCode;
                txtCategoryName.Text = category.CategoryName;
            }

            SetInputStatus(false);

            CurrentDataState = DataState.Update;
            SetButtonStatus();
        }

        public override void DeleteData()
        {
            TreeListNode currentNode = DataTree.FocusedNode;
            if (currentNode ==null || currentNode.Tag == null) return;

            CategoryManagement category = currentNode.Tag as CategoryManagement;
            if (category != null)
            {
                bool deleteResult = ServiceHelper.BasicDataService.DeleteCategoryManagement(category.CategoryId);

                if (deleteResult)
                {
                    DataTree.DeleteNode(currentNode);
                    //FormHelper.ShowInformationDialog("成功删除管理分类。");
                }
                else
                {
                    FormHelper.ShowWarningDialog("删除管理分类失败。");
                }
            }
        }

        public override void SaveData()
        {
            CategoryManagement category;
            
            if (ValidateData())
            {
                if (CurrentDataState == DataState.Create)
                {
                    TreeListNode parentNode = DataTree.FocusedNode;
                    category = new CategoryManagement();
                    if (parentNode == null)
                    {
                        category.CategoryLevel = 1;
                        category.ParentId = 0;
                        category.CategoryCode = txtCategoryCode.Text.Trim();
                        category.CategoryName = txtCategoryName.Text.Trim();
                    }
                    else
                    {
                        CategoryManagement parentDistrict = parentNode.Tag as CategoryManagement;
                        if (parentDistrict != null)
                        {
                            category.CategoryLevel = parentDistrict.CategoryLevel + 1;
                            category.ParentId = parentDistrict.CategoryId;
                            category.CategoryCode = txtCategoryCode.Text.Trim();
                            category.CategoryName = txtCategoryName.Text.Trim();
                        }
                    }

                    category.QcPercent = (int)seQcPercent.Value;

                    if (leAbcType.EditValue != null)
                        category.AbcType = (int)leAbcType.EditValue;
                    if (leStorageCondition.EditValue != null)
                        category.StorageCondition = (int)leStorageCondition.EditValue;
                    if (lePickRule.EditValue != null)
                        category.PickRule = (int)lePickRule.EditValue;
                    if (lePickGroup.EditValue != null)
                        category.PickGroup = (int)lePickGroup.EditValue;
                    if (leReplenishGroup.EditValue != null)
                        category.ReplenishGroup = (int)leReplenishGroup.EditValue;

                    category.BarcodeManagement = cbBarcodeManagement.SelectedIndex == 0;
                    category.BatchManagement = cbBatchManagement.SelectedIndex == 0;
                    category.PieceManagement = cbPieceManagement.SelectedIndex == 0;
                    category.IsBigItem = cbIsBigItem.SelectedIndex == 0;
                    category.IsHeavyItem = cbIsHeavyItem.SelectedIndex == 0;
                    category.ContainerManagement = cbContainerManagement.SelectedIndex == 0;

                    category.Remark = txtRemark.Text.Trim();
                    category.CreateUser = GlobalState.CurrentUser.UserId;
                    category.IsActive = cbIsActive.SelectedIndex == 0;
                    category.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                    
                    try
                    {
                        category.CategoryId = ServiceHelper.BasicDataService.CreateCategoryManagement(category);
                        
                        // add new node
                        TreeListNode newNode = DataTree.AppendNode(new object[] { category.CategoryName }, parentNode, category);
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
                        FormHelper.ShowErrorDialog("创建管理分类信息失败。");
                        throw ex;
                    }
                }

                if (CurrentDataState == DataState.Update)
                {
                    TreeListNode currentNode = DataTree.FocusedNode;
                    category = currentNode.Tag as CategoryManagement;
                    if (category != null)
                    {
                        category.CategoryCode = txtCategoryCode.Text.Trim();
                        category.CategoryName = txtCategoryName.Text.Trim();
                    }

                    category.QcPercent = (int)seQcPercent.Value;
                    if (leAbcType.EditValue != null)
                        category.AbcType = (int)leAbcType.EditValue;
                    if (leStorageCondition.EditValue != null)
                        category.StorageCondition = (int)leStorageCondition.EditValue;
                    if (lePickRule.EditValue != null)
                        category.PickRule = (int)lePickRule.EditValue;
                    if (lePickGroup.EditValue != null)
                        category.PickGroup = (int)lePickGroup.EditValue;
                    if (leReplenishGroup.EditValue != null)
                        category.ReplenishGroup = (int)leReplenishGroup.EditValue;

                    category.BarcodeManagement = cbBarcodeManagement.SelectedIndex == 0;
                    category.BatchManagement = cbBatchManagement.SelectedIndex == 0;
                    category.PieceManagement = cbPieceManagement.SelectedIndex == 0;
                    category.IsBigItem = cbIsBigItem.SelectedIndex == 0;
                    category.IsHeavyItem = cbIsHeavyItem.SelectedIndex == 0;
                    category.ContainerManagement = cbContainerManagement.SelectedIndex == 0;

                    category.Remark = txtRemark.Text.Trim();
                    category.EditUser = GlobalState.CurrentUser.UserId;
                    category.IsActive = cbIsActive.SelectedIndex == 0;

                    try
                    {
                        bool updateResult = ServiceHelper.BasicDataService.UpdateCategoryManagement(category);

                        if (updateResult)
                        {
                            CategoryManagement newCategory = ServiceHelper.BasicDataService.GetCategoryManagementByCode(category.CategoryCode);
                            currentNode.Tag = newCategory;
                            currentNode.SetValue(NodeValueColumn, category.CategoryName);
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
                        FormHelper.ShowErrorDialog("更新管理分类信息失败。");
                        throw ex;
                    }
                }
            }
        }

        private bool ValidateData()
        {
            Validator.Clear();

            bool result = true;

            if (txtCategoryCode.Text.Trim() == "")
            {
                string tipa = "请填写管理分类代码。";
                Validator.SetError(txtCategoryCode, tipa);
                result = false;
            }

            if (txtCategoryName.Text.Trim() == "")
            {
                string tipa = "请填写管理分类名称。";
                Validator.SetError(txtCategoryName, tipa);
                result = false;
            }

            if (cbBarcodeManagement.SelectedIndex == -1)
            {
                string tipa = "请选择是否条码管理方式。";
                Validator.SetError(cbBarcodeManagement, tipa);
                result = false;
            }

            if (cbBatchManagement.SelectedIndex == -1)
            {
                string tipa = "请选择是否批次管理方式。";
                Validator.SetError(cbBatchManagement, tipa);
                result = false;
            }

            if (cbContainerManagement.SelectedIndex == -1)
            {
                string tipa = "请选择是否容器管理方式。";
                Validator.SetError(cbContainerManagement, tipa);
                result = false;
            }

            if (cbIsBigItem.SelectedIndex == -1)
            {
                string tipa = "请选择是否大货管理方式。";
                Validator.SetError(cbIsBigItem, tipa);
                result = false;
            }

            if (cbIsHeavyItem.SelectedIndex == -1)
            {
                string tipa = "请选择是否重货管理方式。";
                Validator.SetError(cbIsHeavyItem, tipa);
                result = false;
            }

            if (cbPieceManagement.SelectedIndex == -1)
            {
                string tipa = "请选择是否单件管理方式。";
                Validator.SetError(cbPieceManagement, tipa);
                result = false;
            }

            if (lePickRule.EditValue == null)
            {
                string tipa = "请选择拣选规则。";
                Validator.SetError(lePickRule, tipa);
                result = false;
            }

            if (lePickGroup.EditValue == null)
            {
                string tipa = "请选择拣选分组。";
                Validator.SetError(lePickGroup, tipa);
                result = false;
            }

            if (leReplenishGroup.EditValue == null)
            {
                string tipa = "请选择补货分组。";
                Validator.SetError(leReplenishGroup, tipa);
                result = false;
            }


            return result;
        }

        public override void ReloadData()
        {
            TreeListNode currentNode = DataTree.FocusedNode;

            if (currentNode != null && currentNode.Tag != null)
            {
                CategoryManagement category = currentNode.Tag as CategoryManagement;
                if (category != null)
                {
                    txtCategoryLevel.Text = category.CategoryLevel.ToString();
                    CategoryManagement parentCategory = GetCategoryById(category.ParentId);
                    if (parentCategory != null)
                        txtParentID.Text = parentCategory.CategoryName;
                    else
                        txtParentID.Text = string.Empty;
                    txtCategoryCode.Text = category.CategoryCode;
                    txtCategoryName.Text = category.CategoryName;

                    seQcPercent.EditValue = category.QcPercent;
                    seQcPercent.Value = category.QcPercent;

                    leAbcType.EditValue = category.AbcType;
                    leStorageCondition.EditValue = category.StorageCondition;
                    lePickRule.EditValue = category.PickRule;
                    lePickGroup.EditValue = category.PickGroup;
                    leReplenishGroup.EditValue = category.ReplenishGroup;

                    if (category.BarcodeManagement)
                        cbBarcodeManagement.SelectedIndex = 0;
                    else
                        cbBarcodeManagement.SelectedIndex = 1;

                    if (category.BatchManagement)
                        cbBatchManagement.SelectedIndex = 0;
                    else
                        cbBatchManagement.SelectedIndex = 1;

                    if (category.PieceManagement)
                        cbPieceManagement.SelectedIndex = 0;
                    else
                        cbPieceManagement.SelectedIndex = 1;

                    if (category.IsBigItem)
                        cbIsBigItem.SelectedIndex = 0;
                    else
                        cbIsBigItem.SelectedIndex = 1;

                    if (category.IsHeavyItem)
                        cbIsHeavyItem.SelectedIndex = 0;
                    else
                        cbIsHeavyItem.SelectedIndex = 1;

                    if (category.ContainerManagement)
                        cbContainerManagement.SelectedIndex = 0;
                    else
                        cbContainerManagement.SelectedIndex = 1;

                    txtRemark.Text = category.Remark;

                    txtCreateTime.Text = category.CreateTime;
                    txtEditTime.Text = category.EditTime;
                    txtCreateUser.Text = ServiceHelper.ApplicationService.GetUserName(category.CreateUser);
                    txtEditUser.Text = ServiceHelper.ApplicationService.GetUserName(category.EditUser);

                    if (category.IsActive)
                        cbIsActive.SelectedIndex = 0;
                    else
                        cbIsActive.SelectedIndex = 1;
                }
            }
        }

        public override void SetButtonStatus()
        {
            if (CurrentFormMode == FormMode.Browse)
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
                            btnCopy.Enabled = true;
                            break;
                        }
                    case DataState.Create:
                        {
                            btnInsert.Enabled = false;
                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;
                            btnSave.Enabled = true;
                            btnCancel.Enabled = true;
                            btnCopy.Enabled = false;
                            break;
                        }
                    case DataState.Update:
                        {
                            btnInsert.Enabled = false;
                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;
                            btnSave.Enabled = true;
                            btnCancel.Enabled = true;
                            btnCopy.Enabled = true;
                            break;
                        }
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

        public override bool ValidateSelectNode()
        {
            TreeListNode currentNode = DataTree.FocusedNode;
            if (currentNode != null && currentNode.Tag != null)
            {
                return true;
            }

            FormHelper.ShowWarningDialog("请选择管理分类。");
            return false;
        }

        protected override void FocusedNodeChangedEventHandler(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            ReloadData();
            CurrentDataState = DataState.Read;

            TreeListNode currentNode = DataTree.FocusedNode;
            
            if (currentNode != null && currentNode.Tag != null)
            {
                SelectedData = currentNode.Tag;
                CategoryManagement category = currentNode.Tag as CategoryManagement;
                if (category != null && CurrentFormMode == FormMode.Browse)
                {
                    if (category.CategoryLevel == 1 || category.CategoryLevel == 2)
                    {
                        btnInsert.Enabled = true;
                    }
                    else
                    {
                        btnInsert.Enabled = false;
                    }

                    if (!currentNode.HasChildren || category.CategoryLevel == 3)
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
