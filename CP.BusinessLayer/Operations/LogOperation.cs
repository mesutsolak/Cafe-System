using CP.Entities.Migrations;
using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class LogOperation
    {
        static CafeProjectModel db = new CafeProjectModel();
        public static void LogInfoAdd(LogInfo logInfo)
        {
            db.LogInfo.Add(logInfo);
            db.SaveChanges();
        }
        public static void LogAdd(Log log)
        {
            db.Log.Add(log);
            db.SaveChanges();
        }
    }
}
