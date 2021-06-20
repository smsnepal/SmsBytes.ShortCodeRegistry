using System;

namespace SmsBytes.ShortCodeRegistry.Api.GraphQL.Directives.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException() : base("You do not have sufficient permission to perform this operation")
        {
        }
    }
}
