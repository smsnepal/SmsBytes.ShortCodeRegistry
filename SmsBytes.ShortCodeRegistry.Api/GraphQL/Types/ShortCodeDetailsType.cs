using GraphQL.Types;
using SmsBytes.ShortCodeRegistry.Storage;

namespace SmsBytes.ShortCodeRegistry.Api.GraphQL.Types
{
    public sealed class ShortCodeDetailsType : ObjectGraphType<ShortCodeDetails>
    {
        public ShortCodeDetailsType()
        {
            Name = "ShortCodeDetails";
            Field("short_code", x => x.ShortCode);
            Field("use_default_short_code", x => x.UseDefaultShortCode);
            Field("approved", x => x.Approved);
        }
    }
}
