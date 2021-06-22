using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAL
{
   public class CustomerDAL
    {
        SqlDb sqldb = new SqlDb();
        
        public DataTable GetInfo()
        {
            string sqlstr = "select * from Customer";
            DataTable dt = sqldb.FillDt(sqlstr);
            return dt;
        }
        public DataTable GetInfo(string type)
        {
            string sqlstr = null;
            if (type == "按编号")
            {  sqlstr = "select * from Customer order by CustomerID"; }
           else if (type == "按姓名")
            {  sqlstr = "select * from Customer order by CustomerName"; }
            else
            {  sqlstr = "select * from Customer order by CustomerType"; }
            DataTable dt = sqldb.FillDt(sqlstr);
            return dt;
        }

        public DataTable GetInfo(string type,string name)
        {
            string sqlstr = null;
            if (type == "精准查找")
            { sqlstr = "select * from Customer where CustomerName = '"+name+"'"; }
            else
            { sqlstr = "select * from Customer where CustomerName like '" + name + "%'"; }
            DataTable dt = sqldb.FillDt(sqlstr);
            return dt;
        }
    }
}
