using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wms.Mobile.Common;
using Wms.Mobile.UI;

namespace Wms.Mobile
{
    public partial class MainForm : Form
    {
        public TemplateForm CurrentForm { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.Hide();
            //LoginForm form = new LoginForm();
            //form.ShowDialog();
            //if (GlobalState.CurrentUser == null)
            //    this.Close();

            //this.Show();
        }

        private void LoadOperations()
        {
            switch (cbOperationType.SelectedIndex)
            {
                case 0:
                    lvOperation.Items.Clear();
                    lvOperation.Items.Add(new ListViewItem(new[] { "101", "收货" }));
                    lvOperation.Items.Add(new ListViewItem(new[] { "102", "上架" }));
                    break;
                case 1:
                    lvOperation.Items.Clear();
                    lvOperation.Items.Add(new ListViewItem(new[] { "201", "库存查询" }));
                    lvOperation.Items.Add(new ListViewItem(new[] { "202", "移货" }));
                    lvOperation.Items.Add(new ListViewItem(new[] { "203", "盘点" }));
                    lvOperation.Items.Add(new ListViewItem(new[] { "204", "主动补货" }));
                    lvOperation.Items.Add(new ListViewItem(new[] { "205", "按计划补货" }));
                    lvOperation.Items.Add(new ListViewItem(new[] { "206", "锁定/解锁" }));
                    break;
                case 2:
                    lvOperation.Items.Clear();
                    //lvOperation.Items.Add(new ListViewItem(new[] { "301", "绑定托盘" }));
                    lvOperation.Items.Add(new ListViewItem(new[] { "301", "拣货" }));
                    lvOperation.Items.Add(new ListViewItem(new[] { "302", "发货" }));
                    //lvOperation.Items.Add(new ListViewItem(new[] { "304", "协作拣货" }));
                    break;
                case 3:
                    lvOperation.Items.Clear();
                    break;
            }
        }

        private void cbOperationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOperations();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm form = new LoginForm();
            form.Show();
            //Application.Exit();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = lvOperation.SelectedIndices;
            switch (cbOperationType.SelectedIndex)
            {
                case 0:
                    if (indices != null && indices.Count > 0)
                    {
                        switch (indices[0])
                        {
                            case 0:
                                FormHelper.OpenModuleForm(this, "Receiving");
                                break;
                            case 1:
                                FormHelper.OpenModuleForm(this, "Putaway");
                                break;
                        }
                    }
                    break;
                case 1:
                    if (indices != null && indices.Count > 0)
                    {
                        switch (indices[0])
                        {
                            case 0:
                                FormHelper.OpenModuleForm(this, "StockQuery");
                                break;
                            case 1:
                                FormHelper.OpenModuleForm(this, "Transfer");
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                        }
                    }
                    break;
                case 2:
                    if (indices != null && indices.Count > 0)
                    {
                        switch (indices[0])
                        {
                            case 0:
                                FormHelper.OpenModuleForm(this, "Pick");
                                break;
                            case 1:
                                FormHelper.OpenModuleForm(this, "Delivery");
                                break;
                        }
                    }
                    break;
                case 3:
                    if (indices != null && indices.Count > 0)
                    {
                        switch (indices[0])
                        {
                            case 0:
                                break;
                        }
                    }
                    break;
                case 4:
                    if (indices != null && indices.Count > 0)
                    {
                        
                    }
                    break;
            }
        }


    }
}