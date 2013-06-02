using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Business.Domain.Wms;
using Business.Domain.Inventory;
using Frame.Utils.Service;
using MES.BllService;
using MES.Entity;
using Mes.Product.Modules.ProductPlan.Barcode;
using Wms.Common;
using DevExpress.XtraEditors.Controls;
using Framework.UI.Template.Common;
using Framework.UI.Template.Others;
using Sku = Business.Domain.Wms.Sku;

namespace Mes.Product.Modules.ProductPlan.Views
{
    public partial class PrintSkuLabelForm : CustomForm
    {
        private IEntityService<MES.Entity.ProductionPlan> Service = ServiceBloker.GetService<ProductionPlan>();
        #region Field

        //private BllResult _bllResult;

        private Boolean _canPrint = true;

        private ProductionPlanDetail _ProductionPlanDetail;

        private bool _isPieceManmagement;

        #endregion

        #region Property

        /// <summary>
        /// 入库计划
        /// </summary>
        public ProductionPlan CurrentProductionPlan { get; set; }

        public List<ProductionPlanDetail> PlanDetails { get; set; }

        #endregion

        #region Method

        public PrintSkuLabelForm()
        {
            InitializeComponent();


        }

        //private void SetGoodsQuentity(ProductionPlanDetailView ProductionPlanDetail)
        //{
        //    //if (ProductionPlanDetail != null)
        //    //{
        //    //    setGoodsQutity.Enabled = true;
        //    //    medInboundDetailMemo.Text = GetMemo(ProductionPlanDetail.GoodsId);
        //    //    setGoodsQutity.Text = ProductionPlanDetail.GoodsQty.ToString();
        //    //}
        //    //else
        //    //{
        //    //    medInboundDetailMemo.Text = "";
        //    //    setGoodsQutity.Text = @"0";
        //    //    setGoodsQutity.Enabled = false;
        //    //}
        //}

        //private static String GetMemo(int goodsId)
        //{
        //    string result = "";
        //    //BllResult bllResult;
        //    //ArrayList arrayList = ServiceHelper.FacadeService.GetByCondition(out bllResult, typeof (Goods).FullName,
        //    //                                                        " GoodsID =" + goodsId);
        //    //if(arrayList!=null && arrayList.Count>0)
        //    //{
        //    //    var goods = (Goods) arrayList[0];
        //    //    if(goods!=null)
        //    //    {
        //    //        if(!string.IsNullOrEmpty(goods.GoodsName))
        //    //        {
        //    //            result += goods.GoodsName;
        //    //        }
        //    //        if (!string.IsNullOrEmpty(goods.Model))
        //    //        {
        //    //            if (!string.IsNullOrEmpty(result))
        //    //            {
        //    //                result += "," + goods.Model;
        //    //            }else
        //    //            {
        //    //                result += goods.Model;
        //    //            }
        //    //        }
        //    //        if (!string.IsNullOrEmpty(goods.Specs))
        //    //        {
        //    //            if (!string.IsNullOrEmpty(result))
        //    //            {
        //    //                result += "," + goods.Specs;
        //    //            }
        //    //            else
        //    //            {
        //    //                result += goods.Specs;
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //    return result;
        //}

        private void InitForm()
        {
            if (CurrentProductionPlan != null)
            {
                beProductionPlan.Enabled = false;

                beProductionPlan.Tag = CurrentProductionPlan;
                //beProductionPlan.Text = CurrentProductionPlan.PlanNumber;
                memPlanInformation.Text = CurrentProductionPlan.Remark;
                LoadPlanDetail();

            }
        }

        private void LoadPlanDetail()
        {
            if (beProductionPlan.Tag != null)
            {
                ProductionPlan plan = beProductionPlan.Tag as ProductionPlan;
                List<ProductionPlanDetail> details = Service.GetProductionPlanDetailView(plan.PlanId);

                leSku.Properties.DataSource = null;
                leSku.Properties.DataSource = details;
                leSku.Properties.DisplayMember = "SkuNumber";
                leSku.Properties.ValueMember = "SkuId";
                leSku.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SkuNumber", "货物代码"));
                leSku.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PackName", "包装"));

                PlanDetails = details;
            }
        }

