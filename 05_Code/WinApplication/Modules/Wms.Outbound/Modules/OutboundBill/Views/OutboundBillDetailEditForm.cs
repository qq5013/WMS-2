using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Framework.UI.Template.MasterDetail;
using Business.Domain.Inventory;
using Business.Domain.Wms;
using Wms.Common;
using Modules.SkuModule.Views;
using Framework.UI.Template.Common;
using Business.Common.Exception;
using System.ServiceModel;
using Modules.ContainerModule.Views;
using Business.Domain.Warehouse;
using Business.Component;
using Modules.OutboundBillModule;
using Business.Domain.Inventory.Views;
using Modules.LocationModule.Views;

namespace Modules.OutboundBillModule.Views
{
    public partial class OutboundBillDetailEditForm : DetailEditForm
    {
        public OutboundPlan CurrentPlan { get; set; }

        public List<string> SNList { get; set; }

        private bool _isPieceManagement { get; set; }

        private Stock _stock { get; set; }

        public OutboundBillDetailEditForm()
        {
            InitializeComponent();
        }

        public int CurrentGoodsId;

        public override void FormInitialize()
        {

            base.FormInitialize();
            SNList = new List<string>();

            if (ReferenceParentForm != null)
            {
                CurrentPlan = ((OutboundBillEditForm)ReferenceParentForm).bePlanId.Tag as OutboundPlan;
                if (CurrentPlan == null)
                {
                    FormHelper.ShowErrorDialog("请选择出库计划。");
                    this.Close();
                }
                else
                    InitPlanSku();
            }
        }

        private void InitPlanSku()
        {
            List<OutboundPlanDetailView> details = ServiceHelper.OutboundService.GetOutboundPlanDetailView(CurrentPlan.PlanId);
            lePlanSku.Properties.DataSource = null;
            lePlanSku.Properties.DataSource = details;
            lePlanSku.Properties.DisplayMember = "SkuNumber";
            lePlanSku.Properties.ValueMember = "SkuId";

            lePlanSku.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SkuNumber", "货物代码"));
            lePlanSku.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SkuName", "货物名称"));
        }

        public override void SetFormData()
        {
            if (CurrentDetailData != null)
            {
                OutboundBillDetail billDetail = CurrentDetailData as OutboundBillDetail;

                if (billDetail != null)
                {
                    SkuView skuView = ServiceHelper.SkuService.GetSkuView(billDetail.SkuId);
                    lePlanSku.EditValue = billDetail.SkuId;
                    txtSKuName.Text = skuView.SkuName;
                    txtBatchNumber.Text = billDetail.BatchNumber;
                    SetSkuPack(billDetail.SkuId, billDetail.PackId);

                    Location location = ServiceHelper.WarehouseService.GetLocation(billDetail.LocationId);
                    if (location != null)
                    {
                        beLocationId.Tag = location;
                        beLocationId.Text = location.LocationName;
                    }

                    Container container = ServiceHelper.WarehouseService.GetContainer(billDetail.ContainerId);
                    if (container != null)
                    {
                        beContainerId.Tag = container;
                        beContainerId.Text = container.ContainerName;
                    }


                    _isPieceManagement = ServiceHelper.SkuService.IsPieceManagement(skuView.SkuId);
                    if (!_isPieceManagement)
                    {
                        seQty.Value = billDetail.Qty;
                    }
                    else
                    {
                        SNList = billDetail.SerialNumbers;
                        RefreshSN();
                    }
                }
            }
        }

        private void SetSkuPack(int skuId, int packId)
        {
            List<Pack> packs = ServiceHelper.SkuService.GetPacks(skuId);
            lePackId.Properties.DataSource = null;
            lePackId.Properties.DataSource = packs;
            lePackId.Properties.DisplayMember = "PackName";
            lePackId.Properties.ValueMember = "PackId";
            if (packId > 0)
                lePackId.EditValue = packId;
            else
            {
                Pack pack = ServiceHelper.SkuService.GetDefaultPack(skuId);
                if (pack != null)
                    lePackId.EditValue = pack.PackId;
                else
                    FormHelper.ShowErrorDialog("货物缺省包装未正确设置。");
            }
        }

