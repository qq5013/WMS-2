namespace MES.Execute
{
    partial class UcMenu
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
            this.dropDownButton1 = new DevExpress.XtraEditors.DropDownButton();
            this.SuspendLayout();
            // 
            // dropDownButton1
            // 
            this.dropDownButton1.Appearance.Font = new System.Drawing.Font("NSimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropDownButton1.Appearance.Options.UseFont = true;
            this.dropDownButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.dropDownButton1.Location = new System.Drawing.Point(0, 2);
            this.dropDownButton1.Name = "dropDownButton1";
            this.dropDownButton1.Size = new System.Drawing.Size(100, 30);
            this.dropDownButton1.TabIndex = 4;
            this.dropDownButton1.Text = "生产管理";
            // 
            // UcMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dropDownButton1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcMenu";
            this.Size = new System.Drawing.Size(536, 35);
            this.Load += new System.EventHandler(this.UcMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DropDownButton dropDownButton1;

    }
}
