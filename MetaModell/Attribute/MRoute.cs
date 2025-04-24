namespace DSLController_MModell.MetaModell.Attribute
{
    internal class MRoute : IMAttribute
    {
        public string Route { get; set; } = string.Empty;

        public MRoute(string route)
        {
            Route = route;
        }
    }
}