using DSLController_MModell.MetaModell;
using DSLController_MModell.MetaModell.Action;
using DSLController_MModell.MetaModell.Attribute;

namespace DSLController_MModell
{
    public class ControllerBuilder
    {
        private readonly HashSet<MController> _controllers = new();
        private MController _currentController = new();

        public static ControllerBuilder Init(string name)
        {
            var builder = new ControllerBuilder();
            builder._currentController = new MController();
            builder._currentController.Name = new MName(name);
            builder._controllers.Add(builder._currentController);
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

        public ControllerBuilder WithAntiforgery(bool ignoreAntiforgery = false)
        {
            _currentController.Attributes.Add(new MAntiforgery(ignoreAntiforgery));
            return this;
        }

        public ActionBuilder WithAction(string name, HttpMethod method)
        {
            var action = new MAction();
            action.Attributes.Add(new MHttpMethod(method));
            action.Name = new MName(name);
            return new ActionBuilder(this, _currentController, action);
        }

        public ControllerBuilder Controller(string name)
        {
            _currentController = new MController();
            _currentController.Name.Name = name;
            _controllers.Add(_currentController);
            return this;
        }

        public HashSet<MController> Build() => _controllers;
    }

}
