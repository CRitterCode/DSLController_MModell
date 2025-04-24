using DSLController_MModell.Generator.Template;
using DSLController_MModell.MetaModell.Action;

namespace DSLController_MModell.Generator
{
    public static class ActionGenerator
    {
        public static ActionTemplate Generate(MAction action)
        {
            return new ActionTemplate
            {
                Name = action.Name.Name,
                Attributes = action.Attributes
                    .Select(AttributeHelper.Render)
                    .ToList(),
                Parameters = action.Parameters.Select(p => new ParameterTemplate
                {
                    Name = p.Name,
                    Type = TypeHelper.GetFullTypeAsString(p.Type),
                    Binding = p.Binding.ToString()
                }).ToList(),
                Returntype = action.Result != null
                    ? TypeHelper.GetFullTypeAsString(action.Result.GetType())
                    : "IActionResult",
                Validatebinding = action.Validatebinding
            };
        }
    }
}
