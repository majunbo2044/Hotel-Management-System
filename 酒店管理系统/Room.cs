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
    public partial class Room : Form
    {
        RoomInfoBLL BLL = new RoomInfoBLL();
        public Room()
        {
            InitializeComponent();
            dataGridView1.DataSource = BLL.GetInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateRoomInfo updateRoomInfo = new UpdateRoomInfo();
            updateRoomInfo.ShowDialog();
            dataGridView1.DataSource = BLL.GetInfo();

        }
    }
}
