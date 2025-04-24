using DSLController_MModell.MetaModell.Attribute;
using DSLController_MModell.MetaModell.Result;
using System.Runtime.CompilerServices;

namespace DSLController_MModell.MetaModell.Action
{
    public class MAction
    {
        public HashSet<IMAttribute> Attributes { get; } = new();
        public HashSet<MParameter> Parameters { get; } = new();
        public IMResult Result { get; set; }
        public MName Name { get; set; } = new();
        public bool Validatebinding { get; set; }
    }

}
