using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLController_MModell.Generator.Template
{
    public class ActionTemplate
    {
        public string Name { get; set; }
        public List<string> Attributes { get; set; } = new();
        public List<ParameterTemplate> Parameters { get; set; } = new();
        public string Returntype { get; set; }
        public bool Validatebinding { get; set; }
    }

}
