

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Frame.Utils.Service;
using MES.BllService;
using MES.Entity;
using MES.Execute.Common;
using MES.Execute.Properties;

namespace MES.Execute.Controls
{
    /// <summary>
    /// 销售订单编辑
    /// </summary>
    public partial class UcSalesOrder : UserControl, IInitControl, ICheckClosing
    {
        /// <summary>
        /// 销售订单
        /// </summary>
        public UcSalesOrder()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 销售订单
        /// </summary>
        public SalesOrder Data { get; set; }

        /// <summary>
        /// 销售订单明细Service
        /// </summary>
        private IEntityService<SalesOrderDetail> SalesOrderDetailService
        {
            get { return ServiceHelper.GetService<SalesOrderDetail>(); }
        }

        /// <summary>
        /// 销售订单Service
        /// </summary>
        private IEntityService<SalesOrder> SalesOrderService
        {
            get { return ServiceHelper.GetService<SalesOrder>(); }
        }

        #region ICheckClosing Members

        /// <summary>
        /// 数据变更
        /// </summary>
        public bool DataChanged { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            gridControl1.MainView.PostEditor();

            if (!Validation())
                return false;

            Data.LoadData(Controls);
            int salesOrderId = SalesOrderService.Save(Data);
            if (Data.SalesOrderId == 0)
            {
                Data.SalesOrderId = salesOrderId;
            }
            // 删除控件删除的数据
            foreach (SalesOrderDetail detail in Data.RemoveList)
            {
                if (detail.GetEntityId() > 0)
                    detail.Remove();
            }
            Data.RemoveList.Clear();

            // 保存明细
            foreach (SalesOrderDetail detail in Data.Details)
            {
                detail.SalesOrderId = Data.SalesOrderId;


                int salesOrderDetailId = SalesOrderDetailService.Save(detail);
                if (detail.SalesOrderDetailId == 0)
                    detail.SalesOrderDetailId = salesOrderDetailId;
            }
            DataChanged = false;
            return true;
        }

        #endregion

        #region IInitControl Members

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            barManager2.Form = groupControl1;
            glueCustomer.BindCustomer(ControlMode.Edit);
            glueOperator.BindUser(ControlMode.Edit, new List<string> {"sales"});
            glueCreater.BindUser(ControlMode.Edit, null);
            glueCreater.EditValue = CommonApi.CurrentUser().UserId;
            deCreateTime.EditValue = DateTimeHelper.Now;

            deOrderDate.EditValue = DateTimeHelper.Now;

            gluePayment.BindPayment(ControlMode.Edit);
            glueShipVia.BindShipVia(ControlMode.Edit);
            riglueMeasure.BindMeasure();
            CommonApi.BindSku(riglueSkuCategoryName, riglueSkuName, riglueSkuCode, riglueSkuSpec, riglueSkuModel,
                              riglueSkuColor, false);

            if (Data != null)
            {
                teCode.Properties.ReadOnly = true;
                Data.FillData(Controls);

                // 如果已经审核则不能再修改
                if (Data.Status != SalesOrderStatus.Created)
                {
                    foreach (object control in Controls)
                    {
                        if (control is GridLookUpEdit)
                        {
                            ((GridLookUpEdit) control).Properties.ReadOnly = true;
                        }
                        else if (control is TextEdit)
                        {
                            ((TextEdit) control).Properties.ReadOnly = true;
                        }
                        else if (control is CheckEdit)
                        {
                            ((CheckEdit) control).Properties.ReadOnly = true;
                        }
                    }
                    bandedGridView1.OptionsBehavior.ReadOnly = true;
                    btnSave.Enabled = false;
                    btnAdd.Enabled = false;
                    btnRemove.Enabled = false;
                    //barButtonItem1.Enabled = false;
                }

                List<SalesOrderDetail> salesOrderDetails =
                    ServiceHelper.GetService<SalesOrderDetail>().FindAll(c => c.SalesOrderId == Data.SalesOrderId,
                                                                         null);
                Data.Details.Clear();
                Data.Details.AddRange(salesOrderDetails);
                BindDetail();
            }
            else
            {
                Reset();
                DataChanged = true;
            }

            // 添加事件，数据变更后有记录
            riglueMeasure.EditValueChanged += (sender, e) => { DataChanged = true; };
            riseUnitPrice.EditValueChanged += (sender, e) => { DataChanged = true; };
            riseQuantity.EditValueChanged += (sender, e) => { DataChanged = true; };


            glueCreater.EditValueChanged += (sender, e) => { DataChanged = true; };
            glueCustomer.EditValueChanged += (sender, e) => { DataChanged = true; };
            glueOperator.EditValueChanged += (sender, e) => { DataChanged = true; };
            gluePayment.EditValueChanged += (sender, e) => { DataChanged = true; };
            glueShipVia.EditValueChanged += (sender, e) => { DataChanged = true; };

            teBargainNo.EditValueChanged += (sender, e) => { DataChanged = true; };
            teCode.EditValueChanged += (sender, e) => { DataChanged = true; };
            teContractWay.EditValueChanged += (sender, e) => { DataChanged = true; };
            teDeliveryAddress.EditValueChanged += (sender, e) => { DataChanged = true; };
            teOrderContract.EditValueChanged += (sender, e) => { DataChanged = true; };
            teTopicNumber.EditValueChanged += (sender, e) => { DataChanged = true; };

            seAmount.EditValueChanged += (sender, e) => { DataChanged = true; };

