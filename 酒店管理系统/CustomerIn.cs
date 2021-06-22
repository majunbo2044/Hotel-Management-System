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
    public partial class CustomerIn : Form
    {
        public CustomerIn()
        {
            InitializeComponent();
        }
        RoomInfoBLL RBLL = new RoomInfoBLL();
        InHistoryBLL IBLL = new InHistoryBLL();

        string RoomID = null;
        string WorkerName = null;
        public CustomerIn(string Room,string RoomType,string RoomPrice,string Worker)
        {
            InitializeComponent();
            RoomID = Room;
            label1.Text += Room;
            label2.Text += RoomType;
            label3.Text += RoomPrice;
            WorkerName = Worker;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           DateTime.Now.ToShortDateString().ToString();

            DateTime dt = DateTime.Now;
           dt=dt.AddDays(Convert.ToDouble( textBox2.Text));
            string Out = dt.ToShortDateString().ToString();
           bool op = IBLL.Insert(textBox3.Text, RoomID, Out,WorkerName);
           bool op2 = RBLL.StateChange(RoomID);
            if (op && op2)
            {
                MessageBox.Show("操作成功！");
            }
            else
                MessageBox.Show("操作失败！请检查数据库");

                
        }
    }
}
