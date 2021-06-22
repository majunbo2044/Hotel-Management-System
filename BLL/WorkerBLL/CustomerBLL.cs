using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
namespace BLL
{
   public class CustomerBLL
    {
        CustomerDAL DAL = new CustomerDAL();
        public DataTable GetInfo()
        {
            return DAL.GetInfo();
        }
        public DataTable GetInfo(string type)
        {
            return DAL.GetInfo(type);
        }
        public DataTable GetInfo(string type,string name)
        {
            return DAL.GetInfo(type,name);
        }
    }
}
