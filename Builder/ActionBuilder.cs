using DSLController_MModell.MetaModell;
using DSLController_MModell.MetaModell.Action;
using DSLController_MModell.MetaModell.Attribute;
using DSLController_MModell.MetaModell.Result;

namespace DSLController_MModell.Builder
{
    public class ActionBuilder
    {
        private readonly ControllerBuilder _parent;
        private readonly MController _controller;
        private readonly MAction _action;

        public ActionBuilder(ControllerBuilder parent, MController controller, MAction action)
        {
            _parent = parent;
            _controller = controller;
            _action = action;
        }

        public ActionBuilder WithParameter<T>(string name, MHttpBinding binding = MHttpBinding.None)
        {
            _action.Parameters.Add(new MParameter(name, typeof(T), binding));
            return this;
        }

        public ActionBuilder WithRoute(string route)
        {
            _action.Attributes.Add(new MRoute(route));
            return this;
        }

        public ActionBuilder WithAuthorize(params MRole[] role)
        {
            _action.Attributes.Add(new MAuthorize(role));
            return this;
        }

        public ActionBuilder WithValidateModel()
        {
            _action.Validatebinding = true;
            return this;
        }

        public ActionBuilder Returns<T>() where T : IMResult, new()
        {
            _action.Result = new T();
            return this;
        }

        public ActionBuilder WithConsumes(string mediaType)
        {
            _action.Attributes.Add(new MConsumes(mediaType));
            return this;
        }

        public ActionBuilder WithAntiforgery(bool ignoreAntiforgery = false)
        {
            _action.Attributes.Add(new MAntiforgery(ignoreAntiforgery));
            return this;
        }

        public ActionBuilder WithProduces(string mediaType)
        {
            _action.Attributes.Add(new MProduces(mediaType));
            return this;
        }
        public ControllerBuilder Done()
        {
            _controller.Actions.Add(_action);
            return _parent;
        }

        public ControllerBuilder Controller(string name, string nspace) => Done().Controller(name, nspace);
    }

}
