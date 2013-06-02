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
using Framework.UI.Template.Common;
using Wms.Common;
using Business.Common.Exception;
using System.ServiceModel;

namespace Modules.DistrictModule.Views
{
    [SmartPart]
    public partial class DistrictForm : TreeListForm
    {
        /// <summary>
        /// 全部数据字典缓存
        /// </summary>
        private List<District> DataCache { get; set; }

        public DistrictForm ()
        {
            InitializeComponent();
        }

        public DistrictForm(FormMode mode, bool isMultiSelect)
            : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            base.InitForm();

            this.TreeListName = "所有地区";
            this.TreeListFieldName = "DistrictName";
        }

        public override void InitButtonAuthority()
        {
            btnInsert.Tag = "DISTRICT_INSERT";
            btnUpdate.Tag = "DISTRICT_EDIT";
            btnDelete.Tag = "DISTRICT_DELETE";
        }

        private District GetDistrictById(int districtId)
        {
            foreach (var item in DataCache)
                if (item.DistrictId == districtId)
                    return item;

            return null;
        }

        public override void LoadData()
        {
            Query query = new Query();
            query.Criteria.Add(new Criterion("DistrictId", CriteriaOperator.GreaterThan, 0));
            query.OrderClauses.Add(new OrderClause("DistrictLevel", OrderClause.OrderClauseCriteria.Ascending));
            query.OrderClauses.Add(new OrderClause("DistrictCode", OrderClause.OrderClauseCriteria.Ascending));
            List<District> list = ServiceHelper.BasicDataService.GetDistrictByQuery(query);
            DataCache = list;

            // add DataDictionary nodes
            foreach (District district in list)
            {
                int level = district.DistrictLevel;
                string value = district.DistrictName;
                int id = district.DistrictId;
                int parentID = district.ParentId;
                TreeListNode parentNode = null;
                if (level != 1)
                {
                    FindTreeNode(DataTree.Nodes, parentID, ref parentNode);
                    if (parentNode != null)
                    {
                        TreeListNode newNode = DataTree.AppendNode(new object[] { value }, parentNode, district);
                    }
                }
                else
                {
                    TreeListNode newNode = DataTree.AppendNode(new object[] { value }, null, district);
                    newNode.HasChildren = true;
                }
            }
        }

        private void FindTreeNode(TreeListNodes nodes, int districtId, ref TreeListNode findedNode)
        {
            if (findedNode == null)
                foreach (TreeListNode node in nodes)
                {
                    District district = node.Tag as District;
                    if (district.DistrictId == districtId)
                    {
                        findedNode = node;
                        return;
                    }

                    if (node.HasChildren)
                    {
                        FindTreeNode(node.Nodes, districtId, ref findedNode);
                    }
                }
        }

        public override void ClearFormData()
        {
            txtDistrictLevel.Text = string.Empty;
            txtParentID.Text = string.Empty;
            txtDistrictCode.Text = string.Empty;
            txtDistrictName.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
        }

        public override void SetInputStatus(bool isReadOnly)
        {
            txtDistrictLevel.Properties.ReadOnly = true;
            txtParentID.Properties.ReadOnly = true;
            txtDistrictCode.Properties.ReadOnly = isReadOnly;
            txtDistrictName.Properties.ReadOnly = isReadOnly;
            txtPostalCode.Properties.ReadOnly = isReadOnly;
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

            District district = currentNode.Tag as District;
            if (district != null)
            {
                txtDistrictLevel.Text = district.DistrictLevel.ToString();
                District parentDictionary = GetDistrictById(district.ParentId);
                if (parentDictionary != null)
                    txtParentID.Text = parentDictionary.DistrictName;
                else
                    txtParentID.Text = string.Empty;
                txtDistrictCode.Text = district.DistrictCode;
                txtDistrictName.Text = district.DistrictName;
                txtPostalCode.Text = district.PostalCode;
            }

            SetInputStatus(false);

            CurrentDataState = DataState.Update;
            SetButtonStatus();
        }

        public override void DeleteData()
        {
            TreeListNode currentNode = DataTree.FocusedNode;
            if (currentNode ==null || currentNode.Tag == null) return;

            District district = currentNode.Tag as District;
            if (district != null)
            {
                bool deleteResult = ServiceHelper.BasicDataService.DeleteDistrict(district.DistrictId);

                if (deleteResult)
                {
                    DataTree.DeleteNode(currentNode);
                    //FormHelper.ShowInformationDialog("成功删除地区。");
                }
                else
                {
                    FormHelper.ShowWarningDialog("删除地区失败。");
                }
            }
        }

