using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Business.Domain.Wms;
using Business.Domain.Inventory;
using Business.Domain.Inventory.Views;
using Wms.Common;
using DevExpress.XtraEditors.Controls;
using Framework.UI.Template.Common;
using Framework.UI.Template.Others;
using Modules.InboundPlanModule.Barcode;
using Business.Common.Exception;
using Framework.Core.Encryption;
using System.ServiceModel;

namespace Modules.InboundPlanModule.Views
{
    public partial class PrintSkuLabelForm : CustomForm
    {

        #region Field
        private InboundPlanDetailView _inboundPlanDetail;

        private bool _isPieceManagement;
        private bool _isBarcodeManagement;
        private bool _isBatchManagement;

        #endregion

        #region Property

        /// <summary>
        /// 入库计划
        /// </summary>
        public InboundPlan CurrentInboundPlan { get; set; }

        public List<InboundPlanDetailView> PlanDetails { get; set; }

        #endregion

        #region Method

        public PrintSkuLabelForm()
        {
            InitializeComponent();
        }

        private void InitForm()
        {
            if (CurrentInboundPlan != null)
            {
                beInboundPlan.Enabled = false;

                beInboundPlan.Tag = CurrentInboundPlan;
                beInboundPlan.Text = CurrentInboundPlan.PlanNumber;
                memPlanInformation.Text = CurrentInboundPlan.Remark;
                LoadPlanDetail();
            }
        }

        private void LoadPlanDetail()
        {
            if (beInboundPlan.Tag != null)
            {
                var plan = beInboundPlan.Tag as InboundPlan;
                List<InboundPlanDetailView> details = ServiceHelper.InboundService.GetInboundPlanDetailView(plan.PlanId);

                leSku.Properties.DataSource = null;
                leSku.Properties.DataSource = details;
                leSku.Properties.DisplayMember = "SkuNumber";
                leSku.Properties.ValueMember = "SkuId";
                leSku.Properties.Columns.Add(new LookUpColumnInfo("SkuNumber", "货物代码"));
                leSku.Properties.Columns.Add(new LookUpColumnInfo("PackName", "包装"));

                PlanDetails = details;
            }
        }

        private void CreateInboundBatch(int qty)
        {
            string batchNumber = txtBatchNumber.Text.Trim();

            var batch = new InboundBatch();
            batch.BatchNumber = batchNumber;
            batch.BillNumber = string.Empty;
            batch.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            batch.CreateUser = GlobalState.CurrentUser.UserId;
            batch.InboundDate = DateTime.Now.ToString("yyyy-MM-dd");
            batch.PlanNumber = CurrentInboundPlan.PlanNumber;
            batch.Qty = qty;
            batch.SkuId = _inboundPlanDetail.SkuId;
            batch.WarehouseId = CurrentInboundPlan.WarehouseId;
            try
            {
                ServiceHelper.InboundService.CreateInboundBatch(batch);
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }

        private bool PrintLabel()
        {
            var flag = true;

            try
            {
                var qty = Convert.ToInt32(seQty.Value);
                
                if (txtBatchNumber.Text.Trim() != string.Empty)
                    CreateInboundBatch(qty);

                if (_isPieceManagement)
                {
                    List<SerialNumber> numbers = ServiceHelper.InboundService.CreateSerialNumber(GlobalState.CurrentWarehouse.WarehouseId, _inboundPlanDetail.PlanId, _inboundPlanDetail.SkuId, _inboundPlanDetail.PackId, (int)seQty.Value, GlobalState.CurrentUser.UserId);
                    if (numbers.Count != (int)seQty.Value)
                    {
                        FormHelper.ShowErrorDialog("序列号创建失败。");
                        return false;
                    }

                    SerialNumber[] snArray = numbers.ToArray();
                    txtSNFrom.Text = snArray[0].Sn;
                    txtSNTo.Text = snArray[snArray.Length - 1].Sn;

                    SkuLabel skuLabel = new SkuLabel();
                    foreach (var serialNumber in numbers)
                    {
                        string data = string.Format(SkuLabel.DataFormat, _inboundPlanDetail.SkuNumber, _inboundPlanDetail.SkuNumber,
                                                     _inboundPlanDetail.SkuName, serialNumber.Sn, txtBatchNumber.Text.Trim(), "", "", DateTime.Now.ToString("yyyy-MM-dd"));
                        skuLabel.AppendData(data);
                    }

                    skuLabel.Print();
                }
                else
                {
                    SkuLabel skuLabel = new SkuLabel();
                    for (var i = 0; i <= qty - 1; i++)
                    {
                        string data = string.Format(SkuLabel.DataFormat, _inboundPlanDetail.SkuNumber, _inboundPlanDetail.SkuNumber,
                                 _inboundPlanDetail.SkuName, "", txtBatchNumber.Text.Trim(), "", "", DateTime.Now.ToString("yyyy-MM-dd"));
                        skuLabel.AppendData(data);
                    }

                    skuLabel.Print();
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }

            return flag;
        }

        #endregion

        #region Event

        private void PrintPlanItemBarCode_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_inboundPlanDetail != null)
            {
                if (!_isBarcodeManagement)
                {
                    FormHelper.ShowWarningDialog("非条码管理货物无需打印条码标签。");
                    return;
                }

                var labelQty = (int) seQty.Value;
                if (labelQty <= 0)
                {
                    FormHelper.ShowWarningDialog("标签数量必须大于0。");
                    return;
                }

                if (PrintLabel())
                {
                    FormHelper.ShowInformationDialog("货物" + _inboundPlanDetail.SkuNumber + "条码标签打印成功！");
                }
                else
                {
                    FormHelper.ShowErrorDialog("打印条码标签失败!");
                }
            }
        }

