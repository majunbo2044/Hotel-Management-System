using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace 酒店管理系统
{
    class Operation
    {
        public static void Clear(Form us)
        {
            foreach (Control item in us.Controls)
            {
                if (item is TextBox || item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }
    }
}
