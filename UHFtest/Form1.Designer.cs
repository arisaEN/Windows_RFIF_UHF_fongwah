namespace UHFtest
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_test = new System.Windows.Forms.Button();
            this.lB_test = new System.Windows.Forms.ListBox();
            this.btn_ReadMultipleEPC = new System.Windows.Forms.Button();
            this.lB_Continuous = new System.Windows.Forms.ListBox();
            this.btn_StartScan = new System.Windows.Forms.Button();
            this.btn_StopScan = new System.Windows.Forms.Button();
            this.lV_Continuous = new System.Windows.Forms.ListView();
            this.cb_AllowDuplicates = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(680, 113);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(114, 32);
            this.btn_test.TabIndex = 0;
            this.btn_test.Text = "Test";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // lB_test
            // 
            this.lB_test.FormattingEnabled = true;
            this.lB_test.ItemHeight = 12;
            this.lB_test.Location = new System.Drawing.Point(13, 19);
            this.lB_test.Name = "lB_test";
            this.lB_test.Size = new System.Drawing.Size(163, 364);
            this.lB_test.TabIndex = 1;
            // 
            // btn_ReadMultipleEPC
            // 
            this.btn_ReadMultipleEPC.Location = new System.Drawing.Point(680, 184);
            this.btn_ReadMultipleEPC.Name = "btn_ReadMultipleEPC";
            this.btn_ReadMultipleEPC.Size = new System.Drawing.Size(115, 32);
            this.btn_ReadMultipleEPC.TabIndex = 2;
            this.btn_ReadMultipleEPC.Text = "Read multiple EPC";
            this.btn_ReadMultipleEPC.UseVisualStyleBackColor = true;
            this.btn_ReadMultipleEPC.Click += new System.EventHandler(this.btn_ReadMultipleEPC_Click);
            // 
            // lB_Continuous
            // 
            this.lB_Continuous.FormattingEnabled = true;
            this.lB_Continuous.ItemHeight = 12;
            this.lB_Continuous.Location = new System.Drawing.Point(182, 19);
            this.lB_Continuous.Name = "lB_Continuous";
            this.lB_Continuous.Size = new System.Drawing.Size(51, 364);
            this.lB_Continuous.TabIndex = 3;
            // 
            // btn_StartScan
            // 
            this.btn_StartScan.Location = new System.Drawing.Point(680, 252);
            this.btn_StartScan.Name = "btn_StartScan";
            this.btn_StartScan.Size = new System.Drawing.Size(124, 23);
            this.btn_StartScan.TabIndex = 4;
            this.btn_StartScan.Text = "btn_StartScan";
            this.btn_StartScan.UseVisualStyleBackColor = true;
            this.btn_StartScan.Click += new System.EventHandler(this.btn_StartScan_Click);
            // 
            // btn_StopScan
            // 
            this.btn_StopScan.Location = new System.Drawing.Point(679, 310);
            this.btn_StopScan.Name = "btn_StopScan";
            this.btn_StopScan.Size = new System.Drawing.Size(125, 23);
            this.btn_StopScan.TabIndex = 5;
            this.btn_StopScan.Text = "btn_StopScan";
            this.btn_StopScan.UseVisualStyleBackColor = true;
            this.btn_StopScan.Click += new System.EventHandler(this.btn_StopScan_Click);
            // 
            // lV_Continuous
            // 
            this.lV_Continuous.AllowColumnReorder = true;
            this.lV_Continuous.HideSelection = false;
            this.lV_Continuous.Location = new System.Drawing.Point(239, 19);
            this.lV_Continuous.Name = "lV_Continuous";
            this.lV_Continuous.Size = new System.Drawing.Size(403, 364);
            this.lV_Continuous.TabIndex = 6;
            this.lV_Continuous.UseCompatibleStateImageBehavior = false;
            // 
            // cb_AllowDuplicates
            // 
            this.cb_AllowDuplicates.AutoSize = true;
            this.cb_AllowDuplicates.Location = new System.Drawing.Point(662, 19);
            this.cb_AllowDuplicates.Name = "cb_AllowDuplicates";
            this.cb_AllowDuplicates.Size = new System.Drawing.Size(142, 16);
            this.cb_AllowDuplicates.TabIndex = 7;
            this.cb_AllowDuplicates.Text = "連続検出切替(テスト用)";
            this.cb_AllowDuplicates.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 404);
            this.Controls.Add(this.cb_AllowDuplicates);
            this.Controls.Add(this.lV_Continuous);
            this.Controls.Add(this.btn_StopScan);
            this.Controls.Add(this.btn_StartScan);
            this.Controls.Add(this.lB_Continuous);
            this.Controls.Add(this.btn_ReadMultipleEPC);
            this.Controls.Add(this.lB_test);
            this.Controls.Add(this.btn_test);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "UHFtest";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.ListBox lB_test;
        private System.Windows.Forms.Button btn_ReadMultipleEPC;
        private System.Windows.Forms.ListBox lB_Continuous;
        private System.Windows.Forms.Button btn_StartScan;
        private System.Windows.Forms.Button btn_StopScan;
        private System.Windows.Forms.ListView lV_Continuous;
        private System.Windows.Forms.CheckBox cb_AllowDuplicates;
    }
}

