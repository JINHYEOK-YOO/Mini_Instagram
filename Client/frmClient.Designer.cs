namespace Client
{
    partial class frmClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClient));
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblInstagram = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblNoAccount = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnJoin = new System.Windows.Forms.Button();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lstSearch = new System.Windows.Forms.ListBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlUpload = new System.Windows.Forms.Panel();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtUploadText = new System.Windows.Forms.TextBox();
            this.picUploadPicture = new System.Windows.Forms.PictureBox();
            this.txtPicturePath = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.pnlMypage = new System.Windows.Forms.Panel();
            this.btnViewTypeList = new System.Windows.Forms.Button();
            this.pnlPost = new System.Windows.Forms.Panel();
            this.btnViewTypeTile = new System.Windows.Forms.Button();
            this.txtProfile = new System.Windows.Forms.TextBox();
            this.btnProfileEdit = new System.Windows.Forms.Button();
            this.lblPost = new System.Windows.Forms.Label();
            this.lblPostCounting = new System.Windows.Forms.Label();
            this.picProfile = new System.Windows.Forms.PictureBox();
            this.picMypage = new System.Windows.Forms.PictureBox();
            this.picUpload = new System.Windows.Forms.PictureBox();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pnlSearch.SuspendLayout();
            this.pnlUpload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUploadPicture)).BeginInit();
            this.pnlMypage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMypage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUpload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(45, 48);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(30, 15);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "IP :";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(45, 87);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(44, 15);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Port :";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(97, 45);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(227, 25);
            this.txtIP.TabIndex = 2;
            this.txtIP.Text = "서버PC IP 입력";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(97, 84);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(227, 25);
            this.txtPort.TabIndex = 3;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(330, 48);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 61);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblInstagram
            // 
            this.lblInstagram.AutoSize = true;
            this.lblInstagram.Font = new System.Drawing.Font("굴림", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInstagram.Location = new System.Drawing.Point(65, 180);
            this.lblInstagram.Name = "lblInstagram";
            this.lblInstagram.Size = new System.Drawing.Size(297, 38);
            this.lblInstagram.TabIndex = 5;
            this.lblInstagram.Text = "MINI Instagram";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(100, 264);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(30, 15);
            this.lblID.TabIndex = 6;
            this.lblID.Text = "ID :";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(48, 311);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(82, 15);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password :";
            // 
            // lblNoAccount
            // 
            this.lblNoAccount.AutoSize = true;
            this.lblNoAccount.Location = new System.Drawing.Point(139, 364);
            this.lblNoAccount.Name = "lblNoAccount";
            this.lblNoAccount.Size = new System.Drawing.Size(145, 15);
            this.lblNoAccount.TabIndex = 8;
            this.lblNoAccount.Text = "아직 계정이 없나요?";
            // 
            // btnLogin
            // 
            this.btnLogin.Enabled = false;
            this.btnLogin.Location = new System.Drawing.Point(330, 254);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 72);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(136, 254);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(171, 25);
            this.txtID.TabIndex = 10;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(136, 308);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(171, 25);
            this.txtPassword.TabIndex = 11;
            // 
            // btnJoin
            // 
            this.btnJoin.Enabled = false;
            this.btnJoin.Location = new System.Drawing.Point(290, 357);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(89, 28);
            this.btnJoin.TabIndex = 12;
            this.btnJoin.Text = "회원가입";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // pnlHome
            // 
            this.pnlHome.Location = new System.Drawing.Point(441, 12);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(471, 541);
            this.pnlHome.TabIndex = 14;
            this.pnlHome.Visible = false;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.lstSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Location = new System.Drawing.Point(441, 12);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(471, 541);
            this.pnlSearch.TabIndex = 0;
            this.pnlSearch.Visible = false;
            // 
            // lstSearch
            // 
            this.lstSearch.FormattingEnabled = true;
            this.lstSearch.ItemHeight = 15;
            this.lstSearch.Location = new System.Drawing.Point(59, 90);
            this.lstSearch.Name = "lstSearch";
            this.lstSearch.Size = new System.Drawing.Size(353, 439);
            this.lstSearch.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(59, 45);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(283, 25);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(348, 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "찾기";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlUpload
            // 
            this.pnlUpload.Controls.Add(this.btnUpload);
            this.pnlUpload.Controls.Add(this.txtUploadText);
            this.pnlUpload.Controls.Add(this.picUploadPicture);
            this.pnlUpload.Controls.Add(this.txtPicturePath);
            this.pnlUpload.Controls.Add(this.btnFind);
            this.pnlUpload.Location = new System.Drawing.Point(441, 12);
            this.pnlUpload.Name = "pnlUpload";
            this.pnlUpload.Size = new System.Drawing.Size(471, 541);
            this.pnlUpload.TabIndex = 0;
            this.pnlUpload.Visible = false;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(51, 495);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(361, 34);
            this.btnUpload.TabIndex = 4;
            this.btnUpload.Text = "게시물 등록하기";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtUploadText
            // 
            this.txtUploadText.Location = new System.Drawing.Point(51, 407);
            this.txtUploadText.Multiline = true;
            this.txtUploadText.Name = "txtUploadText";
            this.txtUploadText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUploadText.Size = new System.Drawing.Size(360, 82);
            this.txtUploadText.TabIndex = 3;
            // 
            // picUploadPicture
            // 
            this.picUploadPicture.Location = new System.Drawing.Point(51, 72);
            this.picUploadPicture.Name = "picUploadPicture";
            this.picUploadPicture.Size = new System.Drawing.Size(360, 320);
            this.picUploadPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUploadPicture.TabIndex = 2;
            this.picUploadPicture.TabStop = false;
            // 
            // txtPicturePath
            // 
            this.txtPicturePath.Enabled = false;
            this.txtPicturePath.Location = new System.Drawing.Point(117, 35);
            this.txtPicturePath.Name = "txtPicturePath";
            this.txtPicturePath.Size = new System.Drawing.Size(295, 25);
            this.txtPicturePath.TabIndex = 1;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(51, 35);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(60, 23);
            this.btnFind.TabIndex = 0;
            this.btnFind.Text = "찾기";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // pnlMypage
            // 
            this.pnlMypage.Controls.Add(this.btnViewTypeList);
            this.pnlMypage.Controls.Add(this.pnlPost);
            this.pnlMypage.Controls.Add(this.btnViewTypeTile);
            this.pnlMypage.Controls.Add(this.txtProfile);
            this.pnlMypage.Controls.Add(this.btnProfileEdit);
            this.pnlMypage.Controls.Add(this.lblPost);
            this.pnlMypage.Controls.Add(this.lblPostCounting);
            this.pnlMypage.Controls.Add(this.picProfile);
            this.pnlMypage.Location = new System.Drawing.Point(441, 12);
            this.pnlMypage.Name = "pnlMypage";
            this.pnlMypage.Size = new System.Drawing.Size(471, 541);
            this.pnlMypage.TabIndex = 15;
            this.pnlMypage.Visible = false;
            // 
            // btnViewTypeList
            // 
            this.btnViewTypeList.Location = new System.Drawing.Point(210, 213);
            this.btnViewTypeList.Name = "btnViewTypeList";
            this.btnViewTypeList.Size = new System.Drawing.Size(160, 23);
            this.btnViewTypeList.TabIndex = 8;
            this.btnViewTypeList.Text = "리스트";
            this.btnViewTypeList.UseVisualStyleBackColor = true;
            // 
            // pnlPost
            // 
            this.pnlPost.AutoScroll = true;
            this.pnlPost.Location = new System.Drawing.Point(23, 252);
            this.pnlPost.Name = "pnlPost";
            this.pnlPost.Size = new System.Drawing.Size(389, 264);
            this.pnlPost.TabIndex = 7;
            // 
            // btnViewTypeTile
            // 
            this.btnViewTypeTile.Location = new System.Drawing.Point(44, 213);
            this.btnViewTypeTile.Name = "btnViewTypeTile";
            this.btnViewTypeTile.Size = new System.Drawing.Size(160, 23);
            this.btnViewTypeTile.TabIndex = 5;
            this.btnViewTypeTile.Text = "바둑판";
            this.btnViewTypeTile.UseVisualStyleBackColor = true;
            // 
            // txtProfile
            // 
            this.txtProfile.Location = new System.Drawing.Point(23, 154);
            this.txtProfile.Multiline = true;
            this.txtProfile.Name = "txtProfile";
            this.txtProfile.Size = new System.Drawing.Size(377, 53);
            this.txtProfile.TabIndex = 4;
            // 
            // btnProfileEdit
            // 
            this.btnProfileEdit.Location = new System.Drawing.Point(213, 90);
            this.btnProfileEdit.Name = "btnProfileEdit";
            this.btnProfileEdit.Size = new System.Drawing.Size(187, 58);
            this.btnProfileEdit.TabIndex = 3;
            this.btnProfileEdit.Text = "프로필 수정";
            this.btnProfileEdit.UseVisualStyleBackColor = true;
            // 
            // lblPost
            // 
            this.lblPost.AutoSize = true;
            this.lblPost.Location = new System.Drawing.Point(279, 63);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(52, 15);
            this.lblPost.TabIndex = 2;
            this.lblPost.Text = "게시물";
            // 
            // lblPostCounting
            // 
            this.lblPostCounting.AutoSize = true;
            this.lblPostCounting.Location = new System.Drawing.Point(296, 39);
            this.lblPostCounting.Name = "lblPostCounting";
            this.lblPostCounting.Size = new System.Drawing.Size(15, 15);
            this.lblPostCounting.TabIndex = 1;
            this.lblPostCounting.Text = "0";
            // 
            // picProfile
            // 
            this.picProfile.Image = global::Client.Properties.Resources.profile_img;
            this.picProfile.Location = new System.Drawing.Point(23, 16);
            this.picProfile.Name = "picProfile";
            this.picProfile.Size = new System.Drawing.Size(181, 132);
            this.picProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProfile.TabIndex = 0;
            this.picProfile.TabStop = false;
            // 
            // picMypage
            // 
            this.picMypage.Image = global::Client.Properties.Resources.button_mypage;
            this.picMypage.Location = new System.Drawing.Point(786, 564);
            this.picMypage.Name = "picMypage";
            this.picMypage.Size = new System.Drawing.Size(97, 59);
            this.picMypage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMypage.TabIndex = 13;
            this.picMypage.TabStop = false;
            this.picMypage.Click += new System.EventHandler(this.picMypage_Click);
            // 
            // picUpload
            // 
            this.picUpload.Image = global::Client.Properties.Resources.button_upload;
            this.picUpload.Location = new System.Drawing.Point(683, 564);
            this.picUpload.Name = "picUpload";
            this.picUpload.Size = new System.Drawing.Size(97, 59);
            this.picUpload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUpload.TabIndex = 13;
            this.picUpload.TabStop = false;
            this.picUpload.Click += new System.EventHandler(this.picUpload_Click);
            // 
            // picSearch
            // 
            this.picSearch.Image = ((System.Drawing.Image)(resources.GetObject("picSearch.Image")));
            this.picSearch.Location = new System.Drawing.Point(580, 564);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(97, 59);
            this.picSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSearch.TabIndex = 13;
            this.picSearch.TabStop = false;
            this.picSearch.Click += new System.EventHandler(this.picSearch_Click);
            // 
            // picHome
            // 
            this.picHome.BackColor = System.Drawing.SystemColors.Control;
            this.picHome.Image = global::Client.Properties.Resources.button_home;
            this.picHome.Location = new System.Drawing.Point(477, 564);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(97, 59);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHome.TabIndex = 13;
            this.picHome.TabStop = false;
            this.picHome.Click += new System.EventHandler(this.picHome_Click);
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 640);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlMypage);
            this.Controls.Add(this.pnlHome);
            this.Controls.Add(this.pnlUpload);
            this.Controls.Add(this.picMypage);
            this.Controls.Add(this.picUpload);
            this.Controls.Add(this.picSearch);
            this.Controls.Add(this.picHome);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblNoAccount);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblInstagram);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIP);
            this.MaximumSize = new System.Drawing.Size(953, 687);
            this.MinimumSize = new System.Drawing.Size(953, 687);
            this.Name = "frmClient";
            this.Text = "Mini Instagram Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmClient_FormClosed);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlUpload.ResumeLayout(false);
            this.pnlUpload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUploadPicture)).EndInit();
            this.pnlMypage.ResumeLayout(false);
            this.pnlMypage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMypage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUpload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblInstagram;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblNoAccount;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.PictureBox picUpload;
        private System.Windows.Forms.PictureBox picMypage;
        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.ListBox lstSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlUpload;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtUploadText;
        private System.Windows.Forms.PictureBox picUploadPicture;
        private System.Windows.Forms.TextBox txtPicturePath;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Panel pnlMypage;
        private System.Windows.Forms.Button btnViewTypeList;
        private System.Windows.Forms.Panel pnlPost;
        private System.Windows.Forms.Button btnViewTypeTile;
        private System.Windows.Forms.TextBox txtProfile;
        private System.Windows.Forms.Button btnProfileEdit;
        private System.Windows.Forms.Label lblPost;
        private System.Windows.Forms.Label lblPostCounting;
        private System.Windows.Forms.PictureBox picProfile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

