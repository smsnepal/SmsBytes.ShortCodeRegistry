namespace SmsBytes.ShortCodeRegistry.Api.Internal.Configs
{
    public class Services
    {
        public KeyStoreConfig KeyStore { set; get; }
        public AppRegistration AppRegistration { set; get; }
    }

    public class KeyStoreConfig
    {
        public string Url { set; get; }
    }
    public class AppRegistration
    {
        public string Url { set; get; }
    }
}
