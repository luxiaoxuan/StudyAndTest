namespace WindowsFormsApplicationTrial
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClickMe = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClickMe
            // 
            this.btnClickMe.Location = new System.Drawing.Point(0, 0);
            this.btnClickMe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClickMe.Name = "btnClickMe";
            this.btnClickMe.Size = new System.Drawing.Size(384, 80);
            this.btnClickMe.TabIndex = 0;
            this.btnClickMe.Text = "Smart Application";
            this.btnClickMe.UseVisualStyleBackColor = true;
            this.btnClickMe.Click += new System.EventHandler(this.btnClickMe_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(0, 80);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.MaxLength = 45;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(385, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "012345678901234567890123456789012345678901234";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(128)));
            this.textBox2.Location = new System.Drawing.Point(390, 80);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.MaxLength = 40;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(360, 23);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "0123456789012345678901234567890123456789";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(754, 124);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnClickMe);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Smart Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClickMe;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

