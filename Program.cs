using DSLController_MModell.MetaModell.Result;
using DSLController_MModell.MetaModell.Attribute;
using DSLController_MModell.MetaModell.Action;
using DSLController_MModell.Generator;
using DSLController_MModell.Builder;
using DSLController_MModell;


var builder = ControllerBuilder
    .Init("User", "DSLController_MModell")
    .WithAuthorize()
    .WithRoute("api/[controller]")
    .WithAction("Get", HttpMethod.Get)
        .WithParameter<int>("id", MHttpBinding.Route)
        .WithAuthorize(MRole.User, MRole.Admin)
        .Returns<MIActionResult>()
    .Controller("Backoffice", "DSLController_MModell")
        .WithRoute("opentimes")
        .WithAuthorize(MRole.AllowAnonymus)
        .SetAntiforgery(true)
        .WithAction("SetOpenTimes", HttpMethod.Post)
            .WithValidateModel()
            .WithRoute("opentimes")
            .Returns<MActionResult<List<int>>>()
            .Done()
        .WithAction("GetOpenTimes", HttpMethod.Get)
            .WithProduces("application/json")
            .WithRoute("opentimes/all")
            .Returns<MIActionResult>()
            .Done()
    .Build();

ScribanGenerator.Generate(ControllerGenerator.Generate(builder));





