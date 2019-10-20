namespace Client
{
    partial class FormClient
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
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbListUser = new System.Windows.Forms.ComboBox();
            this.tbSendMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbServerIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbClientIP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbClientPort = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnUpdateUserList = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbMsg
            // 
            this.tbMsg.Location = new System.Drawing.Point(12, 67);
            this.tbMsg.Multiline = true;
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbMsg.Size = new System.Drawing.Size(756, 340);
            this.tbMsg.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "当前用户：";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(95, 40);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(100, 21);
            this.tbUserName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "选择用户：";
            // 
            // cbListUser
            // 
            this.cbListUser.FormattingEnabled = true;
            this.cbListUser.Location = new System.Drawing.Point(278, 40);
            this.cbListUser.Name = "cbListUser";
            this.cbListUser.Size = new System.Drawing.Size(121, 20);
            this.cbListUser.TabIndex = 5;
            // 
            // tbSendMsg
            // 
            this.tbSendMsg.Location = new System.Drawing.Point(12, 414);
            this.tbSendMsg.Name = "tbSendMsg";
            this.tbSendMsg.Size = new System.Drawing.Size(675, 21);
            this.tbSendMsg.TabIndex = 6;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(693, 412);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "服务器IP：";
            // 
            // tbServerIP
            // 
            this.tbServerIP.Location = new System.Drawing.Point(95, 12);
            this.tbServerIP.Name = "tbServerIP";
            this.tbServerIP.Size = new System.Drawing.Size(100, 21);
            this.tbServerIP.TabIndex = 3;
            this.tbServerIP.Text = "11.20.6.212";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "服务器port：";
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(290, 12);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(100, 21);
            this.tbServerPort.TabIndex = 3;
            this.tbServerPort.Text = "12345";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(402, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "客户端IP：";
            // 
            // tbClientIP
            // 
            this.tbClientIP.Location = new System.Drawing.Point(473, 15);
            this.tbClientIP.Name = "tbClientIP";
            this.tbClientIP.Size = new System.Drawing.Size(100, 21);
            this.tbClientIP.TabIndex = 3;
            this.tbClientIP.Text = "11.20.6.212";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(585, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "客户端Port：";
            // 
            // tbClientPort
            // 
            this.tbClientPort.Location = new System.Drawing.Point(668, 15);
            this.tbClientPort.Name = "tbClientPort";
            this.tbClientPort.Size = new System.Drawing.Size(100, 21);
            this.tbClientPort.TabIndex = 3;
            this.tbClientPort.Text = "54321";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(668, 38);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // btnUpdateUserList
            // 
            this.btnUpdateUserList.Location = new System.Drawing.Point(404, 38);
            this.btnUpdateUserList.Name = "btnUpdateUserList";
            this.btnUpdateUserList.Size = new System.Drawing.Size(43, 23);
            this.btnUpdateUserList.TabIndex = 11;
            this.btnUpdateUserList.Text = "刷新";
            this.btnUpdateUserList.UseVisualStyleBackColor = true;
            this.btnUpdateUserList.Click += new System.EventHandler(this.btnUpdateUserList_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(453, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "连接";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.cbListUser_SelectedIndexChanged);
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 443);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUpdateUserList);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbSendMsg);
            this.Controls.Add(this.cbListUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbClientPort);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbServerPort);
            this.Controls.Add(this.tbClientIP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbServerIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMsg);
            this.Name = "FormClient";
            this.Text = "FormClient";
            this.Load += new System.EventHandler(this.FormClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbListUser;
        private System.Windows.Forms.TextBox tbSendMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbServerIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbClientIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbClientPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnUpdateUserList;
        private System.Windows.Forms.Button button1;
    }
}

