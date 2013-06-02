using System;
using System.Windows.Forms;
using Module.ReceiveGoodsModule.Views;
using ecWMS.Business.Entity;
using System.Collections;
using ecWMS.Common;
using ecWMS.Business.Common;

namespace Modules.InboundBillModule.Views
{
    public partial class MatchForm : Form
    {
        public InboundPlan CurrentInboundPlan;
        public InboundBill CurrentInboundBill;
        public ArrayList InboundPlanMatchList;

        public MatchForm()
        {
            InitializeComponent();
        }

        private void MatchForm_Load(object sender, EventArgs e)
        {
            if (CurrentInboundBill == null) return;
            BllResult bllResult;
            CurrentInboundPlan = GenericServiceHelper.Get<InboundPlan>(out bllResult, CurrentInboundBill.InboundPlanId);
            if (CurrentInboundPlan == null) return;

            CopyMatchInfo();
            CalcMatchInfo();
            BindMatchInfo();
        }

        private void CopyMatchInfo()
        {
            BllResult bllResult;
            InboundPlanMatchList = new ArrayList();
            ArrayList receivePlanDetailList = GenericServiceHelper.GetListByCondition<InboundPlanDetail>(out bllResult, "InboundPlanID = " + CurrentInboundPlan.InboundPlanId.ToString());
            foreach (InboundPlanDetail planDetail in receivePlanDetailList)
            {
                InboundPlanDetailMatch match = new InboundPlanDetailMatch();
                match.GoodsId = planDetail.GoodsId;
                match.GoodsCode = planDetail.GoodsCode;
                match.GoodsName = planDetail.GoodsName;
                match.GoodsPacket = planDetail.GoodsPacket;
                match.GoodsQty = planDetail.GoodsQty;
                match.ReceivedGoodsQty = planDetail.ReceivedGoodsQty;
                match.Property1 = planDetail.Property1;
                match.Property2 = planDetail.Property2;
                match.Property3 = planDetail.Property3;
                match.CurrentReceivedQty = 0;
                match.LeftQty = planDetail.GoodsQty - planDetail.ReceivedGoodsQty;
                match.ReceivedVolume = 0;
                match.CurrentReceivedVolume = 0;
                match.LeftVolume = planDetail.Volume;
                match.ReceivedWeight = 0;
                match.CurrentReceivedWeight = 0;
                match.LeftWeight = planDetail.Weight;

                InboundPlanMatchList.Add(match);
            }
        }

        private void CalcMatchInfo()
        {
            BllResult bllResult;
            ArrayList receiveGoodsDetailList = GenericServiceHelper.GetListByCondition<InboundBillDetail>(out bllResult, "InboundBillID = " + CurrentInboundBill.InboundBillId);
            foreach (InboundBillDetail goodsList in receiveGoodsDetailList)
            {
                foreach (InboundPlanDetailMatch match in InboundPlanMatchList)
                {
                    if (goodsList.GoodsId == match.GoodsId && goodsList.GoodsPacket == match.GoodsPacket
                        && goodsList.Property1 == match.Property1 
                        && goodsList.Property2 == match.Property2 
                        && goodsList.Property3 == match.Property3)
                    {
                        match.CurrentReceivedQty = match.CurrentReceivedQty + goodsList.GoodsQty;
                        match.LeftQty = match.LeftQty - goodsList.GoodsQty;
                        match.ReceivedVolume = 0;
                        match.CurrentReceivedVolume = 0;
                        match.LeftVolume = 0;
                        match.ReceivedWeight = 0;
                        match.CurrentReceivedWeight = 0;
                        match.LeftWeight = 0;
                    }
                }
            }

            foreach (InboundPlanDetailMatch match1 in InboundPlanMatchList)
            {
                if (match1.LeftQty != 0)
                    match1.IsNotOK = true;
            }
        }

        private void BindMatchInfo()
        {
            MainGrid.DataSource = null;
            if (InboundPlanMatchList != null && InboundPlanMatchList.Count > 0)
            {
                //为了取出数据后仍饱含全部的数据，不显示列的只是隐藏掉，此功能未作
                MainGrid.DataSource = InboundPlanMatchList;
                MainGrid.MainView.PopulateColumns();

                CustomizeGrid();
            }
        }

