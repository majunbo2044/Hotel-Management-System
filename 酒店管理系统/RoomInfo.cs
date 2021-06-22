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
    public partial class RoomInfo : Form
    {
        RoomInfoBLL BLL = new RoomInfoBLL();
        public RoomInfo()
        {
            int NullRoom = 0;
            int RoomCount = 20;
            InitializeComponent();
            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    if(BLL.isnull(item.Text))
                    {
                    item.BackColor = Color.Green;
                        NullRoom++;
                    }
                    else
                        item.BackColor = Color.Red;
                }
            }
            label1.Text += Convert.ToString(RoomCount);
            label2.Text += Convert.ToString(NullRoom);
            label3.Text += Convert.ToString(RoomCount-NullRoom);
            label4.Text = label4.Text +(RoomCount-NullRoom)*100/RoomCount+"%";
            
        }

       
    }
}
