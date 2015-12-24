namespace Tmx.Client.Library.Helpers
{
    using Abstract;

    public class RestRequestFactory
    {
        public static IRestRequestCreator RestRequestCreator { get; set; }

        public static IRestRequestCreator GetRestRequestCreator()
        {
            return RestRequestCreator ?? new RestRequestCreator();
        }
    }
}