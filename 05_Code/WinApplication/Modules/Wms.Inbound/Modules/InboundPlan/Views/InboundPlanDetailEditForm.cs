using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Framework.UI.Template.MasterDetail;
using Business.Domain.Inventory;
using Business.Domain.Wms;
using Wms.Common;
using Modules.SkuModule.Views;
using Framework.UI.Template.Common;
using Business.Common.Exception;
using System.ServiceModel;


namespace Modules.InboundPlanModule.Views
{
    public partial class InboundPlanDetailEditForm : DetailEditForm
    {
        public InboundPlanDetailEditForm()
        {
            InitializeComponent();
        }

        public override void FormInitialize()
        {
            base.FormInitialize();
        }

        public override void SetFormData()
        {
            if (CurrentDetailData != null)
            {
                InboundPlanDetail planDetail = CurrentDetailData as InboundPlanDetail;

                if (planDetail != null)
                {
                    SkuView skuView = ServiceHelper.SkuService.GetSkuView(planDetail.SkuId);
                    beSkuId.Tag = skuView as Sku;
                    beSkuId.Text = skuView.SkuNumber;
                    txtSKuName.Text = skuView.SkuName;

                    List<Pack> packs = ServiceHelper.SkuService.GetPacks(planDetail.SkuId);
                    lePackId.Properties.DataSource = null;
                    lePackId.Properties.DataSource = packs;
                    lePackId.Properties.DisplayMember = "PackName";
                    lePackId.Properties.ValueMember = "PackId";
                    lePackId.EditValue = planDetail.PackId;

                    //Pack pack = ServiceHelper.SkuService.GetPacks(planDetail.PackId);
                    seQty.Value = planDetail.Qty;
                    seReceivedQty.Value = planDetail.ReceivedQty;
                }
            }
        }

        public override void SaveLocalData()
        {
            InboundPlanEditForm editForm = ReferenceParentForm as InboundPlanEditForm;

            #region 保存新增或复制..........
            if (CurrentDataState == DataState.Create)
            {
                LocalDataInfo localInfo = new LocalDataInfo();

                localInfo.SkuId = (beSkuId.Tag as Sku).SkuId;
                localInfo.PackId = (int)lePackId.EditValue;
                localInfo.PackName = lePackId.Text.Trim();
                localInfo.Qty = (int)seQty.Value;
                localInfo.SkuName = txtSKuName.Text.Trim();
                localInfo.SkuNumber = beSkuId.Text.Trim();

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
                    localInfo.SkuId = (beSkuId.Tag as Sku).SkuId;
                    localInfo.PackId = (int)lePackId.EditValue;
                    localInfo.PackName = lePackId.Text.Trim();
                    localInfo.Qty = (int)seQty.Value;
                    localInfo.SkuName = txtSKuName.Text.Trim();
                    localInfo.SkuNumber = beSkuId.Text.Trim();

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
            if (beSkuId.Tag == null)
            {
                string tipa = "请选择货物。";
                Validator.SetError(beSkuId, tipa);
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

            return result;
        }

        public override void ClearControl()
        {
            beSkuId.Tag = null;
            beSkuId.Text = string.Empty;
            txtSKuName.Text = string.Empty;

            lePackId.EditValue = null;
            lePackId.Properties.DataSource = null;
            
            seQty.Value = 0;
            seReceivedQty.Value = 0;
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

        private void beSkuId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Form parentForm = new DevExpress.XtraEditors.XtraForm();
            parentForm.AutoSize = true;
            parentForm.StartPosition = FormStartPosition.CenterScreen;
            parentForm.ControlBox = false;
            parentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            SkuListForm form = new SkuListForm(FormMode.Select, false);

            if (this.ReferenceParentForm != null)
            {
                InboundPlanEditForm detailForm = this.ReferenceParentForm as InboundPlanEditForm;
                form.beMerchantId.Enabled = false;
                form.beMerchantId.Tag = detailForm.beMerchantId.Tag;
                form.beMerchantId.Text = detailForm.beMerchantId.Text;
            }

            form.Size = new System.Drawing.Size(810, 600);
            form.Parent = parentForm;
            form.ReferenceForm = parentForm;
            form.QueryData();
            parentForm.ShowDialog();
            IList skus = form.GetSelectedData<Sku>();
            if (skus != null && skus.Count > 0)
            {
                Sku sku = skus[0] as Sku;
                beSkuId.Tag = sku;
                beSkuId.Text = sku.SkuNumber;
                txtSKuName.Text = sku.SkuName;

                SetSkuPacket(sku.SkuId);
            }
        }
    }
}