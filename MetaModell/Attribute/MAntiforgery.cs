namespace DSLController_MModell.MetaModell.Attribute
{
    public class MAntiforgery : IMAttribute {

        public bool IgnoreAntiforgery { get; set; }

        public MAntiforgery(bool ignoreAntiForgery)
        {
            IgnoreAntiforgery = ignoreAntiForgery;
        }
    }

}
