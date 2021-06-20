namespace SmsBytes.ShortCodeRegistry.Storage
{
    public class ShortCodeDetails
    {
        public string Id { set; get; }
        public string ApplicationId { set; get; }
        public string ShortCode { set; get; }
        public bool UseDefaultShortCode { set; get; }
        public bool Approved { set; get; }
    }
}
