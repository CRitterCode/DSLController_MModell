using DSLController_MModell.MetaModell;
using DSLController_MModell.MetaModell.Action;
using DSLController_MModell.MetaModell.Attribute;

namespace DSLController_MModell.Builder
{
    public class ControllerBuilder
    {
        private readonly HashSet<MController> _controllers = new();
        private MController _currentController = new();

        public static ControllerBuilder Init(string name, string nspace)
        {
            var builder = new ControllerBuilder();
            builder.Controller(name, nspace);
            return builder;
        }

        private ControllerBuilder() { }

        public ControllerBuilder WithRoute(string route)
        {
            _currentController.Attributes.Add(new MRoute(route));
            return this;
        }

        public ControllerBuilder WithAuthorize(params MRole[] roles)
        {
            _currentController.Attributes.Add(new MAuthorize(roles));
            return this;
        }

        public ControllerBuilder SetAntiforgery(bool isAntiforgery)
        {
            _currentController.Attributes.Add(new MAntiforgery(isAntiforgery));
            return this;
        }

        public ActionBuilder WithAction(string name, HttpMethod method)
        {
            var action = new MAction();
            action.Attributes.Add(new MHttpMethod(method));
            action.Name = new MName(name);
            return new ActionBuilder(this, _currentController, action);
        }

        public ControllerBuilder Controller(string name, string nspace)
        {
            _currentController = new MController();
            _currentController.ControllerName.Name = name;
            _currentController.Namespace.Name = nspace;
            _controllers.Add(_currentController);
            return this;
        }

        public HashSet<MController> Build() => _controllers;
    }

}
