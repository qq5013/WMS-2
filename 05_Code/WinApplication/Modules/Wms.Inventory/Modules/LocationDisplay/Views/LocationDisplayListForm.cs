using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Domain.Warehouse;
using DevExpress.XtraEditors;
using Framework.UI.Template.Common;
using Microsoft.Practices.CompositeUI.SmartParts;
using Modules.CompanyModule.Views;
using Wms.Common;
using System.ServiceModel;
using Business.Common.DataDictionary;
using Business.Domain.Application;
using Modules.AreaModule.Views;
using DevExpress.XtraEditors.Controls;
using Business.Domain.Inventory.Views;
using Modules.StockModule.Views;

namespace Modules.LocationDisplayModule.Views
{
    [SmartPart]
    public partial class LocationDisplayListForm : Framework.UI.Template.Single.SingleListForm
    {
        private List<Criterion> _criterions = new List<Criterion>();

        public LocationDisplayListForm()
        {
            InitializeComponent();
        }

        public LocationDisplayListForm(FormMode mode, bool isMultiSelect) : base(mode, isMultiSelect)
        {
            InitializeComponent();
        }

        public override void InitForm()
        {
            RegisterDetailForm("Modules.LocationModule.Views.LocationEditForm");
        }

        public override void InitButtonAuthority()
        {
            //btnCopy.Tag = "Location_INSERT";
            //btnInsert.Tag = "Location_INSERT";
            //btnUpdate.Tag = "Location_EDIT";
            //btnDelete.Tag = "Location_DELETE";
            //btnSearch.Tag = "Location_QUERY";
        }

        public override void SetButtonStatus()
        {
            this.barButton.Visible = false;
        }

