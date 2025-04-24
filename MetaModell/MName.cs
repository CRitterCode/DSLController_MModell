using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLController_MModell.MetaModell
{
    public class MName
    {
        public string Name { get; set; } = string.Empty;

        public MName(string name = "")
        {
            Name = name;
        }
    }
}
