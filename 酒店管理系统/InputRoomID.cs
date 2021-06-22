using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace 酒店管理系统
{
    public partial class InputRoomID : Form
    {
        public InputRoomID()
        {
            InitializeComponent();
        }
        string WorkerName = null;
        public InputRoomID(string name)
        {
            InitializeComponent();
            WorkerName = name;
        }
        RoomInfoBLL BLL = new RoomInfoBLL();
        private void button1_Click(object sender, EventArgs e)
        {
            if (BLL.HasRoom(textBox1.Text))
            {
                if (BLL.isnull(textBox1.Text))
                {
                    string RoomType = BLL.RoomType(textBox1.Text);
                    string RoomPrice = BLL.RoomPrice(textBox1.Text);
                    CustomerIn customerIn = new CustomerIn(textBox1.Text, RoomType, RoomPrice,WorkerName);
                    customerIn.MdiParent = this.Owner;
                    customerIn.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("房间已占用！");
            }
            else
                MessageBox.Show("房间不存在！");
        }
    }
}
