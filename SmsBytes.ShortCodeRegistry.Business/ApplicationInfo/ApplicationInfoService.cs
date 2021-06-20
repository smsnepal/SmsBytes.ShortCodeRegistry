using System.Threading.Tasks;

namespace SmsBytes.ShortCodeRegistry.Business.ApplicationInfo
{
    public interface IApplicationInfoService
    {
        Task<ExternalApplicationModel> GetApplicationInfo(string applicationId, string authHeader);
    }
    public class ApplicationInfoService : IApplicationInfoService
    {
        public async Task<ExternalApplicationModel> GetApplicationInfo(string applicationId, string authHeader)
        {
            var client = new ApplicationGraphqlClient("http://localhost:35000/graphql");
            return await client.GetApplicationInfo(applicationId, authHeader);
        }
    }
}
