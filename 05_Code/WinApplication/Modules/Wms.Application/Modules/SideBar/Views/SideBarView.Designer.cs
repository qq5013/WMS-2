namespace Modules.SidebarModule.Views
{
	partial class SideBarView
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SideBarView));
            this.tvNavigator = new System.Windows.Forms.TreeView();
            this.ilMenu = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // tvNavigator
            // 
            this.tvNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvNavigator.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvNavigator.ImageIndex = 0;
            this.tvNavigator.ImageList = this.ilMenu;
            this.tvNavigator.Location = new System.Drawing.Point(0, 0);
            this.tvNavigator.Name = "tvNavigator";
            this.tvNavigator.SelectedImageIndex = 0;
            this.tvNavigator.Size = new System.Drawing.Size(155, 462);
            this.tvNavigator.TabIndex = 0;
            this.tvNavigator.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvNavigator_AfterSelect);
            this.tvNavigator.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvNavigator_NodeMouseClick);
            // 
            // ilMenu
            // 
            this.ilMenu.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMenu.ImageStream")));
            this.ilMenu.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMenu.Images.SetKeyName(0, "457.png");
            this.ilMenu.Images.SetKeyName(1, "2.png");
            this.ilMenu.Images.SetKeyName(2, "015.png");
            this.ilMenu.Images.SetKeyName(3, "016.png");
            this.ilMenu.Images.SetKeyName(4, "017.png");
            // 
            // SideBarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tvNavigator);
            this.Name = "SideBarView";
            this.Size = new System.Drawing.Size(155, 462);
            this.Load += new System.EventHandler(this.SideBarView_Load);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.ImageList ilMenu;
        public System.Windows.Forms.TreeView tvNavigator;


    }
}
