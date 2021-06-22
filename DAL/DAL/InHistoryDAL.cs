using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAL
{
   public class InHistoryDAL
    {
        SqlDb sqldb = new SqlDb();
        public bool Insert(string CustomerName,string RoomID, string OutDate,string Worker)//bug： InID  静态
        {
            string sqlstr = "select CustomerID,CustomerType from Customer where CustomerName ='"+CustomerName+"'";
           DataTable dt =  sqldb.FillDt(sqlstr);
            string CustomerID =(String) dt.Rows[0]["CustomerID"];
            string CustomerType = (String)dt.Rows[0]["CustomerType"];
            string CustomerInDate = DateTime.Now.ToShortDateString().ToString();
            sqlstr = "select WorkerID from Worker where WorkerName='"+Worker+"'";
            DataTable dt2 = sqldb.FillDt(sqlstr);
            string WorkerID = (String)dt2.Rows[0]["WorkerID"];

             sqlstr = "select max(InID) InID from InHistory";
            DataTable dt3 = new DataTable();
            dt3 = sqldb.FillDt(sqlstr);
            int InID = new int();
            try
            {
                InID = Convert.ToInt32(dt3.Rows[0]["InID"]);
            }
            catch
            {
                InID = 0;
            }
            InID++;
            sqlstr = "insert into InHistory(InID,CustomerID,CustomerType,CustomerInDate,CustomerOutDate,RoomID,Worker) values('" +Convert.ToString(InID)+"','"+CustomerID + "','" + CustomerType + "','" + CustomerInDate + "','" + OutDate + "','" + RoomID + "','" + WorkerID + "')";
         bool op=  sqldb.ExecSql(sqlstr);
            return op;
            
        }

        public DataTable GetInfo()
        {
            string sqlstr = "select * from InHistory";
            DataTable dt = sqldb.FillDt(sqlstr);
            return dt;
        }
    }
}
