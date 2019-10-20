using Models;
using Models.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FormServer : Form, IServerFront
    {
        private IServer _server;
        private SynchronizationContext _synchronizationContext;
        public FormServer()
        {
            InitializeComponent();
            _synchronizationContext = SynchronizationContext.Current;
        }

        private void FormServer_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbPort.Text.Trim(), out int port))
            {
                _server = new ServerRunner(this, port);
            }
            else
            {
                MessageBox.Show("请输入合法的端口号");
            }
            btnStart.Enabled = false;
        }

        public void ShowMsg(string msg)
        {
            _synchronizationContext.Post(obj =>
            {
                tbMsg.AppendText(obj.ToString() + "\r\n");
            }, msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var msg = new MessageCommand<TextMessage>
            {
                Content = new TextMessage { Content = "ce shi shu ju " },
            };
            _server.GetSocket().SendTo(msg.Serialize(), new IPEndPoint(IPAddress.Parse(tbip.Text.Trim()), int.Parse(textBox2.Text.Trim())));
        }
    }
}
