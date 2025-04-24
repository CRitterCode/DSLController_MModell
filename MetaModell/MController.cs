using DSLController_MModell.MetaModell.Action;
using DSLController_MModell.MetaModell.Attribute;

namespace DSLController_MModell.MetaModell
{
    public class MController
    {
        public HashSet<MAction> Actions { get; } = new();
        public HashSet<IMAttribute> Attributes { get; } = new();
        public MName Name { get; set; } = new();
    }

}
