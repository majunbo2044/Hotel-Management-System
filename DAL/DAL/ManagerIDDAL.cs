using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAL
{
   public class ManagerIDDAL
    {
        SqlDb sqldb = new SqlDb();
        public bool JudgeManager(string ID, string Password)
        {
            string sqlstr = "select ManagerName,ManagerPassword from Manager where ManagerName='" + ID + "' and ManagerPassword='" + Password + "'";
            DataTable dt = sqldb.FillDt(sqlstr);
            if (dt.Rows.Count < 1)
            {
                return false;
            }
            else if (dt.Rows[0]["ManagerName"].ToString() == ID && dt.Rows[0]["ManagerPassword"].ToString() == Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        } //验证登陆信息

        public DataTable GetInfo()
        {
            string sqlstr = "select * from Manager";
            DataTable dt = sqldb.FillDt(sqlstr);
            return dt;
        } //获取管理员信息

        public DataTable GetInfo(string type)
        {
            string sqlstr = null;
            if (type == "按编号")
            { sqlstr = "select * from Manager order by ManagerID"; }
            else 
            { sqlstr = "select * from Manager order by ManagerName"; }
            
            DataTable dt = sqldb.FillDt(sqlstr);
            return dt;
        }

        public DataTable GetInfo(string type, string name)
        {
            string sqlstr = null;
            if (type == "精准查找")
            { sqlstr = "select * from Manager where ManagerName = '" + name + "'"; }
            else
            { sqlstr = "select * from Manager where ManagerName like '" + name + "%'"; }
            DataTable dt = sqldb.FillDt(sqlstr);
            return dt;
        }
        public bool DeleteManager(string name)
        {
            string sqlstr = "delete from Manager where ManagerName ='"+name+"'";
          bool op =  sqldb.ExecSql(sqlstr);
            return op;
        }
    }
}
