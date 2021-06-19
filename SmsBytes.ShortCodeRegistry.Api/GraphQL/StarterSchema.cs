using System;
using Micro.GraphQL.Federation;
using SmsBytes.ShortCodeRegistry.Api.GraphQL.Directives;
using SmsBytes.ShortCodeRegistry.Api.GraphQL.Types;

namespace SmsBytes.ShortCodeRegistry.Api.GraphQL
{
    public class StarterSchema : Schema<EntityType>
    {
        public StarterSchema(IServiceProvider services, Query query) : base(services)
        {
            Query = query;
            Directives.Register(new AuthorizeDirective());
            RegisterVisitor(typeof(AuthorizeDirectiveVisitor));
        }
    }
}
