using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Client
{
    public partial class frmClient : Form
    {
        NetworkStream _networkstream;
        TcpClient _client;

        private byte[] _sendBuffer = new byte[1024 * 512];
        private byte[] _readBuffer = new byte[1024 * 512];

        public bool _isConnect = false; // 서버 연결 여부
        public bool _isLogin = false;
        public bool _isNew = false;

        private Thread _thClient;

        public Msg _msg = new Msg();

        public Member _memberList = new Member();
        string[] _members;

        public List<Post> _myPost;
        public int _postnum;

        public PictureBox[] _profileThumbnail;
        public Label[] _profileName;
        public PictureBox[] _postPicture;
        public TextBox[] _postText;

        public frmClient()
        {
            InitializeComponent();
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            if (_isLogin)
            {
                picHome.BackColor = Color.DodgerBlue;
                pnlHome.Visible = true;

                picSearch.BackColor = System.Drawing.SystemColors.Control;
                pnlSearch.Visible = false;
                picUpload.BackColor = System.Drawing.SystemColors.Control;
                pnlUpload.Visible = false;
                picMypage.BackColor = System.Drawing.SystemColors.Control;
                pnlMypage.Visible = false;
            }
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            if (_isLogin)
            {
                picSearch.BackColor = Color.DodgerBlue;
                pnlSearch.Visible = true;

                picHome.BackColor = System.Drawing.SystemColors.Control;
                pnlHome.Visible = false;
                picUpload.BackColor = System.Drawing.SystemColors.Control;
                pnlUpload.Visible = false;
                picMypage.BackColor = System.Drawing.SystemColors.Control;
                pnlMypage.Visible = false;

                
            }
        }

        private void picUpload_Click(object sender, EventArgs e)
        {
            if (_isLogin)
            {
                picUpload.BackColor = Color.DodgerBlue;
                pnlUpload.Visible = true;

                picHome.BackColor = System.Drawing.SystemColors.Control;
                pnlHome.Visible = false;
                picSearch.BackColor = System.Drawing.SystemColors.Control;
                pnlSearch.Visible = false;
                picMypage.BackColor = System.Drawing.SystemColors.Control;
                pnlMypage.Visible = false;
            }
        }

        private void picMypage_Click(object sender, EventArgs e)
        {
            if (_isLogin)
            {
                picMypage.BackColor = Color.DodgerBlue;
                pnlMypage.Visible = true;

                picHome.BackColor = System.Drawing.SystemColors.Control;
                pnlHome.Visible = false;
                picSearch.BackColor = System.Drawing.SystemColors.Control;
                pnlSearch.Visible = false;
                picUpload.BackColor = System.Drawing.SystemColors.Control;
                pnlUpload.Visible = false;

                if (_isNew)
                {
                    pnlPost.Controls.Clear();

                    lblPostCounting.Text = _postnum.ToString();

                    _profileThumbnail = new PictureBox[_postnum];
                    _profileName = new Label[_postnum];
                    _postPicture = new PictureBox[_postnum];
                    _postText = new TextBox[_postnum];

                    int y = 0;
                    for (int i = _postnum - 1; i >= 0; i--)
                    {
                        _profileThumbnail[i] = new PictureBox();
                        _profileThumbnail[i].Image = Properties.Resources.profile_img;
                        _profileThumbnail[i].Size = new Size(30, 30);
                        _profileThumbnail[i].SizeMode = PictureBoxSizeMode.StretchImage;
                        _profileThumbnail[i].Location = new Point(0, y);
                        pnlPost.Controls.Add(_profileThumbnail[i]);

                        _profileName[i] = new Label();
                        _profileName[i].Text = txtID.Text;
                        _profileName[i].Location = new Point(40, y);
                        pnlPost.Controls.Add(_profileName[i]);

                        try
                        {
                            _postPicture[i] = new PictureBox();
                            _postPicture[i].Image = (Image)(_myPost[i]._image);
                            _postPicture[i].Size = new Size(270, 180);
                            _postPicture[i].SizeMode = PictureBoxSizeMode.Zoom;
                            _postPicture[i].Location = new Point(40, y + 50);
                            pnlPost.Controls.Add(_postPicture[i]);

                            _postText[i] = new TextBox();
                            _postText[i].Text = _myPost[i]._text;
                            _postText[i].Size = new Size(270, 180);
                            _postText[i].Location = new Point(40, y + 250);
                            pnlPost.Controls.Add(_postText[i]);
                        }
                        catch
                        {

                        }

                        y += 300;
                    }
                    _isNew = false;
                }
            }
        }

        /* 서버 연결 */
        public void Connect()
        {
            _client = new TcpClient();

            try
            {
                _client.Connect(txtIP.Text, Convert.ToInt32(txtPort.Text));
            }
            catch
            {
                _isConnect = false;
                return;
            }
            _isConnect = true;
            _networkstream = _client.GetStream();

            _thClient = new Thread(new ThreadStart(Communiate));
            _thClient.Start();
        }

        /* 서버 연결 해제 */
        public void Disconnect()
        {
            if (!_isConnect)
                return;
            _isConnect = false;
            Quit quit = new Quit();
            quit.Type = (int)PacketType.QUIT;
            Packet.Serialize(quit).CopyTo(_sendBuffer, 0);
            Send();
            _client.Close();
            _networkstream.Close();
            _thClient.Abort();

            _isLogin = false;
            btnLogin.Text = "로그인";
            btnLogin.ForeColor = Color.Black;
            picHome.BackColor = System.Drawing.SystemColors.Control;
            pnlHome.Visible = false;
            picSearch.BackColor = System.Drawing.SystemColors.Control;
            pnlSearch.Visible = false;
            picUpload.BackColor = System.Drawing.SystemColors.Control;
            pnlUpload.Visible = false;
            picMypage.BackColor = System.Drawing.SystemColors.Control;
            pnlMypage.Visible = false;
        }

        public void Communiate()
        {
            int nRead = 0;
            while (_isConnect)
            {
                try
                {
                    nRead = 0;
                    for (int i = 0; i < _readBuffer.Length; i += (1024 * 4))
                        nRead = _networkstream.Read(_readBuffer, i, 1024 * 4);
                }
                catch
                {
                    _isConnect = false;
                    _networkstream = null;
                }

                Packet packet = (Packet)Packet.Desserialize(_readBuffer);
                try { 
                    switch ((int)packet.Type)
                    {
                        case (int)PacketType.MEMBER:
                            {
                                _memberList = (Member)Packet.Desserialize(_readBuffer);
                                _members = _memberList._list.Split('\n');
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    foreach (var member in _members)
                                        lstSearch.Items.Add(member);
                                }));
                                break;
                            }

                        case (int)PacketType.MSG:
                            {
                                _msg = (Msg)Packet.Desserialize(_readBuffer);
                                if (_msg._text.Equals("LogIn"))
                                {
                                    _isLogin = true;
                                    _isNew = true;
                                    _postnum = Convert.ToInt32(_msg._memo);
                                    this.Invoke(new MethodInvoker(delegate ()
                                   {
                                       btnLogin.Text = "로그아웃";
                                       btnLogin.ForeColor = Color.Red;
                                   }));
                                }
                                else if (_msg._text.Equals("성공적으로 업로드하였습니다 ! 마이페이지에서 확인하십시오."))
                                {
                                    MessageBox.Show(_msg._text);
                                    _postnum++;
                                }
                                else
                                    MessageBox.Show(_msg._text);
                                break;
                            }
                        case (int)PacketType.MYPAGE:
                            {
                                Post post = new Post();
                                post = (Post)Packet.Desserialize(_readBuffer);
                                _myPost.Add(post);
                                break;
                            }
                    }
                }
                catch
                {

                }
            }
        }

        public void Send()
        {
            for (int i = 0; i < _sendBuffer.Length; i += (1024 * 4))
                _networkstream.Write(_sendBuffer, i, 1024 * 4);
            _networkstream.Flush();

            for (int i = 0; i < 1024 * 512; i++)
                _sendBuffer[i] = 0;
        }

        private void frmClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            Disconnect();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(btnConnect.Text == "Connect")
            {
                if (txtIP.Text.Equals("") == true || txtPort.Text.Equals("") == true)
                {
                    MessageBox.Show("IP와 Port를 입력하세요.");
                    return;
                }

                Connect();

                if (_isConnect == false)
                {
                    MessageBox.Show("Server가 시작되지 않았습니다.");
                    return;
                }

                if (_isConnect)
                {
                    btnConnect.Text = "Disconnect";
                    btnConnect.ForeColor = Color.Red;
                    txtIP.Enabled = false;
                    txtPort.Enabled = false;
                    txtID.Enabled = true;
                    txtPassword.Enabled = true;
                    btnLogin.Enabled = true;
                    btnJoin.Enabled = true;
                }
            }
            else
            {
                Disconnect();
                btnConnect.Text = "Connect";
                btnConnect.ForeColor = Color.Black;
                txtIP.Enabled = true;
                txtPort.Enabled = true;
                txtID.Text = "";
                txtPassword.Text = "";
                txtID.Enabled = false;
                txtPassword.Enabled = false;
                btnLogin.Enabled = false;
                btnJoin.Enabled = false;
            }
        }


        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (!_isConnect)
                return;

            Join join = new Join();
            join.Type = (int)PacketType.JOIN;
            join._id = txtID.Text;
            join._password = txtPassword.Text;

            Packet.Serialize(join).CopyTo(_sendBuffer, 0);
            Send();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "로그인")
            {
                if (!_isConnect)
                    return;

                Login login = new Login();
                login.Type = (int)PacketType.LOGIN;
                login._id = txtID.Text;
                login._password = txtPassword.Text;
                _myPost = new List<Post>();

                Packet.Serialize(login).CopyTo(_sendBuffer, 0);
                Send();
            }
            else
            {
                if (!_isConnect)
                    return;

                _isLogin = false;
                _postnum = 0;
                _memberList = null;
                _members = null;
                lstSearch.Items.Clear();
                _myPost.Clear();

                btnLogin.Text = "로그인";
                btnLogin.ForeColor = Color.Black;

                picHome.BackColor = System.Drawing.SystemColors.Control;
                pnlHome.Visible = false;
                picSearch.BackColor = System.Drawing.SystemColors.Control;
                pnlSearch.Visible = false;
                picUpload.BackColor = System.Drawing.SystemColors.Control;
                pnlUpload.Visible = false;
                picMypage.BackColor = System.Drawing.SystemColors.Control;
                pnlMypage.Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstSearch.Items.Clear();
            foreach(var member in _members)
            {
                if (member.Contains(txtSearch.Text))
                    lstSearch.Items.Add(member);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = "C:\\";

            if(openFileDialog.ShowDialog() ==DialogResult.OK)
            {
                txtPicturePath.Text = openFileDialog.FileName;
                picUploadPicture.ImageLocation = openFileDialog.FileName;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (txtPicturePath.Text == "" || picUploadPicture.ImageLocation == "")
                MessageBox.Show("업로드할 사진을 선택하세요.");
            else
            {
                Post post = new Post();
                post.Type = (int)PacketType.POST;
                post._image = picUploadPicture.Image.Clone();
                post._text = txtUploadText.Text;

                try
                {
                    Packet.Serialize(post).CopyTo(_sendBuffer, 0);
                    Send();
                }
                catch
                {
                    MessageBox.Show("파일 용량이 너무 큽니다. (512KB 이하)");
                }
                _isNew = true;
            }
        }
    }
}
