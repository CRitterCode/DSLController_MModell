namespace DSLController_MModell.MetaModell.Attribute
{
    public class MAuthorize : IMAttribute
    {
        public MRole[] Roles { get; set; }

        public MAuthorize(params MRole[] roles)
        {
            Roles = roles;
        }
    }

}
