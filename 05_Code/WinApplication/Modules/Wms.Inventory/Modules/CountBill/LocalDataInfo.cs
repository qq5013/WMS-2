using Business.Domain.Inventory.Views;

namespace Modules.CountBillModule
{
    public class LocalDataInfo :CountBillDetailView 
    {
       private int _TempId;

        public int TempId
        {
            get { return _TempId; }
            set { _TempId = value; }
        }

        private string _operationName;
        public string OperationName
        {
            get { return _operationName; }
            set { _operationName = value; }
        }
    }
}