        public override void SaveData()
        {
            District district;
            
            if (ValidateData())
            {
                if (CurrentDataState == DataState.Create)
                {
                    TreeListNode parentNode = DataTree.FocusedNode;
                    district = new District();
                    if (parentNode == null)
                    {
                        district.DistrictLevel = 1;
                        district.ParentId = 0;
                        district.DistrictCode = txtDistrictCode.Text.Trim();
                        district.DistrictName = txtDistrictName.Text.Trim();
                        district.PostalCode = txtPostalCode.Text.Trim();
                    }
                    else
                    {
                        District parentDistrict = parentNode.Tag as District;
                        if (parentDistrict != null)
                        {
                            district.DistrictLevel = parentDistrict.DistrictLevel + 1;
                            district.ParentId = parentDistrict.DistrictId;
                            district.DistrictCode = txtDistrictCode.Text.Trim();
                            district.DistrictName = txtDistrictName.Text.Trim();
                            district.PostalCode = txtPostalCode.Text.Trim();
                        }
                    }

                    try
                    {
                        district.DistrictId = ServiceHelper.BasicDataService.CreateDistrict(district);
                        
                        // add new node
                        TreeListNode newNode = DataTree.AppendNode(new object[] { district.DistrictName }, parentNode, district);
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
                        FormHelper.ShowErrorDialog("创建地区信息失败。");
                        throw ex;
                    }
                }

                if (CurrentDataState == DataState.Update)
                {
                    TreeListNode currentNode = DataTree.FocusedNode;
                    district = currentNode.Tag as District;
                    if (district != null)
                    {
                        district.DistrictCode = txtDistrictCode.Text.Trim();
                        district.DistrictName = txtDistrictName.Text.Trim();
                        district.PostalCode = txtPostalCode.Text.Trim();
                    }

                    try
                    {
                        bool updateResult = ServiceHelper.BasicDataService.UpdateDistrict(district);

                        if (updateResult)
                        {
                            District newFunction = ServiceHelper.BasicDataService.GetDistrictByCode(district.DistrictCode);
                            currentNode.Tag = newFunction;
                            currentNode.SetValue(NodeValueColumn, district.DistrictName);
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
                        FormHelper.ShowErrorDialog("更新地区信息失败。");
                        throw ex;
                    }
                }
            }
        }

        private bool ValidateData()
        {
            Validator.Clear();

            bool result = true;

            if (txtDistrictCode.Text.Trim() == "")
            {
                string tipa = "请填写地区代码。";
                Validator.SetError(txtDistrictCode, tipa);
                result = false;
            }

            if (txtDistrictName.Text.Trim() == "")
            {
                string tipa = "请填写地区名称。";
                Validator.SetError(txtDistrictName, tipa);
                result = false;
            }

            return result;
        }

        public override void ReloadData()
        {
            TreeListNode currentNode = DataTree.FocusedNode;

            if (currentNode != null && currentNode.Tag != null)
            {
                District district = currentNode.Tag as District;
                if (district != null)
                {
                    txtDistrictLevel.Text = district.DistrictLevel.ToString();
                    District parentDistrict = GetDistrictById(district.ParentId);
                    if (parentDistrict != null)
                        txtParentID.Text = parentDistrict.DistrictName;
                    else
                        txtParentID.Text = string.Empty;
                    txtDistrictCode.Text = district.DistrictCode;
                    txtDistrictName.Text = district.DistrictName;
                    txtPostalCode.Text = district.PostalCode;
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
                District district = currentNode.Tag as District;
                if (district != null && district.DistrictLevel == 3)
                {
                    return true;
                }
            }

            FormHelper.ShowWarningDialog("请选择第三级地区。");
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
                District district = currentNode.Tag as District;
                if (district != null && CurrentFormMode == FormMode.Browse)
                {
                    if (district.DistrictLevel == 1 || district.DistrictLevel == 2)
                    {
                        btnInsert.Enabled = true;
                    }
                    else
                    {
                        btnInsert.Enabled = false;
                    }

                    if (!currentNode.HasChildren || district.DistrictLevel == 3)
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
