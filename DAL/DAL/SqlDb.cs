using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
  
    class SqlDb
    {
        public SqlConnection conn = null;
        public SqlCommand cmd = null;
        public SqlDataAdapter dA = null;
        public SqlDb()
        {
            conn = new SqlConnection(@"server=.;DataBase=HotelManagementLibrary;uid=sa;pwd=123456");
            cmd = new SqlCommand();
            cmd.Connection = conn;
            dA = new SqlDataAdapter("", conn);
        }
        public bool ExecSql(string sqlStr)  //执行sql语句
        {
            try
            {
                int i;
                conn.Open();
                cmd = new SqlCommand(sqlStr, conn);
                i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public DataTable FillDt(string selectSql) 
        {
            DataTable dt = new DataTable();
            dA = new SqlDataAdapter(selectSql, conn);
            dA.Fill(dt);
            return dt;
        }

       
    }
}
