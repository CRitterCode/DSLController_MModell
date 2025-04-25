namespace DSLController_MModell.MetaModell.Attribute
{
    public class MAntiforgery : IMAttribute {

        public bool isAntiforgery { get; set; }

        public MAntiforgery(bool ignoreAntiforgery)
        {
            isAntiforgery = ignoreAntiforgery;
        }
    }

}
