using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
namespace BLL
{
   
    public class WorkerIDBLL
    {
        WorkerIDDAL DAL = new WorkerIDDAL();
        public bool JudgeWorker(string ID,string Password)
        {
            return DAL.JudgeWorker(ID,Password);
        }

        public DataTable GetInfo()
        {
            return DAL.GetInfo();
        }
    }
}
