namespace DSLController_MModell.MetaModell.Attribute
{
    public class MConsumes : IMAttribute
    {
        public string MediaType { get; set; } = "application/json";

        public MConsumes(string mediaType)
        {
            MediaType = mediaType;
        }
    }

}
