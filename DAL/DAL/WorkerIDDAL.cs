using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAL
{
    public class WorkerIDDAL
    {
        SqlDb sqldb = new SqlDb();
        public bool JudgeWorker(string ID,string Password)
        {
            string sqlstr = "select WorkerName,WorkerPassword from Worker where WorkerName='"+ID+"' and WorkerPassword='"+Password+"'";
            DataTable dt = sqldb.FillDt(sqlstr);
            if (dt.Rows.Count < 1)
            {
                return false;
            }
            else if(dt.Rows[0]["WorkerName"].ToString() == ID && dt.Rows[0]["WorkerPassword"].ToString() == Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable GetInfo()
        {
            string sqlstr = "select * from Worker";
            DataTable dt = sqldb.FillDt(sqlstr);
            return dt;
        }
    }
}
