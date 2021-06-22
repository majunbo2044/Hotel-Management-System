using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace 酒店管理系统
{
    public partial class WorkerMain : Form
    {
        public WorkerMain()
        {
            InitializeComponent();
        }
        string WorkerName = null;
        public WorkerMain(string name)
        {
            InitializeComponent();
            WorkerName = name;
            toolStripStatusLabel1.Text += name;

            this.toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text =  DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
    {
        RoomInfo roomInfo = new RoomInfo();
            roomInfo.MdiParent = this;
            roomInfo.Show();
        }

        private void WorkerMain_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            customerInfo.MdiParent = this;
            customerInfo.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            InputRoomID inputRoomID = new InputRoomID(WorkerName);
            inputRoomID.ShowDialog();
            

            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            CustomerOut customerOut = new CustomerOut(WorkerName);
           
            customerOut.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            InHistory inHistory = new InHistory();
            inHistory.MdiParent = this;
            inHistory.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            OutHistory outHistory = new OutHistory();
            outHistory.MdiParent = this;
            outHistory.Show();
        }
    }
}
