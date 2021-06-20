using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace SmsBytes.ShortCodeRegistry.Business.ApplicationInfo
{
    public interface IApplicationGraphqlClient
    {
        Task<ExternalApplicationModel> GetApplicationInfo(string applicationId, string authHeader);
    }
    public class ApplicationGraphqlClient : GraphQLHttpClient, IApplicationGraphqlClient
    {
        public ApplicationGraphqlClient(string endPoint) : base(endPoint, new NewtonsoftJsonSerializer())
        {
        }

        public async Task<ExternalApplicationModel> GetApplicationInfo(string applicationId, string authHeader)
        {
            var request = new GraphQLRequest
            {
                Query = @"
query ApplicationById($id: String!) {
  applicationById(id: $id){
    id
    name
    owner{
      id
    }
  }
}
",
                Variables = new
                {
                    Id = applicationId
                },
                OperationName = "ApplicationById"
            };
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authHeader.Replace("Bearer ", ""));
            var result = await SendQueryAsync<ApplicationByIdResponseType>(request);
            if (result.Errors != null)
            {
                throw new Exception(result.Errors.First().Message);
            }

            HttpClient.DefaultRequestHeaders.Authorization = null;
            return result.Data.ApplicationById;
        }
    }
}
