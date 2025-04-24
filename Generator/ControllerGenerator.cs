using DSLController_MModell.Generator.Template;
using DSLController_MModell.MetaModell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLController_MModell.Generator
{
    public static class ControllerGenerator
    {
        public static List<ControllerTemplate> Generate(IEnumerable<MController> controllers)
        {
            return controllers.Select(ctrl => new ControllerTemplate
            {
                Name = ctrl.Name.Name+"Controller : ControllerBase",
                Attributes = ctrl.Attributes.Select(AttributeHelper.Render).ToList(),
                Actions = ctrl.Actions.Select(ActionGenerator.Generate).ToList()
            }).ToList();
        }
    }

}
