using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Server
{
    public partial class frmServer : Form
    {
        public NetworkStream _networkstream;
        private TcpListener _listener;
        int _port;

        private Thread _thServer;

        string _storage = "C:\\Instagram_server\\";

        StreamReader _fileReader;
        StreamWriter _fileWriter;

        public bool _isStart = false;   // 서버 시작 여부
        public bool _isConnect = false; // 클라이언트 연결 여부
        public bool _isError = false; // 오류 발생 여부
        public bool _isLogin = false;

        private byte[] _sendBuffer = new byte[1024 * 512];
        private byte[] _readBuffer = new byte[1024 * 512];

        public Join _joinMember;
        public Login _loginMember;
        public Post _post;

        public frmServer()
        {
            InitializeComponent();
        }

        /* 서버 IP 가져오기 */
        private string GetServerIP()
        {
            string ServerIP = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    ServerIP = ip.ToString();

            return ServerIP;
        }

        /* 가입된 계정 목록 로드 */
        public void LoadMemberList()
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    if (lvwMember.Items.Count > 0)
                        lvwMember.Items.Clear();
                }));

                _fileReader = new StreamReader(_storage + "member.txt");

                int index = 1;
                while (_fileReader.Peek() >= 0)
                {
                    var lvwItem = new ListViewItem(new string[lvwMember.Columns.Count]);
                    for (int i = 0; i < lvwMember.Columns.Count; i++)
                        lvwItem.SubItems[i].Name = lvwMember.Columns[i].Name;
                    lvwItem.SubItems[0].Text = index.ToString();
                    for (int i = 1; i < lvwMember.Columns.Count; i++)
                        lvwItem.SubItems[i].Text = _fileReader.ReadLine();

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        lvwMember.Items.Add(lvwItem);
                    }));
                    index++;
                }

                _fileReader.Close();
                _fileReader.Dispose();
            }
            catch
            {
                _fileWriter = new StreamWriter(_storage + "member.txt", true);
                _fileWriter.Close();
                _fileWriter.Dispose();
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

        private void frmServer_Load(object sender, EventArgs e)
        {
            txtIP.Text = GetServerIP();
        }

        private void frmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            ServerStop();
        }

        /* 서버 시작 */
        public void ServerStart()
        {
            try
            {
                _port = Convert.ToInt32(txtPort.Text);
                _listener = new TcpListener(_port);
                _listener.Start();
                _isStart = true;

                DirectoryInfo di = new DirectoryInfo(_storage);
                if (di.Exists == false)
                    di.Create();

                LoadMemberList();

                 this.Invoke(new MethodInvoker(delegate ()
                 {
                     txtLog.AppendText("Server - Start\n");
                     txtLog.AppendText("Storage Path : C:\\Instagram_server\\\n");
                     txtLog.AppendText("waiting for client access...\n");
                 }));

                while (_isStart)
                {
                    TcpClient client = _listener.AcceptTcpClient();

                    if (client.Connected)
                    {
                        _isConnect = true;
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            txtLog.AppendText("Client Access !!\n");
                        }));
                        _networkstream = client.GetStream();

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
                                _networkstream.Close();
                                _networkstream = null;
                            }


                            Packet packet = (Packet)Packet.Desserialize(_readBuffer);

                            switch ((int)packet.Type)
                            {
                                case (int)PacketType.QUIT:
                                    {
                                        _isConnect = false;
                                        break;
                                    }

                                case (int)PacketType.JOIN:
                                    {
                                        _isError = false;
                                        _joinMember = (Join)Packet.Desserialize(_readBuffer);
                                        _fileReader = new StreamReader(_storage + "member.txt");
                                        while (_fileReader.Peek() >= 0)
                                        {
                                            if (_joinMember._id.Equals(_fileReader.ReadLine()))
                                            {
                                                Msg msg = new Msg();
                                                msg._text = "이미 사용중인 ID 입니다.";
                                                msg.Type = (int)PacketType.MSG;
                                                Packet.Serialize(msg).CopyTo(_sendBuffer, 0);
                                                Send();
                                                _isError = true;
                                                break;
                                            }
                                            _fileReader.ReadLine();
                                        }
                                        _fileReader.Close();
                                        _fileReader.Dispose();
                                        _fileReader = null;

                                        if (_isError)
                                            break;
                                        else
                                        {
                                            _fileWriter = new StreamWriter(_storage + "member.txt", true);
                                            _fileWriter.WriteLine(_joinMember._id);
                                            _fileWriter.WriteLine(_joinMember._password);
                                            _fileWriter.Flush();
                                            _fileWriter.Close();
                                            _fileWriter.Dispose();
                                            _fileWriter = null;
                                            this.Invoke(new MethodInvoker(delegate ()
                                            {
                                                txtLog.AppendText(_joinMember._id + " >> Join\n");
                                            }));
                                            LoadMemberList();

                                            Msg msg = new Msg();
                                            msg._text = "회원가입이 정상적으로 완료되었습니다 !";
                                            msg.Type = (int)PacketType.MSG;
                                            Packet.Serialize(msg).CopyTo(_sendBuffer, 0);
                                            Send();
                                            break;
                                        }
                                    }
                                case (int)PacketType.LOGIN:
                                    {
                                        try
                                        {
                                            _isError = true;
                                            _loginMember = (Login)Packet.Desserialize(_readBuffer);
                                            _fileReader = new StreamReader(_storage + "member.txt");
                                            while (_fileReader.Peek() >= 0)
                                            {
                                                if (_loginMember._id.Equals(_fileReader.ReadLine()))
                                                {
                                                    if (_loginMember._password.Equals(_fileReader.ReadLine()))
                                                    {
                                                        _isError = false;
                                                        break;
                                                    }
                                                }
                                                else
                                                    _fileReader.ReadLine();
                                            }
                                            _fileReader.Close();
                                            _fileReader.Dispose();
                                            _fileReader = null;

                                            if (_isError)
                                            {
                                                Msg msg = new Msg();
                                                msg._text = "ID 또는 PW가 잘못되었습니다.\n계정이 없다면 회원가입 버튼을 통해 계정을 만드십시오!";
                                                msg.Type = (int)PacketType.MSG;
                                                Packet.Serialize(msg).CopyTo(_sendBuffer, 0);
                                                Send();
                                                break;
                                            }
                                            else
                                            {
                                                DirectoryInfo memberDi = new DirectoryInfo(_storage + _loginMember._id);
                                                if (memberDi.Exists == false)
                                                    memberDi.Create();
                                                _loginMember._postnum = memberDi.GetFiles().Length / 2;

                                                Msg msg = new Msg();
                                                msg._text = "LogIn";
                                                msg._memo = _loginMember._postnum.ToString();
                                                msg.Type = (int)PacketType.MSG;
                                                Packet.Serialize(msg).CopyTo(_sendBuffer, 0);
                                                Send();
                                                this.Invoke(new MethodInvoker(delegate ()
                                                {
                                                    txtLog.AppendText(_loginMember._id + " >> LogIn\n");
                                                }));

                                                Member memberList = new Member();
                                                string otherMember;
                                                _fileReader = new StreamReader(_storage + "member.txt");
                                                while (_fileReader.Peek() >= 0)
                                                {
                                                    otherMember = _fileReader.ReadLine();
                                                    if (!_loginMember._id.Equals(otherMember))
                                                        memberList._list += otherMember + "\n";
                                                    _fileReader.ReadLine();
                                                }
                                                memberList.Type = (int)PacketType.MEMBER;
                                                Packet.Serialize(memberList).CopyTo(_sendBuffer, 0);
                                                Send();
                                                _fileReader.Close();
                                                _fileReader.Dispose();
                                                _fileReader = null;

                                                for (int i = 0; i < _loginMember._postnum; i++)
                                                {
                                                    Post post = new Post();
                                                    Image image = (Image)(Image.FromFile(_storage + _loginMember._id + "\\" + i.ToString() + ".jpg").Clone());
                                                    _fileReader = new StreamReader(_storage + _loginMember._id + "\\" + i.ToString());
                                                    post._image = image;
                                                    while (_fileReader.Peek() >= 0)
                                                        post._text += _fileReader.ReadLine();
                                                    post.Type = (int)PacketType.MYPAGE;
                                                    Packet.Serialize(post).CopyTo(_sendBuffer, 0);
                                                    Send();
                                                    _fileReader.Close();
                                                    _fileReader.Dispose();
                                                    _fileReader = null;
                                                }
                                                break;
                                            }
                                        }
                                        catch
                                        {
                                            break;
                                        }
                                    }
                                case (int)PacketType.POST:
                                    {
                                        _isError = false;
                                        try
                                        {
                                            _post = (Post)Packet.Desserialize(_readBuffer);
                                            Image image = (Image)_post._image;
                                            image.Save(_storage + _loginMember._id + "\\" + _loginMember._postnum + ".jpg");
                                            _fileWriter = new StreamWriter(_storage +  _loginMember._id + "\\" + _loginMember._postnum);
                                            _fileWriter.WriteLine(_post._text);

                                            Post post = new Post();
                                            post._image = image;
                                            post._text = _post._text;
                                            post.Type = (int)PacketType.MYPAGE;
                                            Packet.Serialize(post).CopyTo(_sendBuffer, 0);
                                            Send();
                                            _fileWriter.Flush();
                                            _fileWriter.Close();
                                            _fileWriter.Dispose();
                                            _fileWriter = null;
                                            _loginMember._postnum++;
                                        }
                                        catch
                                        {
                                            _isError = true;
                                        }

                                        if (!_isError)
                                        {
                                            Msg msg = new Msg();
                                            msg._text = "성공적으로 업로드하였습니다 ! 마이페이지에서 확인하십시오.";
                                            msg._memo = _loginMember._postnum.ToString();
                                            msg.Type = (int)PacketType.MSG;
                                            Packet.Serialize(msg).CopyTo(_sendBuffer, 0);
                                            Send();
                                        }
                                        else
                                        {
                                            Msg msg = new Msg();
                                            msg._text = "업로드 실패";
                                            msg.Type = (int)PacketType.MSG;
                                            Packet.Serialize(msg).CopyTo(_sendBuffer, 0);
                                            Send();
                                        }
                                        break;
                                    }
                            }
                        }
                        if (!_isConnect)
                            continue;
                    }
                    else
                    {
                        _isConnect = false;
                        _networkstream.Close();
                        _networkstream = null;
                    }
                }
        }
            catch
            {
                ServerStop();
                return;
            }
}


        /* 서버 중지 */
        public void ServerStop()
        {
            if (!_isStart)
                return;

            _listener.Stop();
            if (_isConnect)
                _networkstream.Close();
            _thServer.Abort();

            this.Invoke(new MethodInvoker(delegate ()
            {
                txtLog.AppendText("Server - Stop\n");
            }));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtIP.Text.Equals("") == true || txtPort.Text.Equals("") == true)
            {
                MessageBox.Show("IP와 Port를 입력하세요.");
                return;
            }

            if (btnStart.Text == "Start")
            {
                _thServer = new Thread(new ThreadStart(ServerStart));
                _thServer.Start();

                btnStart.Text = "Stop";
                btnStart.ForeColor = Color.Red;
                txtPort.Enabled = false;
            }
            else
            {
                ServerStop();
                btnStart.Text = "Start";
                btnStart.ForeColor = Color.Black;
                txtPort.Enabled = true;
            }
        }
    }
}