        public override void LoadData()
        {
            this.lblLocation1.Text = "123";
            //Label lbl = new Label();
            //lbl.Name = "lblLocation2";
            //lbl.Text = "222222";
            int abc = pnlCondition.Controls.Count;
            foreach (Control i in pnlCondition.Controls)
            {
                string w = i.Name;
                foreach (Control j in i.Controls)
                {
                    //string 
                }
                i.Text = "234";
            }
            
            try
            {
                SetQueryConditions();
                PagerQuery query = new PagerQuery("Location", "LocationId", "*", "LocationId", 
                    OrderClause.OrderClauseCriteria.Ascending, 600, this.PageNumber, _criterions);

                int totalCount;
                int totalCount1;
                DataList = ServiceHelper.WarehouseService.GetLocationByPagerQuery(query, out totalCount);
                SetSplitPage(totalCount);
                BindData();
                int lcount = DataList.Count;
                if ( lcount > 0)
                {
                    if (lcount < 56)
                    {
                        for (int i = 0; i < lcount; i++)
                        {
                            Location location= (Location)DataList[i];
                            string lbarcode = location.Barcode;
                            string locationCoce = location.LocationCode;
                            foreach (Control p in pnlCondition.Controls)
                            {
                                if (p.Name == ("Location" + (i + 1).ToString()))
                                {
                                    foreach (Control l in p.Controls)
                                    {
                                        if (l.Name == ("lblLocation" + (i + 1).ToString()))
                                        {
                                            l.Text = lbarcode;
                                            _criterions.Clear();

                                            _criterions.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, GlobalState.CurrentWarehouse.WarehouseId));

                                            //if (txtLocationCode.Text.Trim() != "")
                                            _criterions.Add(new Criterion("LocationCode", CriteriaOperator.Like, locationCoce + "%"));
                                            PagerQuery query1 = new PagerQuery("Vw_Stock", "StockId", "*", "StockId",
                                                OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, _criterions);
                                            IList DataList1 = null;
                                            DataList1 = ServiceHelper.InventoryService.GetStockViewByPagerQuery(query1, out totalCount1);
                                            if (DataList1.Count > 0)
                                            {
                                                StockView stockView = (StockView) DataList1[0];
                                                if (stockView.Qty > 0)
                                                {
                                                    p.BackColor = System.Drawing.Color.Red;
                                                    l.Text = lbarcode + "\r" + stockView.SkuNumber + "\r" +
                                                             stockView.BatchNumber + "\r" + stockView.Qty;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < lcount; i++)
                        {
                            Location location = (Location)DataList[i];
                            string lbarcode = location.Barcode;
                            string locationCoce = location.LocationCode;
                            foreach (Control p in pnlCondition.Controls)
                            {
                                if (p.Name == ("Location" + (i + 1).ToString()))
                                {
                                    foreach (Control l in p.Controls)
                                    {
                                        if (l.Name == ("lblLocation" + (i + 1).ToString()))
                                        {
                                            l.Text = lbarcode;
                                            _criterions.Clear();

                                            _criterions.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, GlobalState.CurrentWarehouse.WarehouseId));

                                            //if (txtLocationCode.Text.Trim() != "")
                                            _criterions.Add(new Criterion("LocationCode", CriteriaOperator.Like, locationCoce + "%"));
                                            PagerQuery query1 = new PagerQuery("Vw_Stock", "StockId", "*", "StockId",
                                                OrderClause.OrderClauseCriteria.Descending, this.PageSize, this.PageNumber, _criterions);
                                            IList DataList1 = null;
                                            DataList1 = ServiceHelper.InventoryService.GetStockViewByPagerQuery(query1, out totalCount1);
                                            if (DataList1.Count > 0)
                                            {
                                                StockView stockView = (StockView)DataList1[0];
                                                if (stockView.Qty > 0)
                                                {
                                                    p.BackColor = System.Drawing.Color.Red;
                                                    l.Text = lbarcode + "\r" + stockView.SkuNumber + "\r" +
                                                             stockView.BatchNumber + "\r" + stockView.Qty;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
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

            FormHelper.SetGridColumn(MainGridView, "LocationId", "库位编号", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "LocationCode", "库位代码", 150, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "LocationName", "库位名称", 150, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Barcode", "库位条码", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "WarehouseId", "仓库编号", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "AreaId", "库区编号", 150, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "Length", "长度(米)", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Width", "宽度(米)", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "Height", "高度(米)", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "BearingWeight", "承重(千克)", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "ShelfId", "货架编号", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "ShelfRow", "货架行号", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "ShelfColumn", "货架列号", 100, columnIndex++, true);
            FormHelper.SetGridColumn(MainGridView, "ShelfDepth", "货架深度", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "CoordX", "X坐标", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CoordY", "Y坐标", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CoordZ", "Z坐标", 100, columnIndex++, false);



            FormHelper.SetGridColumn(MainGridView, "Route", "路线序号", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "LocationNumber", "库位数量", 100, columnIndex++, false);

            FormHelper.SetGridColumn(MainGridView, "Remark", "描述", 200, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CreateUser", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "CreateTime", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "EditUser", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "EditTime", "", 100, columnIndex++, false);
            FormHelper.SetGridColumn(MainGridView, "IsActive", "是否可用", 100, columnIndex++, true);

            FormHelper.SetGridColumn(MainGridView, "IsValid", "", 100, 999, false);
        }

        #region 得到下拉列表框的数据
        public override void BindGridColumnMap()
        {
            //
        }
        #endregion

        public override void SetQueryConditions()
        {
            _criterions.Clear();

            _criterions.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, GlobalState.CurrentWarehouse.WarehouseId));

            //if (txtLocationCode.Text.Trim() != "")
            _criterions.Add(new Criterion("LocationCode", CriteriaOperator.Like, "L" + "%"));
            //if (txtLocationName.Text.Trim() != "")
            //    _criterions.Add(new Criterion("LocationName", CriteriaOperator.Like, txtLocationName.Text.Trim() + "%"));
            //if (beAreaId.Tag != null)
            //{
            //    Area area = beAreaId.Tag as Area;
            //    if (area != null)
            //        _criterions.Add(new Criterion("AreaId", CriteriaOperator.Equal, area.AreaId));
            //}
        }

        public override void DeleteData()
        {
            Location location = CurrentData as Location;
            if (location == null) return;

            bool deleteResult = false;
            try
            {
                deleteResult = ServiceHelper.WarehouseService.DeleteLocation(location.LocationId);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }

            if (deleteResult)
                FormHelper.ShowInformationDialog("删除库位成功。");
        }

        private void beAreaId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit edit = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                edit.EditValue = null;
                return;
            }

            Form parentForm = new DevExpress.XtraEditors.XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            AreaListForm form = new AreaListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList areas = form.GetSelectedData<Area>();
            if (areas != null && areas.Count > 0)
            {
                Area area = areas[0] as Area;
                //beAreaId.Tag = area;
                //beAreaId.Text = area.AreaName;
            }
        }

        private void Location1_Click(object sender, EventArgs e)
        {
            //DevExpress.XtraEditors.ButtonEdit edit = (DevExpress.XtraEditors.ButtonEdit)sender;
            //if (e.Button.Kind == ButtonPredefines.Delete)
            //{
            //    edit.Tag = null;
            //    edit.Text = string.Empty;
            //    return;
            //}

            //Form parentForm = new DevExpress.XtraEditors.XtraForm();
            //parentForm.AutoSize = true;
            //parentForm.StartPosition = FormStartPosition.CenterScreen;
            //parentForm.ControlBox = false;
            //parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //parentForm.
            //StockListForm form = new StockListForm(FormMode.Select, false);
            //form.Size = new System.Drawing.Size(810, 600);
            //form.Parent = parentForm;
            //form.ReferenceForm = parentForm;
            //parentForm.ShowDialog();
            //IList companys = form.GetSelectedData<StockView>();
            //if (companys != null && companys.Count > 0)
            //{
            //    StockView company = companys[0] as StockView;
            //    ((ButtonEdit)sender).Tag = company;
            //    ((ButtonEdit)sender).Text = company.SkuName;
            //}
        }
    }
}

