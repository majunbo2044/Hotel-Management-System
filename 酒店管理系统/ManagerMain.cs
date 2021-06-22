using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 酒店管理系统
{
    public partial class ManagerMain : Form
    {
        public ManagerMain()
        {
            InitializeComponent();
        }

        public ManagerMain(string name)
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RoomInfo roomInfo = new RoomInfo();
            roomInfo.MdiParent = this;
            roomInfo.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CustomerInfo customerInfo = new CustomerInfo();
            customerInfo.MdiParent = this;
            customerInfo.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            InHistory inHistory = new InHistory();
            inHistory.MdiParent = this;
            inHistory.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            OutHistory outHistory = new OutHistory();
            outHistory.MdiParent = this;
            outHistory.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Room room = new Room();
            room.MdiParent = this;
            room.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Worker worker = new Worker();
            worker.MdiParent = this;
            worker.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Manager manager = new Manager();
            manager.MdiParent = this;
            manager.Show();
        }
    }
}
