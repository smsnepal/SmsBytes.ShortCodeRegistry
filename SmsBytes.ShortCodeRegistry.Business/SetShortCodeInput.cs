namespace SmsBytes.ShortCodeRegistry.Business
{
    public class SetShortCodeInput
    {
        public string ApplicationId { set; get; }
        public string ShortCode { set; get; }
        public bool UseDefaultShortCode { set; get; }
    }
}
