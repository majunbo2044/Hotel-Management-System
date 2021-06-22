using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
namespace BLL
{
  public  class InHistoryBLL
    {
        DAL.InHistoryDAL DAL = new InHistoryDAL();
        public bool Insert(string CustomerName, string RoomID, string OutDate,string Worker)
        {
         return   DAL.Insert( CustomerName,  RoomID,  OutDate,Worker);
        }

        public DataTable GetInfo()
        {
            return DAL.GetInfo();
        }
    }
}
