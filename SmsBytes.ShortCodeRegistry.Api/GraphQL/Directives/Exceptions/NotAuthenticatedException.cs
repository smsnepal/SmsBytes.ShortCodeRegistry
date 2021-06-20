using System;

namespace SmsBytes.ShortCodeRegistry.Api.GraphQL.Directives.Exceptions
{
    public class NotAuthenticatedException : Exception
    {
        public NotAuthenticatedException() : base("This operation requires logging in")
        {
        }
    }
}
