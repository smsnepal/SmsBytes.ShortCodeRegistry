namespace SmsBytes.ShortCodeRegistry.Api.GraphQL.Types
{
    public class EntityType : Micro.GraphQL.Federation.Types.EntityType
    {
        public EntityType()
        {
            Type<ApplicationType>();
        }
    }
}
