using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Wms.Mobile.UI
{
    public partial class TemplateForm : Form
    {
        public Form MainForm { get; set; }

        public Form ModuleForm { get; set; }

        //public Form PriorForm { get; set; }

        public TemplateForm()
        {
            InitializeComponent();
        }

        public void SetTitle(string title)
        {
            this.Text = title;
        }
    }
}