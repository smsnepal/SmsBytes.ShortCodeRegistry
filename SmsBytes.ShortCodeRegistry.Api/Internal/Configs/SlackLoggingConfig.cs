using Microsoft.Extensions.Logging;

namespace SmsBytes.ShortCodeRegistry.Api.Internal.Configs
{
    public class SlackLoggingConfig
    {
        public string WebhookUrl { set; get; }
        public LogLevel MinLogLevel { set; get; }
    }
}
