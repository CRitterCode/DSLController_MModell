using DSLController_MModell;
using DSLController_MModell.MetaModell.Result;
using DSLController_MModell.MetaModell.Attribute;
using DSLController_MModell.MetaModell.Action;
using Scriban;
using DSLController_MModell.Generator;


var builder = ControllerBuilder
    .Init("User")
    .WithAuthorize()
    .WithRoute("api/[Controller]")
    .WithAction("Get", HttpMethod.Get)
        .WithParameter<int>("id", MHttpBinding.Route)
        .WithAuthorize(MRole.User, MRole.Admin)
        .Returns<MIActionResult>()
    .Controller("Backoffice")
        .WithRoute("opentimes")
        .WithAuthorize(MRole.AllowAnonymus)
        .WithAntiforgery(true)
        .WithAction("SetOpenTimes", HttpMethod.Post)
            .WithValidateModel()
            .WithRoute("opentimes")
            .Returns<MActionResult<List<int>>>()
            .Done()
    .Build();


var templateText = @"
{{ for attr in controller.attributes }}
{{ attr }}{{ end }}
public class {{ controller.name }}
{
    {{ for action in controller.actions }}
    {{ for attr in action.attributes }}
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
";

var generators = ControllerGenerator.Generate(builder);
var template = Template.Parse(templateText);

foreach (var generator in generators)
{
    var result = template.Render(new { controller = generator });
    Console.WriteLine(result);
}

//var filePath = "D:\\projects\\private\\DSLController_MModell\\generated.cs";
//File.WriteAllText(filePath, result);




