using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
namespace BLL
{
   public class ManagerIDBLL
    {
        ManagerIDDAL DAL = new ManagerIDDAL();
        public bool JudgeManager(string ID, string Password)
        {
            return DAL.JudgeManager(ID, Password);
        }
        public DataTable GetInfo()
        {
            return DAL.GetInfo();
        }

        public DataTable GetInfo(string type)
        {
            return DAL.GetInfo(type);
        }
        public DataTable GetInfo(string type, string name)
        {
            return DAL.GetInfo(type, name);
        }
        public bool DeleteManager(string name)
        {
           return  DAL.DeleteManager(name);
        }
    }
    
}
