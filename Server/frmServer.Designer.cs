namespace Server
{
    partial class frmServer
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblIP = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lvwMember = new System.Windows.Forms.ListView();
            this.chIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPassword = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblMemberList = new System.Windows.Forms.Label();
            this.lblLog = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(31, 47);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(30, 15);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "IP :";
            // 
            // txtIP
            // 
            this.txtIP.Enabled = false;
            this.txtIP.Location = new System.Drawing.Point(67, 44);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(434, 25);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "실행시, 서버 PC의 IP를 자동으로 입력받아와서 textBox에 표시";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(563, 47);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(44, 15);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port :";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(613, 44);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(143, 25);
            this.txtPort.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(776, 44);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(141, 25);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lvwMember
            // 
            this.lvwMember.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chIndex,
            this.chID,
            this.chPassword});
            this.lvwMember.Location = new System.Drawing.Point(34, 139);
            this.lvwMember.Name = "lvwMember";
            this.lvwMember.Size = new System.Drawing.Size(341, 423);
            this.lvwMember.TabIndex = 5;
            this.lvwMember.UseCompatibleStateImageBehavior = false;
            this.lvwMember.View = System.Windows.Forms.View.Details;
            // 
            // chIndex
            // 
            this.chIndex.Text = "Index";
            this.chIndex.Width = 97;
            // 
            // chID
            // 
            this.chID.Text = "ID";
            this.chID.Width = 84;
            // 
            // chPassword
            // 
            this.chPassword.Text = "Password";
            this.chPassword.Width = 84;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(393, 139);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(539, 423);
            this.txtLog.TabIndex = 6;
            // 
            // lblMemberList
            // 
            this.lblMemberList.AutoSize = true;
            this.lblMemberList.Location = new System.Drawing.Point(31, 104);
            this.lblMemberList.Name = "lblMemberList";
            this.lblMemberList.Size = new System.Drawing.Size(145, 15);
            this.lblMemberList.TabIndex = 7;
            this.lblMemberList.Text = "Member Account List";
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(390, 104);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(79, 15);
            this.lblLog.TabIndex = 8;
            this.lblLog.Text = "Server Log";
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 574);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.lblMemberList);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lvwMember);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.lblIP);
            this.Name = "frmServer";
            this.Text = "Mini Instagram Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmServer_FormClosed);
            this.Load += new System.EventHandler(this.frmServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListView lvwMember;
        private System.Windows.Forms.ColumnHeader chIndex;
        private System.Windows.Forms.ColumnHeader chID;
        private System.Windows.Forms.ColumnHeader chPassword;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblMemberList;
        private System.Windows.Forms.Label lblLog;
    }
}

