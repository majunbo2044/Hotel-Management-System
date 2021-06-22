using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAL
{
  public  class OutHistoryDAL
    {
        SqlDb sqldb = new SqlDb();
        public double Out(string CustomerName,string WorkerName)  
        {
            string sqlstr = "select WorkerID from Worker where WorkerName ='"+ WorkerName + "'";
            DataTable dt3 = sqldb.FillDt(sqlstr);
            string WorkerID = (String)dt3.Rows[0]["WorkerID"];
            sqlstr = "select CustomerID from Customer where CustomerName = '" + CustomerName + "'";
            DataTable dt = sqldb.FillDt(sqlstr);
            if (dt.Rows.Count > 0)   //判断客户存在
            {
                string CustomerID = (String)dt.Rows[0]["CustomerID"];
                sqlstr = "select CustomerID,CustomerType,CustomerInDate,CustomerOutDate,RoomID from InHistory where CustomerID='" + CustomerID + "'";
                DataTable dt2 = sqldb.FillDt(sqlstr);
                if (dt2.Rows.Count > 0)  //判断客户入住
                {  string RoomID = (String)dt2.Rows[0]["RoomID"];
                    sqlstr = "select RoomState from Room where RoomID='"+ RoomID + "'";
                    DataTable dt7 = new DataTable();
                    dt7 = sqldb.FillDt(sqlstr);
                    if ((String)dt7.Rows[0]["RoomState"] == "已入住")  //防止多次退房
                    {
                        string CustomerType = (String)dt2.Rows[0]["CustomerType"];
                        DateTime CustomerInDate = (DateTime)dt2.Rows[0]["CustomerInDate"];
                        DateTime CustomerOutDate = (DateTime)dt2.Rows[0]["CustomerOutDate"];

                        string InDate = CustomerInDate.ToShortDateString().ToString();
                        string OutDate = CustomerOutDate.ToShortDateString().ToString();
                        double Fine = new double();
                        long x = DateTime.Now.ToFileTime();
                        long y = CustomerOutDate.ToFileTime();
                        long z = (x - y) / 864000000000;  //超时住宿天数
                        if (z > 0) //计算罚款金额
                        {
                            sqlstr = "select RoomPrice from Room where RoomID = '" + RoomID + "'";
                            DataTable dt5 = sqldb.FillDt(sqlstr);
                            double price = Convert.ToDouble(dt5.Rows[0]["RoomPrice"]);
                            sqlstr = "select Fine from CustomerType where TypeName ='" + CustomerType + "'";
                            DataTable dt6 = sqldb.FillDt(sqlstr);
                            double times = Convert.ToDouble(dt6.Rows[0]["Fine"]);
                            Fine = (z * price * times);
                        }
                        else
                        {
                            Fine = 0;
                        }
                        sqlstr = "select max(OutID) OutID from OutHistory";
                        DataTable dt4 = new DataTable();
                        dt4 = sqldb.FillDt(sqlstr);
                        int OutID = new int();
                        try
                        {
                            OutID = Convert.ToInt32(dt4.Rows[0]["OutID"]);
                        }
                        catch
                        {
                            OutID = 0;
                        }
                        OutID++;
                        sqlstr = "insert into OutHistory(OutID,CustomerID,CustomerType,CustomerInDate,CustomerOutDate,RoomID,Fine,Worker) values('" + OutID + "','" + CustomerID + "','" + CustomerType + "','" + InDate + "','" + OutDate + "','" + RoomID + "','" + Fine + "','" + WorkerID + "')";
                        if (sqldb.ExecSql(sqlstr))
                            return Fine;
                        else
                            return -1;
                    }
                    else
                        return -1;
                    
                }
                else
                    return -1;
            }
            else
                return -1;
            
            
        }

        public DataTable GetInfo()
        {
            string sqlstr = "select * from OutHistory";
            DataTable dt = sqldb.FillDt(sqlstr);
            return dt;
        }

        public DataTable GetInfo(string type,string name)
        {
            string sqlstr = null;
            if (type == "精准查找")
            { sqlstr = "select * from OutHistory where CustomerName = '" + name + "'"; }
            else
            { sqlstr = "select * from OutHistory where CustomerName like '" + name + "%'"; }
            DataTable dt = sqldb.FillDt(sqlstr);
            return dt;
        }

        public DataTable GetInfo(string type)
        {
            string sqlstr = null;
            if (type == "按编号")
            { sqlstr = "select * from Customer order by CustomerID"; }
            else if (type == "按姓名")
            { sqlstr = "select * from Customer order by CustomerName"; }
            else
            { sqlstr = "select * from Customer order by CustomerType"; }
            DataTable dt = sqldb.FillDt(sqlstr);
            return dt;
        }
    }
}
