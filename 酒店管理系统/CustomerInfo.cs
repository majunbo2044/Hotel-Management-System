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
    public partial class CustomerInfo : Form
    {
        CustomerBLL BLL = new CustomerBLL();
        public CustomerInfo()
        {
            InitializeComponent();
            dataGridView1.DataSource = BLL.GetInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.GetInfo(comboBox1.Text);  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.GetInfo(comboBox2.Text,textBox1.Text);
        }
    }
}
