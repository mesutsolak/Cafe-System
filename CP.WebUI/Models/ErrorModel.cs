using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CP.WebUI.Models
{
    public class ErrorModel
    {
        public ErrorModel()
        {
            Exception = null;
        }
        public string Title { get; set; }
        public string Source { get; set; }
        public string Url { get; set; }
        public Exception Exception { get; set; }
    }
}