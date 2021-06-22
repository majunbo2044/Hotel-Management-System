using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAL
{
  public  class RoomInfoDAL
    {
        SqlDb sqldb = new SqlDb();
        public bool isnull(string number)
        {
            string sqlstr = "select RoomState from Room where RoomID = '" + number+"'";
            DataTable dt = sqldb.FillDt(sqlstr);
            if((String)dt.Rows[0]["RoomState"] == "未入住")
            {           return true;
            }
            else
            return false;
        }

        public string RoomType(string number)
        {
            string sqlstr = "select RoomType from Room where RoomID = '" + number + "'";
            DataTable dt = sqldb.FillDt(sqlstr);
            return (String)dt.Rows[0]["RoomType"];
        }

        public string RoomPrice(string number)
        {
            string sqlstr = "select RoomPrice from Room where RoomID = '" + number + "'";
            DataTable dt = sqldb.FillDt(sqlstr);
            return Convert.ToString(dt.Rows[0]["RoomPrice"]);
        }

        public bool HasRoom(string number)
        {
            string sqlstr = "select RoomID from Room where RoomID = '" + number + "'";
            DataTable dt = sqldb.FillDt(sqlstr);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool StateChange(string number)
        {
            string sqlstr = "update Room set RoomState ='已入住' where RoomID ='"+number+"'";
          bool op=  sqldb.ExecSql(sqlstr);
            return op;
        }

        public bool StateChange2(string CustomerName)
        {
            string sqlstr = "select CustomerID from Customer where CustomerName='"+CustomerName+"'";
            DataTable dt = sqldb.FillDt(sqlstr);
            string CustomerID = (String)dt.Rows[0]["CustomerID"];
             sqlstr = "select RoomID from InHistory where CustomerID ='"+ CustomerID + "'";
            DataTable dt2 = sqldb.FillDt(sqlstr);
            string RoomID = (String)dt2.Rows[0]["RoomID"];
            sqlstr = "update Room set RoomState ='未入住' where RoomID ='" + RoomID + "'";
            bool op = sqldb.ExecSql(sqlstr);
            return op;
        }

        public DataTable GetInfo()
        {
            string sqlstr = "select * from Room";
            DataTable dt = sqldb.FillDt(sqlstr);
            return dt;
        }

        public bool update(string RoomID,string RoomType,string RoomPrice,string RoomState)
        {
            bool op = false;
            string sqlstr = "update Room set RoomType='"+RoomType+"',RoomPrice='"+RoomPrice+"',RoomState='"+RoomState+"' where RoomID='"+RoomID+"'";
            try
            {
                op = sqldb.ExecSql(sqlstr);
            }
            catch
            {

            }
            return op;
        }
    }
}