        private static String GetDataTime(DateTime dateTime, bool firstDayFlag)
        {
            string result;
            if (firstDayFlag)
            {
                result = Convert.ToDateTime(dateTime.Year + "-01-01 00:00:00").ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                result = Convert.ToDateTime(dateTime.Year + "-12-31 23:59:59").ToString("yyyy-MM-dd HH:mm:ss");
            }
            return result;
        }

        private void SetSnByWarehouse()
        {
            //if (chkSNByWarehouse.Checked)
            //{
            //    SetSnByWarehosueStatus(true);
            //    if (_ProductionPlanDetail != null)
            //    {
            //        if (Convert.ToInt32(seQty.Text.Replace(".", "")) > 0)
            //        {
            //            DateTime dateTime = DateTime.Now;
            //            string startCode = _ProductionPlanDetail.SkuId + "_" +
            //                               dateTime.Year.ToString().Substring(2);
            //            string endCode = _ProductionPlanDetail.SkuId + "_" +
            //                             dateTime.Year.ToString().Substring(2);

            //            int result = ServiceHelper.FacadeService.GetMaxTraceIndex(
            //                _ProductionPlanDetail.GoodsId,
            //                GetDataTime(dateTime, true),
            //                GetDataTime(dateTime, false));
            //            result++;
            //            startCode += "_" + result.ToString().PadLeft(6, '0');
            //            endCode += "_" +
            //                       (result + Convert.ToInt32(seQty.Text) - 1).ToString().PadLeft(6, '0');
            //            txtSNFrom.Text = startCode;
            //            txtSNTo.Text = endCode;
            //        }
            //    }
            //}
            //else
            //{
            //    SetSnByWarehosueStatus(false);
            //}
        }

        private void SetSnByWarehosueStatus(bool flag)
        {
            txtSNFrom.Text = "";
            txtSNTo.Text = "";
            txtBatchNumber.Text = "";
            txtBatchNumber.Enabled = flag;
        }

        private bool PrintSkuLabel()
        {
            var flag = true;

            try
            {
                var num = Convert.ToInt32(seQty.EditValue);
                if (chkSNByWarehouse.Checked)
                {

                    List<SerialNumber> numbers = Service.CreateSerialNumber(GlobalState.CurrentWarehouse.WarehouseId, _ProductionPlanDetail.ProductionPlanId, _ProductionPlanDetail.SkuId, _ProductionPlanDetail.PackId, (int)seQty.Value, GlobalState.CurrentUser.UserId);

                    if (numbers.Count != (int)seQty.Value)
                    {
                        FormHelper.ShowErrorDialog("序列号创建失败。");
                        return false;
                    }

                    SerialNumber[] snArray = numbers.ToArray();

                    txtSNFrom.Text = snArray[0].Sn;
                    txtSNTo.Text = snArray[snArray.Length - 1].Sn;

                    //DateTime dateTime = DateTime.Now;
                    //string start = txtSNFrom.Text.Trim();
                    //string end = txtSNTo.Text.Trim();
                    //string startCode = _ProductionPlanDetail.SkuId.ToString() + "_" + dateTime.Year.ToString().Substring(2);
                    //int firstNum = Convert.ToInt32(start.Substring(start.LastIndexOf("_") + 1));
                    //int lastNum = Convert.ToInt32(end.Substring(end.LastIndexOf("_") + 1));
                    SkuLabel packageNumberLable = new SkuLabel();
                    //for (var i = firstNum; i <= lastNum; i++)
                    foreach (var serialNumber in numbers)
                    {
                        //var sn = new Business.Domain.Inventory.SerialNumber();
                        //sn.WarehouseId = GlobalState.CurrentWarehouse.WarehouseId;
                        //sn.PlanId = CurrentProductionPlan.PlanId;
                        //sn.CreateTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                        //sn.CreateUser = GlobalState.CurrentUser.UserId;
                        //sn.SkuId = _ProductionPlanDetail.SkuId;
                        //sn.PackId = _ProductionPlanDetail.PackId;
                        //sn.Sn = startCode + "_" + i.ToString().PadLeft(6, '0');
                        //sn.SnIndex = i;
                        //ServiceHelper.FacadeService.Insert(out _bllResult, typeof(ProductionPlanTrace).FullName, sn);

                        string data = string.Format(SkuLabel.DataFormat, _ProductionPlanDetail.SkuNumber, _ProductionPlanDetail.SkuNumber,
                                                     _ProductionPlanDetail.SkuName, serialNumber.Sn, "", "", "", DateTime.Now.ToString("yyyy-MM-dd"));
                        packageNumberLable.AppendData(data);
                    }

                    packageNumberLable.Print();
                }
                else
                {
                    SkuLabel skuLabel = new SkuLabel();
                    for (var i = 0; i <= num - 1; i++)
                    {
                        string data = string.Format(SkuLabel.DataFormat, _ProductionPlanDetail.SkuNumber, _ProductionPlanDetail.SkuNumber,
                                 _ProductionPlanDetail.SkuName, "", "", "", "", DateTime.Now.ToString("yyyy-MM-dd"));
                        skuLabel.AppendData(data);
                    }

                    skuLabel.Print();
                }
            }
            catch (Exception exception)
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
            if (_ProductionPlanDetail != null)
            {
                var selectValue = ConvertHelper.ParseInt(leSku.EditValue);
                if (selectValue > 0)
                {
                    if (Convert.ToInt32(seQty.Text.Replace(".", "")) > 0)
                    {
                        if (PrintSkuLabel())
                        {
                            FormHelper.ShowInformationDialog("货物" + _ProductionPlanDetail.SkuNumber + "条码标签打印成功！");
                        }
                        else
                        {
                            MessageBox.Show("打印条码标签失败!");
                        }
                    }
                }
            }
        }

