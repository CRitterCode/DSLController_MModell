using DSLController_MModell.MetaModell.Attribute;
using DSLController_MModell.MetaModell.Result;

namespace DSLController_MModell.MetaModell.Action
{
    public class MAction
    {
        public HashSet<IMAttribute> Attributes { get; } = new();
        public HashSet<MParameter> Parameters { get; } = new();
        public string Result { get; set; }
        public MName Name { get; set; } = new();
        public bool Validatebinding { get; set; }
    }

}
