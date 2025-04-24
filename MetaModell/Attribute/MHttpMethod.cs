namespace DSLController_MModell.MetaModell.Attribute
{
    public class MHttpMethod : IMAttribute {
        public HttpMethod HttpMethod { get; set; }

        public MHttpMethod(HttpMethod httpMethod)
        {
            HttpMethod = httpMethod;
        }
    }

}
