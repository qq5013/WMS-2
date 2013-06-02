using System;
using System.Windows.Forms;

namespace MES.Execute.Controls
{
    /// <summary>
    /// 修改数量
    /// </summary>
    public partial class UcChangeQuantity : UserControl
    {
        /// <summary>
        /// 回调
        /// </summary>
        public Adjust Adjust;

        public UcChangeQuantity()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 数量初始化
        /// </summary>
        public int Data
        {
            set
            {
                spinEdit1.EditValue = value;
                spinEdit2.EditValue = value;
            }
        }

        /// <summary>
        /// 取消修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelClick(object sender, EventArgs e)
        {
            if (ParentForm != null) ParentForm.Close();
        }

        /// <summary>
        /// 确认修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDoneClick(object sender, EventArgs e)
        {
            // 当调整数量反馈后返回
            if (!Adjust(Convert.ToInt32(spinEdit1.EditValue))) return;
            if (ParentForm != null) ParentForm.Close();
        }
    }
}