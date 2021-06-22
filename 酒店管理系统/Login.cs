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
    public partial class Login : Form
    {
        WorkerIDBLL workerbll = new WorkerIDBLL();
        ManagerIDBLL managerbll = new ManagerIDBLL();
        public Login()
        {
            InitializeComponent();
        }

        private void Loginbutton_Click(object sender, EventArgs e)
        {
            string ID = LogintextBox.Text.Trim();
            string Password = PasswordtextBox.Text;


            if (WorkerradioButton.Checked == true)
            {
                bool Judge = workerbll.JudgeWorker(ID, Password);
                if (Judge)
                {
                    this.Hide();
                    MessageBox.Show(ID + "员工登陆成功！");
                    new WorkerMain(ID).ShowDialog(this);
                    this.Show();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误，请重新输入！");
                }
              
            }
            else if (ManagerradioButton .Checked == true)
            {
                bool Judge = managerbll.JudgeManager(ID, Password);
                if (Judge)
                {   this.Hide();
                    MessageBox.Show(ID + "管理员登陆成功！");
                    new ManagerMain(ID).ShowDialog(this);
                    this.Show();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误，请重新输入！");
                }
            }
           
            else
            {
                MessageBox.Show("请选择用户身份登录！");

            }
            
            PasswordtextBox.Text = "";
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerRegister customerRegister = new CustomerRegister();
            customerRegister.Show();
        }

        
    }
}
