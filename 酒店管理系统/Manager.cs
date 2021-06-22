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
    public partial class Manager : Form
    {
        ManagerIDBLL BLL = new ManagerIDBLL();
        public Manager()
        {
            InitializeComponent();
            dataGridView1.DataSource = BLL.GetInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("你确定要删除管理员" + textBox1.Text + "吗？", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)

            {
                

              if(  BLL.DeleteManager(textBox1.Text))
                {
                    MessageBox.Show("删除成功");
                }
                else
                    MessageBox.Show("删除失败");
                dataGridView1.DataSource = BLL.GetInfo();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.GetInfo(comboBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.GetInfo(comboBox2.Text, textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ManagerAdd managerAdd = new ManagerAdd();
            managerAdd.ShowDialog();
            dataGridView1.DataSource = BLL.GetInfo();
        }
    }
}
