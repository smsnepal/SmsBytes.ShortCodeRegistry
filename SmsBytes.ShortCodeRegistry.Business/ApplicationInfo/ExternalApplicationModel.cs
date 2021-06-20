namespace SmsBytes.ShortCodeRegistry.Business.ApplicationInfo
{
    public class ExternalApplicationModel
    {
        public string Id { set; get; }
        public Owner Owner { set; get; }
        public string Name { set; get; }
    }

    public class Owner
    {
        public string Id { set; get; }
    }
}
