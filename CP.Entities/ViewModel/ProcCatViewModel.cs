using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Entities.ViewModel
{
    public class ProcCatViewModel
    {
        public ProcCatViewModel()
        {
            Category = new List<string>();
            Product = new List<int>();
        }
        public List<string> Category { get; set; }
        public List<int> Product { get; set; }
    }
}