        private void CustomizeGrid()
        {
            #region gridview columns...
            string tipa = GlobalState.LanguageHelper.GetLanguageString("MatchSOForm", "caption_IsNotOK");
            MainGridView.Columns["IsNotOK"].Caption = tipa;
            MainGridView.Columns["IsNotOK"].Width = 70;
            MainGridView.Columns["IsNotOK"].VisibleIndex = 0;
            MainGridView.Columns["IsNotOK"].Visible = true;

            tipa = GlobalState.LanguageHelper.GetLanguageString("ReceivePlanForm", "caption_GoodsCode");
            MainGridView.Columns["GoodsCode"].Caption = tipa;
            MainGridView.Columns["GoodsCode"].Width = 70;
            MainGridView.Columns["GoodsCode"].VisibleIndex = 1;
            MainGridView.Columns["GoodsCode"].Visible = true;

            tipa = GlobalState.LanguageHelper.GetLanguageString("ReceivePlanForm", "caption_GoodsName");
            MainGridView.Columns["GoodsName"].Caption = tipa;
            MainGridView.Columns["GoodsName"].Width = 70;
            MainGridView.Columns["GoodsName"].VisibleIndex = 2;
            MainGridView.Columns["GoodsName"].Visible = true;

            tipa = GlobalState.LanguageHelper.GetLanguageString("ReceivePlanForm", "caption_GoodsPacket");
            MainGridView.Columns["GoodsPacket"].Caption = tipa;
            MainGridView.Columns["GoodsPacket"].Width = 70;
            MainGridView.Columns["GoodsPacket"].VisibleIndex = 3;
            MainGridView.Columns["GoodsPacket"].Visible = true;

            var goodsPacketLookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            goodsPacketLookup.DataSource = BusinessKit.GetAllPacket();
            goodsPacketLookup.DisplayMember = "PacketName";
            goodsPacketLookup.ValueMember = "PacketId";
            MainGridView.Columns["GoodsPacket"].ColumnEdit = goodsPacketLookup;

            tipa = GlobalState.LanguageHelper.GetLanguageString("ReceivePlanForm", "caption_Quantity");
            MainGridView.Columns["GoodsQty"].Caption = tipa;
            MainGridView.Columns["GoodsQty"].Width = 70;
            MainGridView.Columns["GoodsQty"].VisibleIndex = 4;
            MainGridView.Columns["GoodsQty"].Visible = true;

            tipa = GlobalState.LanguageHelper.GetLanguageString("MatchSOForm", "caption_ReceivedQuantity");
            MainGridView.Columns["ReceivedGoodsQty"].Caption = tipa;
            MainGridView.Columns["ReceivedGoodsQty"].Width = 70;
            MainGridView.Columns["ReceivedGoodsQty"].VisibleIndex = 5;
            MainGridView.Columns["ReceivedGoodsQty"].Visible = true;

            tipa = GlobalState.LanguageHelper.GetLanguageString("MatchSOForm", "caption_CurrentReceivedQuantity");
            MainGridView.Columns["CurrentReceivedQuantity"].Caption = tipa;
            MainGridView.Columns["CurrentReceivedQuantity"].Width = 70;
            MainGridView.Columns["CurrentReceivedQuantity"].VisibleIndex = 6;
            MainGridView.Columns["CurrentReceivedQuantity"].Visible = true;

            tipa = GlobalState.LanguageHelper.GetLanguageString("MatchSOForm", "caption_LeftQuantity");
            MainGridView.Columns["LeftQuantity"].Caption = tipa;
            MainGridView.Columns["LeftQuantity"].Width = 70;
            MainGridView.Columns["LeftQuantity"].VisibleIndex = 7;
            MainGridView.Columns["LeftQuantity"].Visible = true;


            MainGridView.Columns["ReceivedWeight"].Visible = false;
            MainGridView.Columns["CurrentReceivedWeight"].Visible = false;
            MainGridView.Columns["LeftWeight"].Visible = false;
            MainGridView.Columns["ReceivedVolume"].Visible = false;
            MainGridView.Columns["CurrentReceivedVolume"].Visible = false;
            MainGridView.Columns["LeftVolume"].Visible = false;


            MainGridView.Columns["Id"].Visible = false;
            MainGridView.Columns["InboundPlanId"].Visible = false;
            MainGridView.Columns["InboundPlanLine"].Visible = false;
            MainGridView.Columns["PurchaseOrderId"].Visible = false;
            MainGridView.Columns["PurchaseOrderCode"].Visible = false;
            MainGridView.Columns["GoodsId"].Visible = false;
            MainGridView.Columns["TaxType"].Visible = false;
            MainGridView.Columns["ProductionDate"].Visible = false;
            MainGridView.Columns["EffectiveDate"].Visible = false;
            MainGridView.Columns["Property1"].Visible = false;
            MainGridView.Columns["Property2"].Visible = false;
            MainGridView.Columns["Property3"].Visible = false;
            MainGridView.Columns["PiecePacket"].Visible = false;
            MainGridView.Columns["PieceQty"].Visible = false;
            MainGridView.Columns["ReceivedPieceQty"].Visible = false;
            MainGridView.Columns["Weight"].Visible = false;
            MainGridView.Columns["WeightMeasure"].Visible = false;
            MainGridView.Columns["VolumeMeasure"].Visible = false;
            MainGridView.Columns["Volume"].Visible = false;
            MainGridView.Columns["IsCrossDock"].Visible = false;


            MainGridView.OptionsView.ColumnAutoWidth = false;
            MainGridView.BestFitColumns();
            

            #endregion
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            BllResult bllResult;
            try
            {
               
                bool confirmResult = ServiceHelper.FacadeService.ConfirmIb(out bllResult, CurrentInboundBill.InboundBillId, GlobalState.LoginUser.UserId);
                if (confirmResult)
                {
                

                    AppLoggerHelper.WriteLog("Inbound Bill", "Audit", 0, CurrentInboundBill.InboundBillCode);
                    MessageBox.Show(GlobalState.LanguageHelper.GetLanguageString("message", "audit_complete_tip"));
                }
                else
                {
                    AppLoggerHelper.WriteLog("Inbound Bill", "Audit", 1, CurrentInboundBill.InboundBillCode);
                    MessageBox.Show(bllResult.ResultMessage);
                   
                }
                
                Close();
            }
            catch (Exception ex)
            {
                AppLoggerHelper.WriteLog("Inbound Bill", "Audit", 1, CurrentInboundBill.InboundBillCode);
                MessageBox.Show(GlobalState.LanguageHelper.GetLanguageString("message", "audit_error_tip"));
            }
        }

    }
}