using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Entities.ViewModel
{
    public class ProcCatViewModel
    {
        public IList<string> Category { get; set; }
        public IList<int> Product { get; set; }
    }
}
