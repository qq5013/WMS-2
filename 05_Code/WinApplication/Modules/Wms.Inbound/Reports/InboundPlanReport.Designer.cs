namespace Modules.InboundPlanModule.Reports
{
    partial class InboundPlanReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.pnlDetail = new DevExpress.XtraReports.UI.XRPanel();
            this.lblOtherInformationData = new DevExpress.XtraReports.UI.XRLabel();
            this.lblQtyData = new DevExpress.XtraReports.UI.XRLabel();
            this.lblModelSpecData = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSkuNumberData = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.lblOtherInformation = new DevExpress.XtraReports.UI.XRLabel();
            this.lblQty = new DevExpress.XtraReports.UI.XRLabel();
            this.lblModelSpec = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSkuName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSkuNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.lblRemark = new DevExpress.XtraReports.UI.XRLabel();
            this.lblContactInformation = new DevExpress.XtraReports.UI.XRLabel();
            this.lblOwnerName = new DevExpress.XtraReports.UI.XRLabel();
            this.barBillNumber = new DevExpress.XtraReports.UI.XRBarCode();
            this.lblBillType = new DevExpress.XtraReports.UI.XRLabel();
            this.lblWarehouseName = new DevExpress.XtraReports.UI.XRLabel();
            this.pagPageInfo = new DevExpress.XtraReports.UI.XRPageInfo();
            this.lblCompanyName = new DevExpress.XtraReports.UI.XRLabel();
            this.linePageHeader = new DevExpress.XtraReports.UI.XRLine();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.lblDeliveryTime = new DevExpress.XtraReports.UI.XRLabel();
            this.lineDeliveryTime = new DevExpress.XtraReports.UI.XRLine();
            this.lblPrintTime = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPrintOperator = new DevExpress.XtraReports.UI.XRLabel();
            this.lineReceiveTime = new DevExpress.XtraReports.UI.XRLine();
            this.lblReceiveTime = new DevExpress.XtraReports.UI.XRLabel();
            this.lineReceiver = new DevExpress.XtraReports.UI.XRLine();
            this.lblReceiver = new DevExpress.XtraReports.UI.XRLabel();
            this.lineDeliveryMan = new DevExpress.XtraReports.UI.XRLine();
            this.lblDeliveryMan = new DevExpress.XtraReports.UI.XRLabel();
            this.linePageFooter = new DevExpress.XtraReports.UI.XRLine();
            this.lblOwnerNameData = new DevExpress.XtraReports.UI.XRLabel();
            this.lblContactInformationData = new DevExpress.XtraReports.UI.XRLabel();
            this.lblRemarkData = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPrintOperatorData = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPrintTimeData = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.pnlDetail});
            this.Detail.HeightF = 73.95834F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine2
            // 
            this.xrLine2.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(22.5F, 55F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(717.5F, 2.08F);
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblOtherInformationData,
            this.lblQtyData,
            this.lblModelSpecData,
            this.xrLabel1,
            this.lblSkuNumberData});
            this.pnlDetail.LocationFloat = new DevExpress.Utils.PointFloat(22.50001F, 0F);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.SizeF = new System.Drawing.SizeF(717.5F, 50F);
            // 
            // lblOtherInformationData
            // 
            this.lblOtherInformationData.LocationFloat = new DevExpress.Utils.PointFloat(568.125F, 0F);
            this.lblOtherInformationData.Name = "lblOtherInformationData";
            this.lblOtherInformationData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblOtherInformationData.SizeF = new System.Drawing.SizeF(149.3748F, 45.99998F);
            this.lblOtherInformationData.StylePriority.UseTextAlignment = false;
            this.lblOtherInformationData.Text = "[OtherInformation]";
            this.lblOtherInformationData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lblQtyData
            // 
            this.lblQtyData.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtyData.LocationFloat = new DevExpress.Utils.PointFloat(502.5F, 22.99999F);
            this.lblQtyData.Name = "lblQtyData";
            this.lblQtyData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblQtyData.SizeF = new System.Drawing.SizeF(65.625F, 23F);
            this.lblQtyData.StylePriority.UseFont = false;
            this.lblQtyData.StylePriority.UseTextAlignment = false;
            this.lblQtyData.Text = "[Qty]";
            this.lblQtyData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblModelSpecData
            // 
            this.lblModelSpecData.LocationFloat = new DevExpress.Utils.PointFloat(352.9164F, 0F);
            this.lblModelSpecData.Name = "lblModelSpecData";
            this.lblModelSpecData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblModelSpecData.SizeF = new System.Drawing.SizeF(215.2086F, 23F);
            this.lblModelSpecData.StylePriority.UseTextAlignment = false;
            this.lblModelSpecData.Text = "[ModelSpec]";
            this.lblModelSpecData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 22.99999F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(502.4999F, 23F);
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "[SkuName]";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblSkuNumberData
            // 
            this.lblSkuNumberData.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkuNumberData.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lblSkuNumberData.Name = "lblSkuNumberData";
            this.lblSkuNumberData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSkuNumberData.SizeF = new System.Drawing.SizeF(354.5834F, 23F);
            this.lblSkuNumberData.StylePriority.UseFont = false;
            this.lblSkuNumberData.StylePriority.UseTextAlignment = false;
            this.lblSkuNumberData.Text = "[SkuNumber]";
            this.lblSkuNumberData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 30F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 32.99999F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblRemarkData,
            this.lblContactInformationData,
            this.lblOwnerNameData,
            this.lblOtherInformation,
            this.lblQty,
            this.lblModelSpec,
            this.lblSkuName,
            this.lblSkuNumber,
            this.xrLine1,
            this.lblRemark,
            this.lblContactInformation,
            this.lblOwnerName,
            this.barBillNumber,
            this.lblBillType,
            this.lblWarehouseName,
            this.pagPageInfo,
            this.lblCompanyName,
            this.linePageHeader});
            this.PageHeader.HeightF = 240F;
            this.PageHeader.Name = "PageHeader";
            // 
            // lblOtherInformation
            // 
            this.lblOtherInformation.LocationFloat = new DevExpress.Utils.PointFloat(590.625F, 204.9167F);
            this.lblOtherInformation.Name = "lblOtherInformation";
            this.lblOtherInformation.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblOtherInformation.SizeF = new System.Drawing.SizeF(149.3749F, 23F);
            this.lblOtherInformation.StylePriority.UseTextAlignment = false;
            this.lblOtherInformation.Text = "其它信息";
            this.lblOtherInformation.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblQty
            // 
            this.lblQty.LocationFloat = new DevExpress.Utils.PointFloat(525F, 204.9167F);
            this.lblQty.Name = "lblQty";
            this.lblQty.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblQty.SizeF = new System.Drawing.SizeF(65.625F, 23F);
            this.lblQty.StylePriority.UseTextAlignment = false;
            this.lblQty.Text = "数量";
            this.lblQty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblModelSpec
            // 
            this.lblModelSpec.LocationFloat = new DevExpress.Utils.PointFloat(377.0833F, 204.9167F);
            this.lblModelSpec.Name = "lblModelSpec";
            this.lblModelSpec.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblModelSpec.SizeF = new System.Drawing.SizeF(147.9166F, 23F);
            this.lblModelSpec.StylePriority.UseTextAlignment = false;
            this.lblModelSpec.Text = "规格型号";
            this.lblModelSpec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblSkuName
            // 
            this.lblSkuName.LocationFloat = new DevExpress.Utils.PointFloat(123.9583F, 204.9167F);
            this.lblSkuName.Name = "lblSkuName";
            this.lblSkuName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSkuName.SizeF = new System.Drawing.SizeF(253.125F, 23F);
            this.lblSkuName.StylePriority.UseTextAlignment = false;
            this.lblSkuName.Text = "货物名称";
            this.lblSkuName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblSkuNumber
            // 
            this.lblSkuNumber.LocationFloat = new DevExpress.Utils.PointFloat(22.50001F, 204.9167F);
            this.lblSkuNumber.Name = "lblSkuNumber";
            this.lblSkuNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSkuNumber.SizeF = new System.Drawing.SizeF(101.4583F, 23F);
            this.lblSkuNumber.StylePriority.UseTextAlignment = false;
            this.lblSkuNumber.Text = "货物代码";
            this.lblSkuNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(22.50001F, 227.9167F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(717.4999F, 2.083298F);
            // 
            // lblRemark
            // 
            this.lblRemark.LocationFloat = new DevExpress.Utils.PointFloat(22.50001F, 152.9583F);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblRemark.SizeF = new System.Drawing.SizeF(55.62498F, 37.04172F);
            this.lblRemark.StylePriority.UseTextAlignment = false;
            this.lblRemark.Text = "备注：";
            this.lblRemark.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblContactInformation
            // 
            this.lblContactInformation.LocationFloat = new DevExpress.Utils.PointFloat(349.375F, 129.9583F);
            this.lblContactInformation.Name = "lblContactInformation";
            this.lblContactInformation.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblContactInformation.SizeF = new System.Drawing.SizeF(78.12503F, 23F);
            this.lblContactInformation.StylePriority.UseTextAlignment = false;
            this.lblContactInformation.Text = "联系人：";
            this.lblContactInformation.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblOwnerName
            // 
            this.lblOwnerName.LocationFloat = new DevExpress.Utils.PointFloat(22.50001F, 129.9583F);
            this.lblOwnerName.Name = "lblOwnerName";
            this.lblOwnerName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblOwnerName.SizeF = new System.Drawing.SizeF(55.62499F, 23F);
            this.lblOwnerName.StylePriority.UseTextAlignment = false;
            this.lblOwnerName.Text = "商家：";
            this.lblOwnerName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // barBillNumber
            // 
            this.barBillNumber.Font = new System.Drawing.Font("Times New Roman", 16F);
            this.barBillNumber.LocationFloat = new DevExpress.Utils.PointFloat(427.5F, 49.95832F);
            this.barBillNumber.Name = "barBillNumber";
            this.barBillNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.barBillNumber.SizeF = new System.Drawing.SizeF(312.5001F, 79.99998F);
            this.barBillNumber.StylePriority.UseFont = false;
            this.barBillNumber.StylePriority.UseTextAlignment = false;
            this.barBillNumber.Symbology = code128Generator1;
            this.barBillNumber.Text = "IPSH00001J";
            this.barBillNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblBillType
            // 
            this.lblBillType.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillType.LocationFloat = new DevExpress.Utils.PointFloat(437.5F, 37.45834F);
            this.lblBillType.Name = "lblBillType";
            this.lblBillType.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblBillType.SizeF = new System.Drawing.SizeF(153.125F, 23F);
            this.lblBillType.StylePriority.UseFont = false;
            this.lblBillType.StylePriority.UseTextAlignment = false;
            this.lblBillType.Text = "入库计划 - 采购入库";
            this.lblBillType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblWarehouseName
            // 
            this.lblWarehouseName.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWarehouseName.LocationFloat = new DevExpress.Utils.PointFloat(22.50001F, 37.45834F);
            this.lblWarehouseName.Name = "lblWarehouseName";
            this.lblWarehouseName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblWarehouseName.SizeF = new System.Drawing.SizeF(271.25F, 79.99999F);
            this.lblWarehouseName.StylePriority.UseFont = false;
            this.lblWarehouseName.StylePriority.UseTextAlignment = false;
            this.lblWarehouseName.Text = "上海仓";
            this.lblWarehouseName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // pagPageInfo
            // 
            this.pagPageInfo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagPageInfo.LocationFloat = new DevExpress.Utils.PointFloat(640F, 0F);
            this.pagPageInfo.Name = "pagPageInfo";
            this.pagPageInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.pagPageInfo.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.pagPageInfo.StylePriority.UseFont = false;
            this.pagPageInfo.StylePriority.UseTextAlignment = false;
            this.pagPageInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.LocationFloat = new DevExpress.Utils.PointFloat(22.50001F, 1.999998F);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCompanyName.SizeF = new System.Drawing.SizeF(271.25F, 23F);
            this.lblCompanyName.StylePriority.UseTextAlignment = false;
            this.lblCompanyName.Text = "XX物流有限公司";
            this.lblCompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // linePageHeader
            // 
            this.linePageHeader.LineWidth = 2;
            this.linePageHeader.LocationFloat = new DevExpress.Utils.PointFloat(0F, 22.91667F);
            this.linePageHeader.Name = "linePageHeader";
            this.linePageHeader.SizeF = new System.Drawing.SizeF(750F, 2.083334F);
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblPrintTimeData,
            this.lblPrintOperatorData,
            this.lblDeliveryTime,
            this.lineDeliveryTime,
            this.lblPrintTime,
            this.lblPrintOperator,
            this.lineReceiveTime,
            this.lblReceiveTime,
            this.lineReceiver,
            this.lblReceiver,
            this.lineDeliveryMan,
            this.lblDeliveryMan,
            this.linePageFooter});
            this.PageFooter.HeightF = 125.125F;
            this.PageFooter.Name = "PageFooter";
            // 
            // lblDeliveryTime
            // 
            this.lblDeliveryTime.LocationFloat = new DevExpress.Utils.PointFloat(22.50001F, 56.20829F);
            this.lblDeliveryTime.Name = "lblDeliveryTime";
            this.lblDeliveryTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDeliveryTime.SizeF = new System.Drawing.SizeF(121.875F, 23F);
            this.lblDeliveryTime.StylePriority.UseTextAlignment = false;
            this.lblDeliveryTime.Text = "送货时间：";
            this.lblDeliveryTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lineDeliveryTime
            // 
            this.lineDeliveryTime.LocationFloat = new DevExpress.Utils.PointFloat(144.375F, 66.62496F);
            this.lineDeliveryTime.Name = "lineDeliveryTime";
            this.lineDeliveryTime.SizeF = new System.Drawing.SizeF(206.25F, 23F);
            // 
            // lblPrintTime
            // 
            this.lblPrintTime.LocationFloat = new DevExpress.Utils.PointFloat(421.8749F, 92.125F);
            this.lblPrintTime.Name = "lblPrintTime";
            this.lblPrintTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPrintTime.SizeF = new System.Drawing.SizeF(121.8751F, 23.00001F);
            this.lblPrintTime.StylePriority.UseFont = false;
            this.lblPrintTime.StylePriority.UseTextAlignment = false;
            this.lblPrintTime.Text = "打印时间： ";
            this.lblPrintTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblPrintOperator
            // 
            this.lblPrintOperator.LocationFloat = new DevExpress.Utils.PointFloat(22.50001F, 92.125F);
            this.lblPrintOperator.Name = "lblPrintOperator";
            this.lblPrintOperator.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPrintOperator.SizeF = new System.Drawing.SizeF(121.875F, 23.00001F);
            this.lblPrintOperator.StylePriority.UseTextAlignment = false;
            this.lblPrintOperator.Text = "打印操作员：";
            this.lblPrintOperator.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lineReceiveTime
            // 
            this.lineReceiveTime.LocationFloat = new DevExpress.Utils.PointFloat(543.75F, 66.62496F);
            this.lineReceiveTime.Name = "lineReceiveTime";
            this.lineReceiveTime.SizeF = new System.Drawing.SizeF(206.25F, 23F);
            // 
            // lblReceiveTime
            // 
            this.lblReceiveTime.LocationFloat = new DevExpress.Utils.PointFloat(421.875F, 56.20829F);
            this.lblReceiveTime.Name = "lblReceiveTime";
            this.lblReceiveTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblReceiveTime.SizeF = new System.Drawing.SizeF(121.875F, 23F);
            this.lblReceiveTime.StylePriority.UseTextAlignment = false;
            this.lblReceiveTime.Text = "收货时间：";
            this.lblReceiveTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lineReceiver
            // 
            this.lineReceiver.LocationFloat = new DevExpress.Utils.PointFloat(543.75F, 35.37502F);
            this.lineReceiver.Name = "lineReceiver";
            this.lineReceiver.SizeF = new System.Drawing.SizeF(206.25F, 23F);
            // 
            // lblReceiver
            // 
            this.lblReceiver.LocationFloat = new DevExpress.Utils.PointFloat(421.875F, 24.95836F);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblReceiver.SizeF = new System.Drawing.SizeF(121.875F, 23F);
            this.lblReceiver.StylePriority.UseTextAlignment = false;
            this.lblReceiver.Text = "收货人签名(章)：";
            this.lblReceiver.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lineDeliveryMan
            // 
            this.lineDeliveryMan.LocationFloat = new DevExpress.Utils.PointFloat(144.375F, 35.37502F);
            this.lineDeliveryMan.Name = "lineDeliveryMan";
            this.lineDeliveryMan.SizeF = new System.Drawing.SizeF(206.25F, 23F);
            // 
            // lblDeliveryMan
            // 
            this.lblDeliveryMan.LocationFloat = new DevExpress.Utils.PointFloat(22.50001F, 24.95836F);
            this.lblDeliveryMan.Name = "lblDeliveryMan";
            this.lblDeliveryMan.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDeliveryMan.SizeF = new System.Drawing.SizeF(121.875F, 23F);
            this.lblDeliveryMan.StylePriority.UseTextAlignment = false;
            this.lblDeliveryMan.Text = "送货人签名(章)：";
            this.lblDeliveryMan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // linePageFooter
            // 
            this.linePageFooter.LineWidth = 2;
            this.linePageFooter.LocationFloat = new DevExpress.Utils.PointFloat(0F, 9.999974F);
            this.linePageFooter.Name = "linePageFooter";
            this.linePageFooter.SizeF = new System.Drawing.SizeF(750F, 2.083334F);
            // 
            // lblOwnerNameData
            // 
            this.lblOwnerNameData.LocationFloat = new DevExpress.Utils.PointFloat(78.125F, 129.9583F);
            this.lblOwnerNameData.Name = "lblOwnerNameData";
            this.lblOwnerNameData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblOwnerNameData.SizeF = new System.Drawing.SizeF(271.25F, 23F);
            this.lblOwnerNameData.StylePriority.UseTextAlignment = false;
            this.lblOwnerNameData.Text = "XX有限公司";
            this.lblOwnerNameData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblContactInformationData
            // 
            this.lblContactInformationData.LocationFloat = new DevExpress.Utils.PointFloat(427.5F, 129.9583F);
            this.lblContactInformationData.Name = "lblContactInformationData";
            this.lblContactInformationData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblContactInformationData.SizeF = new System.Drawing.SizeF(312.4997F, 23F);
            this.lblContactInformationData.StylePriority.UseTextAlignment = false;
            this.lblContactInformationData.Text = "张三   021-345335462";
            this.lblContactInformationData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblRemarkData
            // 
            this.lblRemarkData.LocationFloat = new DevExpress.Utils.PointFloat(78.125F, 152.9583F);
            this.lblRemarkData.Name = "lblRemarkData";
            this.lblRemarkData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblRemarkData.SizeF = new System.Drawing.SizeF(661.8747F, 37.04172F);
            this.lblRemarkData.StylePriority.UseTextAlignment = false;
            this.lblRemarkData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblPrintOperatorData
            // 
            this.lblPrintOperatorData.LocationFloat = new DevExpress.Utils.PointFloat(143.125F, 92.125F);
            this.lblPrintOperatorData.Name = "lblPrintOperatorData";
            this.lblPrintOperatorData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPrintOperatorData.SizeF = new System.Drawing.SizeF(206.25F, 23.00001F);
            this.lblPrintOperatorData.StylePriority.UseTextAlignment = false;
            this.lblPrintOperatorData.Text = "张宏志";
            this.lblPrintOperatorData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblPrintTimeData
            // 
            this.lblPrintTimeData.LocationFloat = new DevExpress.Utils.PointFloat(543.75F, 92.125F);
            this.lblPrintTimeData.Name = "lblPrintTimeData";
            this.lblPrintTimeData.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPrintTimeData.SizeF = new System.Drawing.SizeF(206.25F, 23.00001F);
            this.lblPrintTimeData.StylePriority.UseFont = false;
            this.lblPrintTimeData.StylePriority.UseTextAlignment = false;
            this.lblPrintTimeData.Text = "2013-05-13 10:12:21";
            this.lblPrintTimeData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // InboundPlanReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(50, 50, 30, 33);
            this.Version = "12.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo pagPageInfo;
        private DevExpress.XtraReports.UI.XRLine linePageHeader;
        private DevExpress.XtraReports.UI.XRLine linePageFooter;
        private DevExpress.XtraReports.UI.XRLabel lblDeliveryMan;
        private DevExpress.XtraReports.UI.XRLine lineDeliveryMan;
        private DevExpress.XtraReports.UI.XRLine lineReceiver;
        private DevExpress.XtraReports.UI.XRLabel lblReceiver;
        private DevExpress.XtraReports.UI.XRLine lineReceiveTime;
        private DevExpress.XtraReports.UI.XRLabel lblReceiveTime;
        private DevExpress.XtraReports.UI.XRLabel lblPrintTime;
        private DevExpress.XtraReports.UI.XRLabel lblPrintOperator;
        private DevExpress.XtraReports.UI.XRLabel lblRemark;
        private DevExpress.XtraReports.UI.XRLabel lblContactInformation;
        private DevExpress.XtraReports.UI.XRLabel lblDeliveryTime;
        private DevExpress.XtraReports.UI.XRLine lineDeliveryTime;
        private DevExpress.XtraReports.UI.XRLabel lblSkuNumber;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel lblOtherInformation;
        private DevExpress.XtraReports.UI.XRLabel lblQty;
        private DevExpress.XtraReports.UI.XRLabel lblModelSpec;
        private DevExpress.XtraReports.UI.XRLabel lblSkuName;
        private DevExpress.XtraReports.UI.XRPanel pnlDetail;
        private DevExpress.XtraReports.UI.XRLabel lblOtherInformationData;
        private DevExpress.XtraReports.UI.XRLabel lblQtyData;
        private DevExpress.XtraReports.UI.XRLabel lblModelSpecData;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel lblSkuNumberData;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        public DevExpress.XtraReports.UI.XRLabel lblRemarkData;
        public DevExpress.XtraReports.UI.XRLabel lblContactInformationData;
        public DevExpress.XtraReports.UI.XRLabel lblOwnerNameData;
        public DevExpress.XtraReports.UI.XRLabel lblCompanyName;
        public DevExpress.XtraReports.UI.XRLabel lblWarehouseName;
        public DevExpress.XtraReports.UI.XRBarCode barBillNumber;
        public DevExpress.XtraReports.UI.XRLabel lblBillType;
        private DevExpress.XtraReports.UI.XRLabel lblOwnerName;
        public DevExpress.XtraReports.UI.XRLabel lblPrintOperatorData;
        public DevExpress.XtraReports.UI.XRLabel lblPrintTimeData;
    }
}
