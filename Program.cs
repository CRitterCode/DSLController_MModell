using DSLController_MModell;
using DSLController_MModell.MetaModell.Result;
using DSLController_MModell.MetaModell.Attribute;
using DSLController_MModell.MetaModell.Action;
using Scriban;


var builder = ControllerBuilder
    .Init("User")
    .WithAuthorize()
    .WithRoute("/")
    .WithRoute("Index")
    .WithAction("Get", HttpMethod.Get)
        .WithParameter<int>("id", MHttpBinding.Route)
        .WithAuthorize(MRole.User)
        .Returns<MIActionResult>()
    .Controller("Backoffice")
        .WithRoute("opentimes")
        .WithAuthorize()
        .WithAntiforgery(true)
        .WithAction("SetOpenTimes", HttpMethod.Post)
            .WithValidateModel()
            .WithRoute("opentimes")
            .Returns<MT<List<string>>>()
            .Done()
    .Build();


foreach (var item in builder)
{
    Console.WriteLine(item.Name.Name);

    foreach (var item2 in item.Actions)
    {
        Console.WriteLine(item2.Name.Name);
        Console.WriteLine(item2.Attributes.Count);
        Console.WriteLine(item2.Validatebinding);
        foreach (var item3 in item.Attributes)
        {
            Console.WriteLine(item3.GetType().GetProperties().FirstOrDefault().GetValue(item3));
        }
    }
}

var templateText = @"
{{ for controller in controllers }}
public class {{ controller.name.name }}
{
    {{ for action in controller.actions }}
{{ for attr in action.attributes }}
    {{ attr }}
{{ end }}
    public {{ action.result }} {{ action.name.name }}()
    {
        {{ if action.validatebinding }}
            if (!ModelState.IsValid()){
                return BadRequest(ModelState);
                }
        {{ end }}
    }

    {{ end }}
}
{{ end }}
";

var template = Template.Parse(templateText);
var result = template.Render(new { controllers = builder });

//var filePath = "D:\\projects\\private\\DSLController_MModell\\generated.cs";
//File.WriteAllText(filePath, result);

Console.WriteLine(result);

