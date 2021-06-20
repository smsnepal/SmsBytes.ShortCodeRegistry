using GraphQL.Types;

namespace SmsBytes.ShortCodeRegistry.Api.GraphQL.Inputs
{
    public class SetShortCodeInput : InputObjectGraphType<Business.SetShortCodeInput>
    {
        public static QueryArgument BuildArgument(string name)
        {
            return new QueryArgument<NonNullGraphType<SetShortCodeInput>> { Name = name};
        }
        public SetShortCodeInput()
        {
            Name = "CreateShortCodeInput";
            Field<NonNullGraphType<StringGraphType>>("applicationId");
            Field<NonNullGraphType<StringGraphType>>("shortCode");
            Field<NonNullGraphType<BooleanGraphType>>("useDefaultShortCode");
        }
    }
}
