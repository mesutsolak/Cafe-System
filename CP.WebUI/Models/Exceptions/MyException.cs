using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.WebUI.Models.Exceptions
{
    public class MyException:Exception
    {
        public MyException(string message):base(message)
        {
                
        }
    }
}