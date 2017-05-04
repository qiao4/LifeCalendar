namespace LifeCalendar {
    partial class FormMain {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.quickSet = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.precent = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1138, 772);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.precent);
            this.panel2.Controls.Add(this.quickSet);
            this.panel2.Controls.Add(this.btnInit);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 772);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1138, 61);
            this.panel2.TabIndex = 0;
            // 
            // quickSet
            // 
            this.quickSet.Location = new System.Drawing.Point(516, 6);
            this.quickSet.Name = "quickSet";
            this.quickSet.Size = new System.Drawing.Size(99, 43);
            this.quickSet.TabIndex = 2;
            this.quickSet.Text = "quick set";
            this.quickSet.UseVisualStyleBackColor = true;
            this.quickSet.Click += new System.EventHandler(this.quickSet_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(686, 15);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 33);
            this.btnInit.TabIndex = 1;
            this.btnInit.Text = "init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(779, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "reset";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // precent
            // 
            this.precent.Location = new System.Drawing.Point(12, 15);
            this.precent.Name = "precent";
            this.precent.Size = new System.Drawing.Size(67, 33);
            this.precent.TabIndex = 3;
            this.precent.Text = "20%";
            this.precent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 833);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FormMain";
            this.Text = "Life Calendar";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button quickSet;
        private System.Windows.Forms.Label precent;
    }
}