        #endregion

        private void beInboundPlan_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                var listForm = new InboundPlanListForm(FormMode.Select, false);
                listForm.Size = new Size(800, 600);
                Form form = new Form();
                form.Text = @"选择入库计划";

                form.AutoSize = true;

                form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                form.StartPosition = FormStartPosition.CenterScreen;

                form.AutoScroll = true;
                listForm.Parent = form;
                listForm.ReferenceForm = form;
                form.ShowDialog();
                IList list = listForm.GetSelectedData<InboundPlan>();
                if (list != null)
                {
                    var inboundPlan = (InboundPlan)list[0];
                    if (inboundPlan != null)
                    {
                        beInboundPlan.Tag = inboundPlan;
                        beInboundPlan.Text = inboundPlan.PlanNumber;
                        LoadPlanDetail();
                    }
                }
            }

            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                beInboundPlan.Tag = null;
                beInboundPlan.Text = "";
                leSku.Properties.DataSource = null;
                leSku.Properties.Columns.Clear();
                seQty.Value = 0;
                _inboundPlanDetail = null;
            }
        }

        private void leSku_EditValueChanged(object sender, EventArgs e)
        {
            var skuId = (int)leSku.EditValue;
            SetSkuPieceManagement(skuId);

            Sku sku = ServiceHelper.SkuService.GetSkuView(skuId);
            string skuInfo = "货物代号： " + sku.SkuNumber + "\r\n"
                            + "货物名称： " + sku.SkuName + "\r\n"
                            +  "品牌： " + sku.Brand + "\r\n"
                            +  "商家货号： " + sku.ErpCode + "\r\n"
                            +  "型号： " + sku.Model + "\r\n"
                            +  "规格： " + sku.Specification + "\r\n"
                            + "备注： " + sku.Remark;
            memSkuInformation.Text = skuInfo;

            if (_isBatchManagement)
            {
                string batchNumber =
                    ServiceHelper.InboundService.GetNewBatchNumber(GlobalState.CurrentWarehouse.WarehouseCode);
                if (batchNumber == string.Empty)
                {
                    FormHelper.ShowErrorDialog("创建新入库批次号失败。");
                    return;
                }
                txtBatchNumber.Text = batchNumber;
            }

            SetSkuQty(skuId);

            _inboundPlanDetail = (InboundPlanDetailView)leSku.GetSelectedDataRow();
            InitImages();
        }

        private void SetSkuPieceManagement(int skuId)
        {
            // not piece management is default status.
            layoutBarcode.Enabled = false;
            chkIsPieceManagement.Checked = false;
            _isPieceManagement = false;

            SkuManagement skuManagement = ServiceHelper.SkuService.GetSkuManagementMode(skuId);

            if (skuManagement != null)
            {
                if (skuManagement.PieceManagement)
                {
                    chkIsPieceManagement.Checked = true;
                    layoutBarcode.Enabled = true;
                    _isPieceManagement = true;
                }

                _isBatchManagement = skuManagement.BatchManagement;
                _isPieceManagement = skuManagement.PieceManagement;
                chkIsPieceManagement.CheckState = _isPieceManagement ? CheckState.Checked : CheckState.Unchecked;
                _isBarcodeManagement = skuManagement.BarcodeManagement;
            }
        }

        private void SetSkuQty(int skuId)
        {
            foreach (InboundPlanDetailView view in PlanDetails)
            {
                if (view.SkuId == skuId)
                {
                    seQty.Value = view.Qty - view.ReceivedQty;
                    break;
                }
            }
        }

        #region sku images
        private void btnPriorImage_Click(object sender, EventArgs e)
        {
            imgSlider.SlidePrev();
            _currentImageIndex = _currentImageIndex - 1;
            if (_currentImageIndex < 1)
                _currentImageIndex = 1;

            RefreshImageLabel();
        }

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            imgSlider.SlideNext();
            _currentImageIndex = _currentImageIndex + 1;
            if (_currentImageIndex > _skuImageCount)
                _currentImageIndex = _skuImageCount;

            RefreshImageLabel();
        }

        private int _skuImageCount;
        private int _currentImageIndex = 0;

        private void InitImages()
        {
            try
            {
                imgSlider.Images.Clear();

                int skuId = (int)leSku.EditValue;
                _skuImageCount = ServiceHelper.SkuService.GetSkuImageCount(skuId);
                if (_skuImageCount > 0)
                    _currentImageIndex = 1;
                else
                    _currentImageIndex = 0;

                RefreshImageLabel();

                for (int i = 1; i <= _skuImageCount; i++)
                {
                    GetSkuImages(skuId, i);
                }
            }
            catch (FaultException<ServiceError> sex)
            {
                if (sex.Detail != null)
                    FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
            }
        }

        private void RefreshImageLabel()
        {
            lblImages.Text = string.Format("{0}/{1}", _currentImageIndex, _skuImageCount);
        }

        private string GetImagesPath()
        {
            int merchantId = CurrentInboundPlan.MerchantId;
            return System.IO.Path.Combine(GlobalState.SkuImagesPath, merchantId.ToString());
        }

        private string GetImageFileName(int skuId, int index)
        {
            return string.Format("{0}-{1}.jpg", skuId, index);
        }

        private void GetSkuImages(int skuId, int index)
        {
            string path = GetImagesPath();
            string imageFile = System.IO.Path.Combine(path, GetImageFileName(skuId, index));
            bool isExits = System.IO.File.Exists(imageFile);
            if (!isExits)
            {
                try
                {
                    SkuImage skuImage = ServiceHelper.SkuService.GetSkuImage(skuId, index);
                    SaveToImageFile(path, skuImage, index);

                    LoadSkuImage(skuId, index);
                }
                catch (FaultException<ServiceError> sex)
                {
                    if (sex.Detail != null)
                        FormHelper.ShowWarningDialog(sex.Detail.ErrorMessage);
                }
            }
            else
                LoadSkuImage(skuId, index);
        }

        private void SaveToImageFile(string path, SkuImage skuImage, int index)
        {
            CreateFolder(path);
            string filePath = System.IO.Path.Combine(path, GetImageFileName(skuImage.SkuId, index));
            string dStr = CompressHelper.Decompress(skuImage.Image);
            Base64Helper.SaveToFile(dStr, filePath);
        }

        public void CreateFolder(string path)
        {
            System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(path);
            if (!info.Exists)
                System.IO.Directory.CreateDirectory(path);
        }

        private void LoadSkuImage(int skuId, int _currentImageIndex)
        {
            string filePath = System.IO.Path.Combine(GetImagesPath(), GetImageFileName(skuId, _currentImageIndex));
            Image img = Image.FromFile(filePath);
            imgSlider.Images.Add(img);
        }
        #endregion
    }
}
