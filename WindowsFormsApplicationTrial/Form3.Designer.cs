namespace WindowsFormsApplicationTrial
{
    partial class Form3
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
            this.btnClickMe = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClickMe
            // 
            this.btnClickMe.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnClickMe.Location = new System.Drawing.Point(0, 0);
            this.btnClickMe.Margin = new System.Windows.Forms.Padding(0);
            this.btnClickMe.Name = "btnClickMe";
            this.btnClickMe.Size = new System.Drawing.Size(480, 80);
            this.btnClickMe.TabIndex = 1;
            this.btnClickMe.Text = "Smart Application";
            this.btnClickMe.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(80, 82);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.MaxLength = 45;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(400, 23);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "012345678901234567890123456789012345678901234";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(0, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "SmartApp:";
            // 
            // Form3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(944, 162);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnClickMe);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClickMe;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}