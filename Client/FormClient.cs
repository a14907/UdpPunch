using Models;
using Models.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FormClient : Form, IClientFront
    {
        private IClient _client;
        private SynchronizationContext _synchronizationContext;
        private Guid _userId = Guid.NewGuid();
        private string _userName;
        private IPEndPoint _clientEndPoint;
        private IPEndPoint _serverEndPoint;
        private BaseInfo _currentConnectUser;
        private EndPoint _currentConnectEndPoint;

        public FormClient()
        {
            InitializeComponent();
            _synchronizationContext = SynchronizationContext.Current;
        }

        public void ShowMsg(string msg)
        {
            _synchronizationContext.Post(obj =>
            {
                tbMsg.AppendText(obj.ToString() + "\r\n");
            }, msg);
        }

        private void FormClient_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var username = tbUserName.Text.Trim();
            var msg = tbSendMsg.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("用户名必填");
                return;
            }
            if (string.IsNullOrEmpty(msg))
            {
                MessageBox.Show("发生内容不能为空");
            }
            var model = new TextMessage
            {
                Content = msg
            };
            var cur = cbListUser.SelectedItem as BaseInfo;
            if (cur == null)
            {
                MessageBox.Show("请选择用户");
                return;
            }
            ShowMsg($"{_userName}:{msg}");
            _client.Send(new MessageCommand<TextMessage>
            {
                Content = model,
                UserId = _userId,
                UserName = _userName,
                FromPrivate = _clientEndPoint,
                Target = _currentConnectEndPoint
            });
            tbSendMsg.Clear();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {

            var username = tbUserName.Text.Trim();
            var cip = tbClientIP.Text.Trim();
            var cport = tbClientPort.Text.Trim();
            var sip = tbServerIP.Text.Trim();
            var sport = tbServerPort.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("用户名必填");
                return;
            }
            if (string.IsNullOrEmpty(cip))
            {
                MessageBox.Show("客户端IP必填");
                return;
            }
            if (string.IsNullOrEmpty(cport))
            {
                MessageBox.Show("客户端Port必填");
                return;
            }
            if (string.IsNullOrEmpty(sip))
            {
                MessageBox.Show("服务端IP必填");
                return;
            }
            if (string.IsNullOrEmpty(sport))
            {
                MessageBox.Show("服务端Port必填");
                return;
            }
            ChangeSettingStatus(false);
            _userName = username;
            _clientEndPoint = new IPEndPoint(IPAddress.Parse(cip), int.Parse(cport));
            _serverEndPoint = new IPEndPoint(IPAddress.Parse(sip), int.Parse(sport));
            _client = new ClientRunner(this, _clientEndPoint, _serverEndPoint);
            btnStart.Enabled = false;
            await Task.Delay(1000).ConfigureAwait(false);
            _client.Send(new ConnectServerCommand
            {
                UserName = _userName,
                UserId = _userId,
                FromPrivate = _clientEndPoint
            });
        }

        private void ChangeSettingStatus(bool status)
        {
            tbClientIP.Enabled = status;
            tbClientPort.Enabled = status;
            tbServerIP.Enabled = status;
            tbServerPort.Enabled = status;
            tbUserName.Enabled = status;
        }

        public void UpdateUserList(List<BaseInfo> ls)
        {
            _synchronizationContext.Post(obj =>
            {
                var userInfos = obj as List<BaseInfo>;
                if (userInfos?.Count <= 0)
                {
                    return;
                }
                var preselect = cbListUser.SelectedItem as BaseInfo;
                cbListUser.Items.Clear();
                cbListUser.DisplayMember = "UserName";
                foreach (var u in userInfos)
                {
                    if (u.UserId == _userId)
                    {
                        continue;
                    }
                    cbListUser.Items.Add(u);
                }
                if (preselect != null)
                {
                    var f = userInfos.FirstOrDefault(m => m.UserId == preselect.UserId);
                    if (f != null)
                    {
                        cbListUser.SelectedItem = f;
                        return;
                    }
                }
            }, ls);
        }

        private void cbListUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbListUser.Enabled == false)
            {
                return;
            }
            if (_currentConnectUser != null)
            {
                //MessageBox.Show("暂不支持多用户");
                return;
            }
            var cur = cbListUser.SelectedItem as BaseInfo;
            if (cur == null)
            {
                return;
            }
            if (cur.UserId == _userId)
            {
                MessageBox.Show("不能选择自己");
                return;
            }
            _client.Send(new TryConnectClientCommand
            {
                FromPrivate = _clientEndPoint,
                UserId = _userId,
                UserName = _userName,
                Target = cur
            });
        }

        public void ClientConnectSuccess(BaseInfo from, EndPoint endpoint)
        {
            _synchronizationContext.Post(obj =>
            {
                ShowMsg($"和用户：{from.UserName}连接成功，endpoint:{endpoint}");
                if (_currentConnectUser == null)
                {
                    _currentConnectUser = from;
                    _currentConnectEndPoint = endpoint;
                    foreach (BaseInfo item in cbListUser.Items)
                    {
                        if (item.UserId == from.UserId)
                        {
                            cbListUser.SelectedItem = item;
                        }
                    }
                }
                cbListUser.Enabled = false;
                btnUpdateUserList.Enabled = false;
            }, null);

        }

        private void btnUpdateUserList_Click(object sender, EventArgs e)
        {
            _client.Send(new GetAllUserCommand()
            {
                FromPrivate = _clientEndPoint,
                UserId = _userId,
                UserName = _userName
            });
        }
    }
}
