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
    public partial class CustomerOut : Form
    {
        OutHistoryBLL OBLL = new OutHistoryBLL();
        RoomInfoBLL RBLL = new RoomInfoBLL();
        public CustomerOut()
        {
            InitializeComponent();
        }
        string Worker = null;
        public CustomerOut(string WorkerName)
        {
            InitializeComponent();
            Worker = WorkerName;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           double op = OBLL.Out(textBox1.Text,Worker);
            if (op >= 0)
            {
               if(RBLL.StateChange2(textBox1.Text))
                {
                MessageBox.Show("退房成功！需缴纳罚款为："+op+"元");
                }
               else
                    MessageBox.Show("改变房态失败！");
            }
            else
                MessageBox.Show("退房失败！");
        }
    }
}
