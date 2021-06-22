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
    public partial class CustomerRegister : Form
    {
        RegisterBLL BLL = new RegisterBLL();
        public CustomerRegister()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            BLL.CustomerInsertInfo(textBox1.Text,comboBox1.Text,textBox3.Text,comboBox2.Text,textBox5.Text);
                MessageBox.Show("添加成功");
                Operation.Clear(this);
            }
            catch
            {
                MessageBox.Show("添加失败");
            }
        }
    }
}
