namespace HW7_DrawTree
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.text_rratio = new System.Windows.Forms.TextBox();
            this.text_lratio = new System.Windows.Forms.TextBox();
            this.text_rrotate = new System.Windows.Forms.TextBox();
            this.text_lrotate = new System.Windows.Forms.TextBox();
            this.trackBar_penwidth = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_penwidth)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.trackBar_penwidth);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.text_rratio);
            this.panel1.Controls.Add(this.text_lratio);
            this.panel1.Controls.Add(this.text_rrotate);
            this.panel1.Controls.Add(this.text_lrotate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 346);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 112);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(389, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "画笔属性";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "右分支缩放比";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "左分支缩放比";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "右分支旋转角";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "左分支旋转角";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(443, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 23);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // text_rratio
            // 
            this.text_rratio.Location = new System.Drawing.Point(271, 45);
            this.text_rratio.Name = "text_rratio";
            this.text_rratio.Size = new System.Drawing.Size(100, 21);
            this.text_rratio.TabIndex = 5;
            this.text_rratio.Text = "0.7";
            // 
            // text_lratio
            // 
            this.text_lratio.Location = new System.Drawing.Point(271, 18);
            this.text_lratio.Name = "text_lratio";
            this.text_lratio.Size = new System.Drawing.Size(100, 21);
            this.text_lratio.TabIndex = 4;
            this.text_lratio.Text = "0.6";
            // 
            // text_rrotate
            // 
            this.text_rrotate.Location = new System.Drawing.Point(86, 45);
            this.text_rrotate.Name = "text_rrotate";
            this.text_rrotate.Size = new System.Drawing.Size(100, 21);
            this.text_rrotate.TabIndex = 3;
            this.text_rrotate.Text = "20";
            // 
            // text_lrotate
            // 
            this.text_lrotate.Location = new System.Drawing.Point(86, 18);
            this.text_lrotate.Name = "text_lrotate";
            this.text_lrotate.Size = new System.Drawing.Size(100, 21);
            this.text_lrotate.TabIndex = 2;
            this.text_lrotate.Text = "30";
            // 
            // trackBar_penwidth
            // 
            this.trackBar_penwidth.Location = new System.Drawing.Point(391, 45);
            this.trackBar_penwidth.Maximum = 5;
            this.trackBar_penwidth.Name = "trackBar_penwidth";
            this.trackBar_penwidth.Size = new System.Drawing.Size(99, 45);
            this.trackBar_penwidth.TabIndex = 6;
            this.trackBar_penwidth.Value = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 458);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "DrawTree";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_penwidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox text_rratio;
        private System.Windows.Forms.TextBox text_lratio;
        private System.Windows.Forms.TextBox text_rrotate;
        private System.Windows.Forms.TextBox text_lrotate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar_penwidth;
    }
}

