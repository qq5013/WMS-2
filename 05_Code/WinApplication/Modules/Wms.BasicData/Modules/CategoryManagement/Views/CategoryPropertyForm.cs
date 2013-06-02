using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Framework.UI.Template.Others;
using Framework.UI.Template.Common;
using Business.Domain.Wms;
using Business.Common.QueryModel;
using Business.Common.Exception;
using Wms.Common;
using System.ServiceModel;

namespace Modules.CategoryManagementModule.Views
{
    public partial class CategoryPropertyForm : CustomForm
    {
        public CategoryManagement CurrentCategory;

        private List<BatchProperty> _batchProperties = new List<BatchProperty>();

        private List<BatchProperty> _categoryProperties = new List<BatchProperty>();

        public CategoryPropertyForm()
        {
            InitializeComponent();
        }

        public CategoryPropertyForm(CategoryManagement category)
        {
            InitializeComponent();

            CurrentCategory = category;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CategoryPropertyForm_Load(object sender, EventArgs e)
        {
            InitBatchProperty();
            InitCategoryProperty();
            AdjustProperty();

            BindCategoryProperty();
            BindBatchProperty();
        }

        private void BindCategoryProperty()
        {
            if (_categoryProperties.Count > 0)
            {
                lbCategoryProperty.DataSource = null;
                lbCategoryProperty.DataSource = _categoryProperties;
                lbCategoryProperty.DisplayMember = "PropertyName";
                lbCategoryProperty.ValueMember = "PropertyId";
            }
        }

        private void BindBatchProperty()
        {
            if (_batchProperties.Count > 0)
            {
                lbBatchProperty.DataSource = null;
                lbBatchProperty.DataSource = _batchProperties;
                lbBatchProperty.DisplayMember = "PropertyName";
                lbBatchProperty.ValueMember = "PropertyId";
            }
        }

        private void AdjustProperty()
        {
            List<BatchProperty> newList = new List<BatchProperty>();
            foreach (var batchProperty in _batchProperties)
            {
                bool hasProperty = false;
                foreach (var categoryProperty in _categoryProperties)
                {
                    if (batchProperty.PropertyId == categoryProperty.PropertyId)
                    {
                        hasProperty = true;
                        break;
                    }
                }

                if (!hasProperty)
                    newList.Add(batchProperty);
            }

            _batchProperties = newList;
        }

        private void InitCategoryProperty()
        {
            if (CurrentCategory != null)
            {
                List<BatchProperty> list = ServiceHelper.BasicDataService.GetBatchPropertyByCategory(CurrentCategory.CategoryId);
                _categoryProperties = list;
            }
        }

        private void InitBatchProperty()
        {
            Query query = new Query();
            query.Criteria.Add(new Criterion("PropertyId", CriteriaOperator.GreaterThan, 0));
            query.Criteria.Add(new Criterion("IsActive", CriteriaOperator.Equal, 1));
            query.OrderClauses.Add(new OrderClause("PropertyId", OrderClause.OrderClauseCriteria.Ascending));
            List<BatchProperty> list = ServiceHelper.BasicDataService.GetBatchPropertyByQuery(query);
            _batchProperties = list;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (lbBatchProperty.SelectedItem != null)
            {
                BatchProperty property = lbBatchProperty.SelectedItem as BatchProperty;
                _categoryProperties.Add(property);
                BindCategoryProperty();

                _batchProperties.Remove(property);
                BindBatchProperty();
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (lbCategoryProperty.SelectedItem != null)
            {
                BatchProperty property = lbCategoryProperty.SelectedItem as BatchProperty;
                _batchProperties.Add(property);
                BindBatchProperty();

                _categoryProperties.Remove(property);
                BindCategoryProperty();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                bool saveResult = ServiceHelper.BasicDataService.SaveCategoryBatchProperty(CurrentCategory.CategoryId, _categoryProperties);
                if (saveResult)
                    this.Close();
                else
                    FormHelper.ShowWarningDialog("保存分类批次属性失败。");
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }
    }
}
