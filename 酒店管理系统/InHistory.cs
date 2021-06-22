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
    public partial class InHistory : Form
    {
        InHistoryBLL BLL = new InHistoryBLL();
        public InHistory()
        {
            InitializeComponent();
            dataGridView1.DataSource = BLL.GetInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
