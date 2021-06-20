using System.Threading.Tasks;

namespace SmsBytes.ShortCodeRegistry.Business.ApplicationInfo
{
    public interface IApplicationInfoService
    {
        Task<ExternalApplicationModel> GetApplicationInfo(string applicationId, string authHeader);
    }
    public class ApplicationInfoService : IApplicationInfoService
    {
        private readonly IApplicationGraphqlClient _graphqlClient;

        public ApplicationInfoService(IApplicationGraphqlClient graphqlClient)
        {
            _graphqlClient = graphqlClient;
        }

        public async Task<ExternalApplicationModel> GetApplicationInfo(string applicationId, string authHeader)
        {
            return await _graphqlClient.GetApplicationInfo(applicationId, authHeader);
        }
    }
}
