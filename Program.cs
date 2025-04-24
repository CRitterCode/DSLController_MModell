using DSLController_MModell.MetaModell.Result;
using DSLController_MModell.MetaModell.Attribute;
using DSLController_MModell.MetaModell.Action;
using Scriban;
using DSLController_MModell.Generator;
using DSLController_MModell.Builder;
using DSLController_MModell;


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

ScribanGenerator.Generate(ControllerGenerator.Generate(builder));





