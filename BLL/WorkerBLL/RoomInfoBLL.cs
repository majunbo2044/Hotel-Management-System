using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
namespace BLL
{
  public  class RoomInfoBLL
    {
        RoomInfoDAL DAL = new RoomInfoDAL();
        public bool isnull(string number)
        {
            return DAL.isnull(number);
        }

        public string RoomType(string number)
        {
            return DAL.RoomType(number);
        }
        public string RoomPrice(string number)
        {
            return DAL.RoomPrice(number);
        }

        public bool HasRoom(string number)
        {
            return DAL.HasRoom(number);
        }

        public bool StateChange(string number)
        {
          return   DAL.StateChange(number);
        }

        public bool StateChange2(string CustomerName)
        {
            return DAL.StateChange2(CustomerName);
        }

        public DataTable GetInfo()
        {
            return DAL.GetInfo();
        }

        public bool Update(string RoomID, string RoomType, string RoomPrice, string RoomState)
        {
            return DAL.update( RoomID,  RoomType,  RoomPrice,  RoomState);
        }
    }
}
