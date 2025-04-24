using DSLController_MModell.MetaModell;
using DSLController_MModell.MetaModell.Action;
using DSLController_MModell.MetaModell.Attribute;
using DSLController_MModell.MetaModell.Result;

namespace DSLController_MModell
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

        public ActionBuilder WithParameter<T>(string name, MHttpBinding binding = MHttpBinding.Body)
        {
            _action.Parameters.Add(new MParameter
            {
                Name = name,
                Type = typeof(T),
                Binding = binding
            });
            return this;
        }

        public ActionBuilder WithRoute(string route)
        {
            _action.Attributes.Add(new MRoute { Route = route });
            return this;
        }

        public ActionBuilder WithAuthorize(MRole role = MRole.Authorized)
        {
            _action.Attributes.Add(new MAuthorize { Role = role });
            return this;
        }

        public ActionBuilder WithValidateModel()
        {
            _action.Validatebinding = true;
            return this;
        }

        public ActionBuilder Returns<T>() where T : IMResult, new()
        {
            _action.Result = new T().GetType().Name;
            return this;
        }

        public ActionBuilder WithConsumes(string mediaType)
        {
            _action.Attributes.Add(new MConsumes { MediaType = mediaType });
            return this;
        }

        public ActionBuilder WithAntiforgery(bool ignoreAntiforgery = false)
        {
            _action.Attributes.Add(new MAntiforgery(ignoreAntiforgery));
            return this;
        }

        public ActionBuilder WithProduces(string mediaType)
        {
            _action.Attributes.Add(new MProduces { MediaType = mediaType });
            return this;
        }
        public ControllerBuilder Done()
        {
            _controller.Actions.Add(_action);
            return _parent;
        }

        public ControllerBuilder Controller(string name) => Done().Controller(name);
    }

}
