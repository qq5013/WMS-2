using System.Windows.Forms;
using Frame.Utils.Service;
using MES.Entity;

namespace MES.Execute.Controls
{
    public partial class UcProductTrace : UserControl
    {
        public UcProductTrace()
        {
            InitializeComponent();
        }

        public InboundDetail Data { get; set; }

        public void Init()
        {
            listBoxControl1.DisplayMember = "Code";
            listBoxControl1.ValueMember = "InboundDetailTraceId";
            int inboundDetailId = Data.InboundDetailId;
            listBoxControl1.DataSource =
                ServiceHelper.GetService<InboundDetailTrace>().FindAll(c => c.InboundDetaiId == inboundDetailId, null);
        }
    }
}