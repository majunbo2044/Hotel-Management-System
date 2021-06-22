using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
namespace BLL
{
   public class OutHistoryBLL
    {
        OutHistoryDAL DAL = new OutHistoryDAL();
        public double Out(string CustomerName,string WorkerName)
        {
            return DAL.Out(CustomerName, WorkerName);
        }

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
