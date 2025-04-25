using DSLController_MModell.Generator.Template;
using Scriban;

namespace DSLController_MModell
{
    public static class ScribanGenerator
    {
        public static string ControllerPath { get; set; } = Directory.GetCurrentDirectory();


        public static string TemplateText => @"{{ for use in controller.usings }}using {{ use }};
{{ end }}
namespace {{ controller.namespace }}
{
{{ for attr in controller.attributes }}
{{ attr }}{{ end }}
public class {{ controller.name }}{
    {{ for action in controller.actions }}{{ for attr in action.attributes }}
        {{ attr }}{{ end }}
    public {{ action.returntype }} {{ action.name }}({{ for param in action.parameters }}{{ param.binding }} {{ param.type }} {{ param.name }}{{ end }}){
        {{ if action.validatebinding }}
     if (ModelState.IsValid){
        return BadRequest(ModelState);
     }{{ end}}
        throw new NotImplementedException();
     }
    {{ end }}
  }
}
";

        private static Template Template => Template.Parse(TemplateText);

        public static void Generate(List<ControllerTemplate> controllers)
        {
            foreach (var ctrl in controllers) {
                var result = Template.Render(new { controller = ctrl });
                Console.WriteLine(result);
                File.WriteAllText($"{ControllerPath}/{ctrl.Name.Split(':')[0].Trim()}.cs", result);
            }
        }










    }
}
