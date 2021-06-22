using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class RegisterDAL
    {
        SqlDb sqldb = new SqlDb();

        public bool CustomerInsertInfo(string CustomerName, string CustomerSex, string CustomerIDNumber, string CustomerType, string CustomerPhone)
        {
            string sqlstr = "select max(CustomerID) CustomerID from Customer";
            DataTable dt = new DataTable();
            dt = sqldb.FillDt(sqlstr);
            int CustomerNumber = Convert.ToInt32(dt.Rows[0]["CustomerID"]);
            CustomerNumber++;
            string CustomerInDate = DateTime.Now.ToShortDateString().ToString();
            sqlstr = "insert into Customer(CustomerID,CustomerName,CustomerSex,CustomerIDNumber,CustomerType,CustomerPhone,CustomerCreateDate) values('" + Convert.ToString(CustomerNumber) + "','" + CustomerName + "','" + CustomerSex + "','" + CustomerIDNumber + "','" + CustomerType + "','" + CustomerPhone + "','" + CustomerInDate + "')";
            bool op = sqldb.ExecSql(sqlstr);
            return op;
        }

        public bool ManagerInsert(string name,string pwd)
        {
            string sqlstr = "select max(ManagerID) ManagerID from Manager";
            DataTable dt = new DataTable();
            dt = sqldb.FillDt(sqlstr);
            int ManagerID = new int();
            try
            {
                ManagerID = Convert.ToInt32(dt.Rows[0]["ManagerID"]);
            }
            catch
            {
                ManagerID = 0;
            }
            ManagerID++;
            try
            {
             sqlstr = "insert into Manager(ManagerID,ManagerName,ManagerPassword) values('"+ ManagerID +"','"+name+"','"+pwd+"')";
                sqldb.ExecSql(sqlstr);
            }
            catch
            {
                return false;
            }
            return true;

        }
        
    }
}
