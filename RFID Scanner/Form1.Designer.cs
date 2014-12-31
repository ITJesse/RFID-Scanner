namespace RFID_Scaner
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
            this.components = new System.ComponentModel.Container();
            this.cbSerial = new System.Windows.Forms.ComboBox();
            this.btnSerialOpen = new System.Windows.Forms.Button();
            this.btnSerialClose = new System.Windows.Forms.Button();
            this.resultList = new System.Windows.Forms.ListView();
            this.btnScan = new System.Windows.Forms.Button();
            this.scanTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // cbSerial
            // 
            this.cbSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSerial.FormattingEnabled = true;
            this.cbSerial.Location = new System.Drawing.Point(12, 12);
            this.cbSerial.Name = "cbSerial";
            this.cbSerial.Size = new System.Drawing.Size(121, 20);
            this.cbSerial.TabIndex = 0;
            // 
            // btnSerialOpen
            // 
            this.btnSerialOpen.Location = new System.Drawing.Point(139, 10);
            this.btnSerialOpen.Name = "btnSerialOpen";
            this.btnSerialOpen.Size = new System.Drawing.Size(75, 23);
            this.btnSerialOpen.TabIndex = 1;
            this.btnSerialOpen.Text = "打开串口";
            this.btnSerialOpen.UseVisualStyleBackColor = true;
            this.btnSerialOpen.Click += new System.EventHandler(this.btnSerialOpen_Click);
            // 
            // btnSerialClose
            // 
            this.btnSerialClose.Enabled = false;
            this.btnSerialClose.Location = new System.Drawing.Point(220, 10);
            this.btnSerialClose.Name = "btnSerialClose";
            this.btnSerialClose.Size = new System.Drawing.Size(75, 23);
            this.btnSerialClose.TabIndex = 2;
            this.btnSerialClose.Text = "关闭串口";
            this.btnSerialClose.UseVisualStyleBackColor = true;
            this.btnSerialClose.Click += new System.EventHandler(this.btnSerialClose_Click);
            // 
            // resultList
            // 
            this.resultList.FullRowSelect = true;
            this.resultList.GridLines = true;
            this.resultList.Location = new System.Drawing.Point(12, 38);
            this.resultList.MultiSelect = false;
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(760, 326);
            this.resultList.TabIndex = 3;
            this.resultList.UseCompatibleStateImageBehavior = false;
            this.resultList.View = System.Windows.Forms.View.Details;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(12, 370);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(760, 44);
            this.btnScan.TabIndex = 4;
            this.btnScan.Text = "开始扫描";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // scanTimer
            // 
            this.scanTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.resultList);
            this.Controls.Add(this.btnSerialClose);
            this.Controls.Add(this.btnSerialOpen);
            this.Controls.Add(this.cbSerial);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSerial;
        private System.Windows.Forms.Button btnSerialOpen;
        private System.Windows.Forms.Button btnSerialClose;
        private System.Windows.Forms.ListView resultList;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Timer scanTimer;
    }
}

