namespace Wms.Mobile.UI.Receiving
{
    partial class ReceivingForm_Step2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblArrivalTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDeliveryMan = new System.Windows.Forms.Label();
            this.txtDeliveryMan = new System.Windows.Forms.TextBox();
            this.txtVehicle = new System.Windows.Forms.TextBox();
            this.lblVehicle = new System.Windows.Forms.Label();
            this.txtReceivingLocation = new System.Windows.Forms.TextBox();
            this.lblReceivingLocation = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.dpArrivalTime = new System.Windows.Forms.DateTimePicker();
            this.btnReturn = new System.Windows.Forms.Button();
            this.pnlButton.SuspendLayout();
            this.pnlClientZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnReturn);
            this.pnlButton.Controls.Add(this.btnContinue);
            // 
            // pnlClientZone
            // 
            this.pnlClientZone.Controls.Add(this.lblMessage);
            this.pnlClientZone.Controls.Add(this.txtReceivingLocation);
            this.pnlClientZone.Controls.Add(this.lblReceivingLocation);
            this.pnlClientZone.Controls.Add(this.txtVehicle);
            this.pnlClientZone.Controls.Add(this.lblVehicle);
            this.pnlClientZone.Controls.Add(this.txtDeliveryMan);
            this.pnlClientZone.Controls.Add(this.lblDeliveryMan);
            this.pnlClientZone.Controls.Add(this.label1);
            this.pnlClientZone.Controls.Add(this.dpArrivalTime);
            this.pnlClientZone.Controls.Add(this.lblArrivalTime);
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContinue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnContinue.Location = new System.Drawing.Point(234, 8);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(70, 35);
            this.btnContinue.TabIndex = 5;
            this.btnContinue.Text = "继续";
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lblArrivalTime
            // 
            this.lblArrivalTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblArrivalTime.Location = new System.Drawing.Point(14, 7);
            this.lblArrivalTime.Name = "lblArrivalTime";
            this.lblArrivalTime.Size = new System.Drawing.Size(98, 20);
            this.lblArrivalTime.Text = "到仓时间：";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(14, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 20);
            // 
            // lblDeliveryMan
            // 
            this.lblDeliveryMan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblDeliveryMan.Location = new System.Drawing.Point(14, 45);
            this.lblDeliveryMan.Name = "lblDeliveryMan";
            this.lblDeliveryMan.Size = new System.Drawing.Size(78, 20);
            this.lblDeliveryMan.Text = "送货人：";
            // 
            // txtDeliveryMan
            // 
            this.txtDeliveryMan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtDeliveryMan.Location = new System.Drawing.Point(128, 43);
            this.txtDeliveryMan.Name = "txtDeliveryMan";
            this.txtDeliveryMan.Size = new System.Drawing.Size(180, 26);
            this.txtDeliveryMan.TabIndex = 2;
            this.txtDeliveryMan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeliveryMan_KeyPress);
            // 
            // txtVehicle
            // 
            this.txtVehicle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtVehicle.Location = new System.Drawing.Point(130, 83);
            this.txtVehicle.Name = "txtVehicle";
            this.txtVehicle.Size = new System.Drawing.Size(178, 26);
            this.txtVehicle.TabIndex = 3;
            this.txtVehicle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVehicle_KeyPress);
            // 
            // lblVehicle
            // 
            this.lblVehicle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblVehicle.Location = new System.Drawing.Point(14, 83);
            this.lblVehicle.Name = "lblVehicle";
            this.lblVehicle.Size = new System.Drawing.Size(98, 20);
            this.lblVehicle.Text = "送货车辆：";
            // 
            // txtReceivingLocation
            // 
            this.txtReceivingLocation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtReceivingLocation.Location = new System.Drawing.Point(130, 122);
            this.txtReceivingLocation.Name = "txtReceivingLocation";
            this.txtReceivingLocation.Size = new System.Drawing.Size(180, 26);
            this.txtReceivingLocation.TabIndex = 4;
            this.txtReceivingLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceivingLocation_KeyPress);
            // 
            // lblReceivingLocation
            // 
            this.lblReceivingLocation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblReceivingLocation.Location = new System.Drawing.Point(14, 122);
            this.lblReceivingLocation.Name = "lblReceivingLocation";
            this.lblReceivingLocation.Size = new System.Drawing.Size(98, 20);
            this.lblReceivingLocation.Text = "收货库位：";
            // 
            // lblMessage
            // 
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(14, 162);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(290, 20);
            // 
            // dpArrivalTime
            // 
            this.dpArrivalTime.CustomFormat = "";
            this.dpArrivalTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.dpArrivalTime.Location = new System.Drawing.Point(130, 3);
            this.dpArrivalTime.Name = "dpArrivalTime";
            this.dpArrivalTime.Size = new System.Drawing.Size(180, 27);
            this.dpArrivalTime.TabIndex = 1;
            this.dpArrivalTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dpArrivalTime_KeyPress);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReturn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btnReturn.Location = new System.Drawing.Point(22, 8);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(70, 35);
            this.btnReturn.TabIndex = 6;
            this.btnReturn.Text = "返回";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // ReceivingForm_Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(318, 275);
            this.Menu = this.mainMenu1;
            this.Name = "ReceivingForm_Step2";
            this.Text = "ReceivingForm_Step2";
            this.Load += new System.EventHandler(this.ReceivingForm_Step2_Load);
            this.pnlButton.ResumeLayout(false);
            this.pnlClientZone.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblArrivalTime;
        private System.Windows.Forms.Label lblDeliveryMan;
        private System.Windows.Forms.TextBox txtReceivingLocation;
        private System.Windows.Forms.Label lblReceivingLocation;
        private System.Windows.Forms.TextBox txtVehicle;
        private System.Windows.Forms.Label lblVehicle;
        private System.Windows.Forms.TextBox txtDeliveryMan;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.DateTimePicker dpArrivalTime;
        private System.Windows.Forms.Button btnReturn;
    }
}