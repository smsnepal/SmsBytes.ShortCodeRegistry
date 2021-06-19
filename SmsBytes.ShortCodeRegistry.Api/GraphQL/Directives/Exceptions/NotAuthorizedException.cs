using System;

namespace SmsBytes.ShortCodeRegistry.Api.GraphQL.Directives.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException() : base("This operation requires logging in")
        {
        }
    }
}