        private void lueProductionPlanDetail_EditValueChanged(object sender, EventArgs e)
        {
            //var selectValue = ConvertHelper.ParseInt(lueProductionPlanDetail.EditValue);
            //if (selectValue > 0)
            //{
            //    var arrayList = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
            //                                                      typeof (ProductionPlanDetail).FullName,
            //                                                      "ID = " + selectValue);
            //    if (arrayList != null && arrayList.Count > 0)
            //    {
            //        _canPrint = true;
            //        setGoodsQutity.Text = @"0";
            //        setGoodsQutity.Enabled = true;
            //        _ProductionPlanDetail = (ProductionPlanDetail)arrayList[0];
            //        SetGoodsQuentity(_ProductionPlanDetail);
            //        GetMemo(_ProductionPlanDetail.GoodsId);
            //    }
            //    else
            //    {
            //        _canPrint = false;
            //        setGoodsQutity.Text = @"0";
            //        _ProductionPlanDetail = null;
            //        setGoodsQutity.Enabled = false;
            //        medInboundDetailMemo.Text = "";
            //    }
            //}
        }

        private void chkSNByWarehouse_CheckedChanged(object sender, EventArgs e)
        {
            SetSnByWarehouse();
        }

        #endregion

        private void lueProductionPlanDetail_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //var selectValue = ConvertHelper.ParseInt(lueProductionPlanDetail.EditValue);
            //if (selectValue > 0)
            //{
            //    var arrayList = BLLHelper.facadeBL.GetByCondition(out _bllResult,
            //                                                      typeof(ProductionPlanDetail).FullName,
            //                                                      "ID = " + btnInboundSearch.Tag);
            //    if (arrayList != null && arrayList.Count > 0)
            //    {
            //        _canPrint = true;
            //        setGoodsQutity.Text = "0";
            //        setGoodsQutity.Enabled = true;
            //        _ProductionPlanDetail = (ProductionPlanDetail)arrayList[0];
            //        SetGoodsQuentity(_ProductionPlanDetail);
            //        GetMemo(_ProductionPlanDetail.GoodsID);
            //    }
            //    else
            //    {
            //        _canPrint = false;
            //        setGoodsQutity.Text = "0";
            //        _ProductionPlanDetail = null;
            //        setGoodsQutity.Enabled = false;
            //        medInboundDetailMemo.Text = "";
            //    }
            //}
        }

