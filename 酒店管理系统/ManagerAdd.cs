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
    public partial class ManagerAdd : Form
    {
        RegisterBLL BLL = new RegisterBLL();
        public ManagerAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(BLL.ManagerInsert(textBox1.Text,textBox2.Text))
            {
                MessageBox.Show("添加成功！");
            }
            else
            MessageBox.Show("添加失败！");
            
        }
    }
}
