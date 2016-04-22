namespace WindowsFormsApplicationTrial
{
    partial class ColorTestForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRai = new System.Windows.Forms.Label();
            this.txtCnc = new System.Windows.Forms.TextBox();
            this.btnHaku = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRai
            // 
            this.lblRai.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.lblRai.ForeColor = System.Drawing.Color.Red;
            this.lblRai.Location = new System.Drawing.Point(10, 10);
            this.lblRai.Margin = new System.Windows.Forms.Padding(0);
            this.lblRai.Name = "lblRai";
            this.lblRai.Size = new System.Drawing.Size(250, 25);
            this.lblRai.TabIndex = 0;
            this.lblRai.Text = "Rai! Rai!";
            // 
            // txtCnc
            // 
            this.txtCnc.BackColor = System.Drawing.Color.Blue;
            this.txtCnc.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.txtCnc.ForeColor = System.Drawing.Color.LightGray;
            this.txtCnc.Location = new System.Drawing.Point(10, 40);
            this.txtCnc.Name = "txtCnc";
            this.txtCnc.Size = new System.Drawing.Size(250, 27);
            this.txtCnc.TabIndex = 1;
            this.txtCnc.Text = "Cnc! Cnc!";
            // 
            // btnHaku
            // 
            this.btnHaku.Location = new System.Drawing.Point(10, 150);
            this.btnHaku.Name = "btnHaku";
            this.btnHaku.Size = new System.Drawing.Size(250, 80);
            this.btnHaku.TabIndex = 2;
            this.btnHaku.Text = "Haku!";
            this.btnHaku.UseVisualStyleBackColor = true;
            this.btnHaku.Click += new System.EventHandler(this.btnHaku_Click);
            // 
            // ColorTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.btnHaku);
            this.Controls.Add(this.txtCnc);
            this.Controls.Add(this.lblRai);
            this.ForeColor = System.Drawing.Color.Green;
            this.Name = "ColorTestForm";
            this.Text = "ColorTestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRai;
        private System.Windows.Forms.TextBox txtCnc;
        private System.Windows.Forms.Button btnHaku;
    }
}