        public override void SaveLocalData()
        {
            OutboundBillEditForm editForm = ReferenceParentForm as OutboundBillEditForm;

            #region 保存新增或复制..........
            if (CurrentDataState == DataState.Create)
            {
                LocalDataInfo localInfo = new LocalDataInfo();

                localInfo.SkuId = (int)lePlanSku.EditValue;
                localInfo.PackId = (int)lePackId.EditValue;
                localInfo.PackName = lePackId.Text.Trim();
                localInfo.Qty = (int)seQty.Value;
                localInfo.SkuName = txtSKuName.Text.Trim();
                localInfo.SkuNumber = lePlanSku.Text.Trim();
                localInfo.BatchNumber = txtBatchNumber.Text.Trim();
                localInfo.StockId = _stock.StockId;
                if (beLocationId.Tag != null)
                {
                    localInfo.LocationId = (beLocationId.Tag as Location).LocationId;
                }
                if (beContainerId.Tag != null)
                {
                    localInfo.ContainerId = (beContainerId.Tag as Container).ContainerId;
                    localInfo.ContainerName = beContainerId.Text.Trim();
                }
                localInfo.SerialNumbers = SNList;
                localInfo.OperationName = "ADD";

                bool result = FindSameSku(localInfo);
                if (result)
                {
                    string tip = "明细中已存在相同货物。";
                    FormHelper.ShowWarningDialog(tip);
                    return;
                }

                if (editForm != null)
                {
                    editForm.listLocalData.Add(localInfo);
                    editForm.DetailDataList.Add(localInfo);
                }
            }
            #endregion

            #region 保存修改........

            if (CurrentDataState == DataState.Update)
            {
                LocalDataInfo localInfo = CurrentDetailData as LocalDataInfo;

                if (localInfo != null)
                {
                    localInfo.SkuId = (int)lePlanSku.EditValue;
                    localInfo.PackId = (int)lePackId.EditValue;
                    localInfo.PackName = lePackId.Text.Trim();
                    localInfo.Qty = (int)seQty.Value;
                    localInfo.SkuName = txtSKuName.Text.Trim();
                    localInfo.StockId = _stock.StockId;
                    localInfo.SkuNumber = lePlanSku.Text.Trim();
                    localInfo.BatchNumber = txtBatchNumber.Text.Trim();
                    localInfo.SerialNumbers = SNList;
                    if (beLocationId.Tag != null)
                    {
                        localInfo.LocationId = (beLocationId.Tag as Location).LocationId;
                    }
                    if (beContainerId.Tag != null)
                    {
                        localInfo.ContainerId = (beContainerId.Tag as Container).ContainerId;
                        localInfo.ContainerName = beContainerId.Text.Trim();
                    }
                    if (!localInfo.OperationName.Equals("ADD"))
                    {
                        localInfo.OperationName = "EDIT";
                    }

                    editForm.listLocalData[localInfo.TempId] = localInfo;
                    editForm.DetailDataList[localInfo.TempId] = localInfo;
                }
            }
            #endregion
        }

