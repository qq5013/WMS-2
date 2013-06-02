namespace Module.ReceiveGoodsModule.Views
{
    public class InboundPlanDetailMatch : ecWMS.Business.Entity.InboundPlanDetail
    {
        private int _currentReceivedQty;
        public int CurrentReceivedQty
        {
            get { return _currentReceivedQty; }
            set { _currentReceivedQty = value; }
        }

        private int _leftQty;
        public int LeftQty
        {
            get { return _leftQty; }
            set { _leftQty = value; }
        }

        private decimal _receivedVolume;
        public decimal ReceivedVolume
        {
            get { return _receivedVolume; }
            set { _receivedVolume = value; }
        }

        private decimal _currentReceivedVolume;
        public decimal CurrentReceivedVolume
        {
            get { return _currentReceivedVolume; }
            set { _currentReceivedVolume = value; }
        }

        private decimal _leftVolume;
        public decimal LeftVolume
        {
            get { return _leftVolume; }
            set { _leftVolume = value; }
        }

        private decimal _receivedWeight;
        public decimal ReceivedWeight
        {
            get { return _receivedWeight; }
            set { _receivedWeight = value; }
        }

        private decimal _currentReceivedWeight;
        public decimal CurrentReceivedWeight
        {
            get { return _currentReceivedWeight; }
            set { _currentReceivedWeight = value; }
        }

        private decimal _leftWeight;
        public decimal LeftWeight
        {
            get { return _leftWeight; }
            set { _leftWeight = value; }
        }

        private bool _isNotOk;
        public bool IsNotOK
        {
            get { return _isNotOk; }
            set { _isNotOk = value; }
        }
    }
}
