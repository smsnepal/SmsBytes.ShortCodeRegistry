using System;
using Micro.GraphQL.Federation;
using SmsBytes.ShortCodeRegistry.Api.GraphQL.Directives;
using SmsBytes.ShortCodeRegistry.Api.GraphQL.Types;

namespace SmsBytes.ShortCodeRegistry.Api.GraphQL
{
    public class StarterSchema : Schema<EntityType>
    {
        public StarterSchema(IServiceProvider services, Query query, Mutation mutation) : base(services)
        {
            Query = query;
            Mutation = mutation;
            Directives.Register(new AuthorizeDirective());
            RegisterVisitor(typeof(AuthorizeDirectiveVisitor));
            Directives.Register(new RequirePermissionDirective());
            RegisterVisitor(typeof(RequirePermissionDirectiveVisitor));
        }
    }
}
