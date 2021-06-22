using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public   class RegisterBLL
    {
        RegisterDAL DAL = new RegisterDAL();
        public bool CustomerInsertInfo(string CustomerName, string CustomerSex, string CustomerIDNumber, string CustomerType, string CustomerPhone)
        {
            return DAL.CustomerInsertInfo( CustomerName,  CustomerSex,  CustomerIDNumber,  CustomerType,  CustomerPhone);
        }

        public bool ManagerInsert(string name,string pwd)
        {
            return DAL.ManagerInsert(name, pwd);

        }
             
    }
}
