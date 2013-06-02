using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Menu;

namespace MES.Execute
{
    public partial class UcMenuItem : UserControl,IDXDropDownControl
    {
        public UcMenuItem()
        {
            InitializeComponent();
        }

        public void Show(IDXMenuManager manager, Control control, Point pos)
        {
            
        }
    }
}