        ///<summary>
        ///过滤明细表单,如果已有此类型的单据,则不允许新增,要求用户修改。
        ///不允许存在相同货物的记录
        ///</summary>
        public bool FindSameSku(LocalDataInfo newLocalDataInfo)
        {
            try
            {
                IList oldInfo = ReferenceParentForm.DetailDataList;
                foreach (LocalDataInfo oldLocalDataInfo in oldInfo)
                {
                    if (oldLocalDataInfo.SkuId == newLocalDataInfo.SkuId)            //货物代码
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override bool ValidateData()
        {
            Validator.Clear();
            bool result = true;

            if (lePlanSku.EditValue == null)
            {
                string tipa = "请选择货物。";
                Validator.SetError(lePlanSku, tipa);
                result = false;
            }

            if (lePackId.EditValue == null)
            {
                string tipa = "请选择货物包装。";
                Validator.SetError(lePackId, tipa);
                result = false;
            }

            if (seQty.Value <= 0)
            {
                string tipa = "请输入数量";
                Validator.SetError(seQty, tipa);
                result = false;
            }

            if (beLocationId.Tag == null)
            {
                string tipa = "请选择拣货库位。";
                Validator.SetError(beLocationId, tipa);
                result = false;
            }

            if (result)
            {
                int skuId = (int)lePlanSku.EditValue;
                int packId = (int)lePackId.EditValue;
                int locationId = 0;
                int containerId = 0;
                if (beLocationId.Tag != null)
                    locationId = (beLocationId.Tag as Location).LocationId;
                if (beContainerId.Tag != null)
                    containerId = (beContainerId.Tag as Container).ContainerId;
                string batchNumber = txtBatchNumber.Text.Trim();

                Stock stock = ServiceHelper.InventoryService.GetStock(GlobalState.CurrentWarehouse.WarehouseId, locationId, containerId, skuId, packId, batchNumber);
                _stock = stock;
                if (stock == null)
                {
                    string tipa = "出库明细库存不存在。";
                    Validator.SetError(lePlanSku, tipa);
                    result = false;
                }
                else
                {
                    if (stock.Qty < (int)seQty.Value)
                    {
                        string tipa = "库存数量不足。";
                        Validator.SetError(seQty, tipa);
                        result = false;
                    }
                }
            }

            return result;
        }

        public override void ClearControl()
        {
            lePlanSku.EditValue = null;
            txtSKuName.Text = string.Empty;
            beContainerId.Tag = null;
            beContainerId.Text = string.Empty;

            lePackId.EditValue = null;
            lePackId.Properties.DataSource = null;
            
            seQty.Value = 0;
            seQty.Value = 0;
        }

        private void SetSkuPacket(int skuId)
        {
            try
            {
                List<Pack> packs = ServiceHelper.SkuService.GetPacks(skuId);
                lePackId.Properties.DataSource = null;
                lePackId.Properties.DataSource = packs;
                lePackId.Properties.DisplayMember = "PackName";
                lePackId.Properties.ValueMember = "PackId";

                Pack defaultPack = ServiceHelper.SkuService.GetDefaultPack(skuId);
                lePackId.EditValue = defaultPack.PackId;
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }

        //private void beSkuId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    DevExpress.XtraEditors.ButtonEdit edit = (DevExpress.XtraEditors.ButtonEdit)sender;
        //    if (e.Button.Kind == ButtonPredefines.Delete)
        //    {
        //        edit.Tag = null;
        //        edit.Text = string.Empty;
        //        return;
        //    }

        //    Form parentForm = new DevExpress.XtraEditors.XtraForm();
        //    parentForm.AutoSize = true;
        //    parentForm.StartPosition = FormStartPosition.CenterScreen;
        //    parentForm.ControlBox = false;
        //    parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        //    SkuListForm form = new SkuListForm(FormMode.Select, false);

        //    if (this.ReferenceParentForm != null)
        //    {
        //        InboundBillEditForm detailForm = this.ReferenceParentForm as InboundBillEditForm;
        //        form.beMerchantId.Enabled = false;
        //    }

        //    form.Size = new System.Drawing.Size(810, 600);
        //    form.Parent = parentForm;
        //    form.ReferenceForm = parentForm;
        //    form.QueryData();
        //    parentForm.ShowDialog();
        //    IList skus = form.GetSelectedData<Sku>();
        //    if (skus != null && skus.Count > 0)
        //    {
        //        Sku sku = skus[0] as Sku;
        //        beSkuId.Tag = sku;
        //        beSkuId.Text = sku.SkuNumber;
        //        txtSKuName.Text = sku.SkuName;

        //        SetSkuPacket(sku.SkuId);
        //    }
        //}

        private void beContainerId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit edit = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                edit.Tag = null;
                edit.Text = string.Empty;
                return;
            }

            Form parentForm = new DevExpress.XtraEditors.XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            ContainerListForm form = new ContainerListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList containers = form.GetSelectedData<Container>();
            if (containers != null && containers.Count > 0)
            {
                Container container = containers[0] as Container;
                ((ButtonEdit)sender).Tag = container;
                ((ButtonEdit)sender).Text = container.ContainerName;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (SNList.Contains(txtSN.Text.Trim()))
            {
                SNList.Remove(txtSN.Text.Trim());
            }
            txtSN.SelectAll();
            RefreshSN();
            txtSN.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!SNList.Contains(txtSN.Text.Trim()))
            {
                SNList.Add(txtSN.Text.Trim());
            }
            txtSN.SelectAll();
            RefreshSN();
            txtSN.Focus();
        }

        private void AddToSNList(List<string> SerialNumbers, string sn)
        {
            if (!SerialNumbers.Contains(sn))
                SerialNumbers.Add(sn);
        }

        private void RemoveFromSNList(List<string> SerialNumbers, string sn)
        {
            if (SerialNumbers.Contains(sn))
                SerialNumbers.Remove(sn);
        }

        private void RefreshSN()
        {
            lbSerialNumbers.DataSource = null;
            lbSerialNumbers.DataSource = SNList;
            seQty.Value = SNList.Count;
        }

        private void lePlanSku_EditValueChanged(object sender, EventArgs e)
        {
            if (lePlanSku.EditValue != null)
            {
                OutboundPlanDetailView detail = (OutboundPlanDetailView)lePlanSku.GetSelectedDataRow();
                _isPieceManagement = ServiceHelper.SkuService.IsPieceManagement((int)lePlanSku.EditValue);
                txtSKuName.Text = detail.SkuName;
                if (!_isPieceManagement)
                {
                    seQty.Enabled = true;
                    gcSN.Visible = false;

                    // set receive qty 
                    seQty.Value = detail.Qty + detail.IssuedQty;
                }
                else
                {
                    seQty.Enabled = false;
                    gcSN.Visible = true;
                }

                SetSkuPack((int)lePlanSku.EditValue, 0);
            }
        }

        private void txtSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (chkMode.Checked)
                    btnAdd_Click(null, null);
                else
                    btnRemove_Click(null, null);
            }
        }

        private void beLocationId_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit edit = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                edit.Tag = null;
                edit.Text = string.Empty;
                return;
            }

            Form parentForm = new DevExpress.XtraEditors.XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            LocationListForm form = new LocationListForm(FormMode.Select, false);
            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            parentForm.ShowDialog();
            IList locations = form.GetSelectedData<Location>();
            if (locations != null && locations.Count > 0)
            {
                Location location = locations[0] as Location;
                ((ButtonEdit)sender).Tag = location;
                ((ButtonEdit)sender).Text = location.LocationName;
            }
        }
    }
}