        private void lueProductionPlanDetail_Properties_EditValueChanged(object sender, EventArgs e)
        {
            //var selectValue = ConvertHelper.ParseInt(lueProductionPlanDetail.EditValue);
            //if (selectValue > 0)
            //{
            //    var arrayList = ServiceHelper.FacadeService.GetByCondition(out _bllResult,
            //                                                      typeof(ProductionPlanDetail).FullName,
            //                                                      "ID = " + selectValue);
            //    if (arrayList != null && arrayList.Count > 0)
            //    {
            //        _canPrint = true;
            //        setGoodsQutity.Text = "0";
            //        setGoodsQutity.Enabled = true;
            //        _ProductionPlanDetail = (ProductionPlanDetail)arrayList[0];
            //        SetGoodsQuentity(_ProductionPlanDetail);
            //        GetMemo(_ProductionPlanDetail.GoodsId);
            //    }
            //    else
            //    {
            //        _canPrint = false;
            //        setGoodsQutity.Text = "0";
            //        _ProductionPlanDetail = null;
            //        setGoodsQutity.Enabled = false;
            //        medInboundDetailMemo.Text = "";
            //    }
            //}
        }

        private void beProductionPlan_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                var listForm = new ProductionPlanListForm(FormMode.Select, false);
                listForm.Size = new Size(800, 600);
                //listForm.IsFromPrintBarCode = true;
                Form form = new Form();
                form.Text = @"选择入库计划";

                form.AutoSize = true;

                form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                form.StartPosition = FormStartPosition.CenterScreen;

                form.AutoScroll = true;
                listForm.Parent = form;
                listForm.ReferenceForm = form;
                form.ShowDialog();
                IList list = listForm.GetSelectedData<ProductionPlan>();
                if (list != null)
                {
                    var ProductionPlan = (ProductionPlan)list[0];
                    if (ProductionPlan != null)
                    {
                        beProductionPlan.Tag = ProductionPlan;
                        beProductionPlan.Text = ProductionPlan.PlanNumber;
                        //InitForm();
                        LoadPlanDetail();
                    }
                }
            }

            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                beProductionPlan.Tag = null;
                beProductionPlan.Text = "";
                leSku.Properties.DataSource = null;
                leSku.Properties.Columns.Clear();
                _canPrint = false;
                seQty.Value = 0;
                _ProductionPlanDetail = null;
                //SetGoodsQuentity(_ProductionPlanDetail);
            }
        }

        private void leSku_EditValueChanged(object sender, EventArgs e)
        {
            int skuId = (int)leSku.EditValue;
            Sku sku = ServiceHelper.SkuService.GetSkuView(skuId);
            string skuInfo = "货物代号： " + sku.SkuNumber + "\r\n"
                            + "货物名称： " + sku.SkuName + "\r\n"
                            +  "品牌： " + sku.Brand + "\r\n"
                            +  "商家货号： " + sku.ErpCode + "\r\n"
                            +  "型号： " + sku.Model + "\r\n"
                            +  "规格： " + sku.Specification + "\r\n"
                            + "备注： " + sku.Remark;
            memSkuInformation.Text = skuInfo;

            txtBatchNumber.Text = skuId.ToString() + DateTime.Now.ToString("yyyyMMdd");

            SetSkuQty(skuId);

            SetSkuPieceManagement(skuId);

            _ProductionPlanDetail = (ProductionPlanDetailView)leSku.GetSelectedDataRow();
        }

        private void SetSkuPieceManagement(int skuId)
        {
            // not piece management is default status.
            layoutBarcode.Enabled = false;
            chkSNByWarehouse.Checked = false;
            _isPieceManmagement = false;

            SkuManagement skuManagement = ServiceHelper.SkuService.GetSkuManagement(skuId);
            if (skuManagement != null)
            {
                if (skuManagement.PieceManagement)
                {
                    chkSNByWarehouse.Checked = true;
                    layoutBarcode.Enabled = true;
                    _isPieceManmagement = true;
                    return;
                }
            }
            else
            {
                CategoryManagement categoryManmagement = ServiceHelper.SkuService.GetCategoryManagement(skuId);
                if (categoryManmagement != null)
                {
                    if (categoryManmagement.PieceManagement)
                    {
                        chkSNByWarehouse.Checked = true;
                        layoutBarcode.Enabled = true;
                        _isPieceManmagement = true;
                        return;
                    }
                }
            }
        }

        private void SetSkuQty(int skuId)
        {
            foreach (ProductionPlanDetailView view in PlanDetails)
            {
                if (view.SkuId == skuId)
                {
                    seQty.Value = view.Qty - view.ReceivedQty;
                    break;
                }
            }
        }
    }
}
