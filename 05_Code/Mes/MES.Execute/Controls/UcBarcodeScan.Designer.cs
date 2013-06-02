namespace MES.Execute.Controls
{
    partial class UcBarcodeScan
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
            this.beBarcode = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.beBarcode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // beBarcode
            // 
            this.beBarcode.Location = new System.Drawing.Point(86, 34);
            this.beBarcode.Name = "beBarcode";
            this.beBarcode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beBarcode.Properties.Appearance.Options.UseFont = true;
            this.beBarcode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.OK)});
            this.beBarcode.Properties.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BeBarcodeKeyPress);
            this.beBarcode.Size = new System.Drawing.Size(302, 26);
            this.beBarcode.TabIndex = 0;
            this.beBarcode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.BeBarcodeButtonClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(13, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(112, 22);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "条码扫描作业区";
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(86, 66);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(60, 17);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "信息提示区";
            // 
            // UcBarcodeScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.beBarcode);
            this.Name = "UcBarcodeScan";
            this.Size = new System.Drawing.Size(406, 137);
            ((System.ComponentModel.ISupportInitialize)(this.beBarcode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit beBarcode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblMessage;
    }
}
