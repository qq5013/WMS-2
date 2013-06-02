using System;
using System.Windows.Forms;
using Business.Domain.Wms;
using DevExpress.XtraBars;
using MES.BllService;
using MES.Common;
using MES.Entity;

namespace MES.Execute.Controls
{
    /// <summary>
    /// Sku列表
    /// </summary>
    public partial class UcSkuList : UserControl, IInitControl
    {
        /// <summary>
        /// 结果
        /// </summary>
        public int Result;

        /// <summary>
        /// Sku列表
        /// </summary>
        public UcSkuList()
        {
            InitializeComponent();
        }

        #region IInitControl Members

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            glueProduct.BindProduct(ControlMode.Edit, true);
        }

        #endregion

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelItemClick(object sender, ItemClickEventArgs e)
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
            if (glueProduct.EditValue == null)
            {
                MessageBox.Show("请选择物料");
                return;
            }
            if (teCode.Text.Trim().Length != 5)
            {
                MessageBox.Show("代码长度必须是5位");
                return;
            }
            try
            {
                var sku = new Sku();
                sku.LoadData(Controls);
                Result = sku.Save();
            }
            catch (Exception ex)
            {
                ex.Process("保存失败");
            }

            if (ParentForm != null) ParentForm.Close();
        }
    }
}