            deCreateTime.EditValueChanged += (sender, e) => { DataChanged = true; };
            deDeliveryDate.EditValueChanged += (sender, e) => { DataChanged = true; };
            meRemark.EditValueChanged += (sender, e) => { DataChanged = true; };

            riseUnitPrice.ValueChanged += RisePriceEditValueChanged;
            riseQuantity.ValueChanged += RisePriceEditValueChanged;
        }

        #endregion

        /// <summary>
        /// 价格变更修改总价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RisePriceEditValueChanged(object sender, EventArgs e)
        {
            gridControl1.MainView.PostEditor();
            seAmount.EditValue = Data.Details.Sum(c => c.Amount);
        }

        /// <summary>
        /// 重置
        /// </summary>
        private void Reset()
        {
            Data = new SalesOrder
                       {
                           CreaterId = CommonApi.CurrentUser().UserId,
                           OrderDate = DateTimeHelper.Now,
                           DeliveryDate = DateTimeHelper.Min,
                           CreateTime = DateTimeHelper.Now,
                           Status = SalesOrderStatus.Created
                       };
            teCode.Text = CommonApi.GetCode<SalesOrder>();
            teCode.Properties.ReadOnly = true;
            Data.FillData(Controls);
            BindDetail();
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcSalesOrder_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelItemClick(object sender, ItemClickEventArgs e)
        {
            DoClose();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void DoClose()
        {
            if (ParentForm != null) ParentForm.Close();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveItemClick(object sender, ItemClickEventArgs e)
        {
            if (!Save()) return;
            if (
                MessageBox.Show(Resources.SaveSuccessQuestion, Resources.Notice, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                DoClose();
            }
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        private bool Validation()
        {
            bool isValidated = true;
            dxErrorProvider1.ClearErrors();
            // 客户名称不能为空
            if (glueCustomer.EditValue == null)
            {
                dxErrorProvider1.SetError(glueCustomer, "请选择客户名称");
                isValidated = false;
            }
            if (deDeliveryDate.EditValue == null)
            {
                dxErrorProvider1.SetError(deDeliveryDate, "交货日期不能为空");
                isValidated = false;
            }
            if (teDeliveryAddress.EditValue == null || teDeliveryAddress.EditValue.ToString() == string.Empty)
            {
                dxErrorProvider1.SetError(teDeliveryAddress, "交货地址不能为空");
                isValidated = false;
            }

            if (meRemark.EditValue != null && meRemark.EditValue.ToString().Length > 200)
            {
                dxErrorProvider1.SetError(meRemark, "备注内容超过200字");
                isValidated = false;
            }

            return isValidated;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddItemClick(object sender, ItemClickEventArgs e)
        {
            
            var ucSelectSku = new UcSelectSku {CallBack = ImportCode, IsMateriel = false};
            ucSelectSku.Init();

            // 打开对话框添加物料
            new Form
                {
                    Controls = {ucSelectSku},
                    Size = new Size(700, 280),
                    Text = Resources.AddProduct
                }.Dialog();
        }

        /// <summary>
        /// 录入条码
        /// </summary>
        /// <param name="skuinfo"></param>
        /// <param name="barcode"></param>
        /// <param name="lotno"></param>
        /// <param name="measureid"></param>
        /// <param name="quantity"></param>
        /// <param name="showerror"></param>
        private void ImportCode(SkuInfo skuinfo, string barcode, string lotno, int measureid, int quantity,
                                ShowError showerror)
        {
            SalesOrderDetail salesOrderDetail = Data.Details.Find(c => c.SkuId == skuinfo.SkuId);

            // 如果明细中有此物料则添加
            if (salesOrderDetail != null)
            {
                salesOrderDetail.Quantity += quantity;
            }
            else
            {
                // 如果明细中没有则新建
                salesOrderDetail = new SalesOrderDetail
                                       {SkuId = skuinfo.SkuId, Quantity = quantity, MeasureId = measureid};
                Data.Details.Insert(0, salesOrderDetail);
            }

            // 统计总数
            seAmount.EditValue = Data.Details.Sum(c => c.Amount);
            BindDetail();
            DataChanged = true;
        }

        /// <summary>
        /// 绑定明细
        /// </summary>
        private void BindDetail()
        {
            gridControl1.DataSource = null;
            gridControl1.DataSource = Data.Details;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveItemClick(object sender, ItemClickEventArgs e)
        {
            int[] selectedRows = bandedGridView1.GetSelectedRows();
            if (selectedRows != null && selectedRows.Length > 0)
            {
                List<SalesOrderDetail> list =
                    selectedRows.Select(selectedRow => bandedGridView1.GetRow(selectedRow) as SalesOrderDetail).ToList();
                // 将选中的明细加入删除列表
                foreach (SalesOrderDetail detail in list)
                {
                    Data.RemoveList.Add(detail);
                    Data.Details.Remove(detail);
                }
                seAmount.EditValue = Data.Details.Sum(c => c.Amount);
                BindDetail();
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrintItemClick(object sender, ItemClickEventArgs e)
        {
            if (Data == null)
            {
                return;
            }
            gridControl1.MainView.PostEditor();
            Data.LoadData(Controls);
            Data.GetReport().ShowPrint();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExportItemClick(object sender, ItemClickEventArgs e)
        {
            if (Data == null)
            {
                return;
            }
            gridControl1.MainView.PostEditor();
            Data.LoadData(Controls);
            Data.GetReport().Export("销售订单" + Data.Code);
        }
    }
}