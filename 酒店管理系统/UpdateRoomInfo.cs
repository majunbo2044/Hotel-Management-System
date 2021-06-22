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
    
    public partial class UpdateRoomInfo : Form
    {
        public UpdateRoomInfo()
        {
            InitializeComponent();
        }

        RoomInfoBLL BLL = new RoomInfoBLL();

        private void button1_Click(object sender, EventArgs e)
        {
            if (BLL.Update(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text))
            {
                MessageBox.Show("修改成功！");
            }
            else
                MessageBox.Show("修改失败！");
        }
    }
}
