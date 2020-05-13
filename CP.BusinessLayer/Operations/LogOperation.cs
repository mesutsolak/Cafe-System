using CP.Entities.Migrations;
using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.BusinessLayer.Operations
{
    public class LogOperation
    {
        static CafeProjectModel db = new CafeProjectModel();
        public static void LogInfoAdd(LogInfoes logInfo)
        {
            db.LogInfoes.Add(logInfo);
            db.SaveChanges();
        }
        public static void LogAdd(Log log)
        {
            db.Log.Add(log);
            db.SaveChanges();
        }
    }
}
