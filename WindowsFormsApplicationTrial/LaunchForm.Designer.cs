﻿namespace WindowsFormsApplicationTrial
{
    partial class LaunchForm
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
            this.btnFontPoint = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnDPIPoint = new System.Windows.Forms.Button();
            this.btnNonePoint = new System.Windows.Forms.Button();
            this.btnNonePixel = new System.Windows.Forms.Button();
            this.btnDPIPixel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFontPoint
            // 
            this.btnFontPoint.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnFontPoint.Location = new System.Drawing.Point(0, 0);
            this.btnFontPoint.Margin = new System.Windows.Forms.Padding(2);
            this.btnFontPoint.Name = "btnFontPoint";
            this.btnFontPoint.Size = new System.Drawing.Size(250, 40);
            this.btnFontPoint.TabIndex = 0;
            this.btnFontPoint.Text = "UI: Font; Text: Point";
            this.btnFontPoint.UseVisualStyleBackColor = true;
            this.btnFontPoint.Click += new System.EventHandler(this.btnFontPoint_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(0, 80);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
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
            // btnDPIPoint
            // 
            this.btnDPIPoint.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnDPIPoint.ForeColor = System.Drawing.Color.Green;
            this.btnDPIPoint.Location = new System.Drawing.Point(251, 0);
            this.btnDPIPoint.Margin = new System.Windows.Forms.Padding(0);
            this.btnDPIPoint.Name = "btnDPIPoint";
            this.btnDPIPoint.Size = new System.Drawing.Size(250, 40);
            this.btnDPIPoint.TabIndex = 3;
            this.btnDPIPoint.Text = "UI: DPI; Text: Point";
            this.btnDPIPoint.UseVisualStyleBackColor = true;
            this.btnDPIPoint.Click += new System.EventHandler(this.btnDPIPoint_Click);
            // 
            // btnNonePoint
            // 
            this.btnNonePoint.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnNonePoint.ForeColor = System.Drawing.Color.Red;
            this.btnNonePoint.Location = new System.Drawing.Point(502, 0);
            this.btnNonePoint.Margin = new System.Windows.Forms.Padding(0);
            this.btnNonePoint.Name = "btnNonePoint";
            this.btnNonePoint.Size = new System.Drawing.Size(250, 40);
            this.btnNonePoint.TabIndex = 4;
            this.btnNonePoint.Text = "UI: None; Text: Point";
            this.btnNonePoint.UseVisualStyleBackColor = true;
            this.btnNonePoint.Click += new System.EventHandler(this.btnNonePoint_Click);
            // 
            // btnNonePixel
            // 
            this.btnNonePixel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnNonePixel.ForeColor = System.Drawing.Color.Green;
            this.btnNonePixel.Location = new System.Drawing.Point(502, 40);
            this.btnNonePixel.Margin = new System.Windows.Forms.Padding(0);
            this.btnNonePixel.Name = "btnNonePixel";
            this.btnNonePixel.Size = new System.Drawing.Size(250, 40);
            this.btnNonePixel.TabIndex = 5;
            this.btnNonePixel.Text = "UI: None; Text: Pixel";
            this.btnNonePixel.UseVisualStyleBackColor = true;
            this.btnNonePixel.Click += new System.EventHandler(this.btnNonePixel_Click);
            // 
            // btnDPIPixel
            // 
            this.btnDPIPixel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnDPIPixel.ForeColor = System.Drawing.Color.Red;
            this.btnDPIPixel.Location = new System.Drawing.Point(251, 40);
            this.btnDPIPixel.Margin = new System.Windows.Forms.Padding(0);
            this.btnDPIPixel.Name = "btnDPIPixel";
            this.btnDPIPixel.Size = new System.Drawing.Size(250, 40);
            this.btnDPIPixel.TabIndex = 6;
            this.btnDPIPixel.Text = "UI: DPI; Text: Pixel";
            this.btnDPIPixel.UseVisualStyleBackColor = true;
            this.btnDPIPixel.Click += new System.EventHandler(this.btnDPIPixel_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.button1.Location = new System.Drawing.Point(0, 40);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 40);
            this.button1.TabIndex = 7;
            this.button1.Text = "UI: Font; Text: Pixel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnFontPixel_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(754, 124);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDPIPixel);
            this.Controls.Add(this.btnNonePixel);
            this.Controls.Add(this.btnNonePoint);
            this.Controls.Add(this.btnDPIPoint);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnFontPoint);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form";
            this.Text = "Smart Application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFontPoint;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnDPIPoint;
        private System.Windows.Forms.Button btnNonePoint;
        private System.Windows.Forms.Button btnNonePixel;
        private System.Windows.Forms.Button btnDPIPixel;
        private System.Windows.Forms.Button button1;
    }
}

