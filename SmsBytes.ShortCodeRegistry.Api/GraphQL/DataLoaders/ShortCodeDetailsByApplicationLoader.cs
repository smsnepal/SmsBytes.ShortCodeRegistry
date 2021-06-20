using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using SmsBytes.ShortCodeRegistry.Business;
using SmsBytes.ShortCodeRegistry.Storage;

namespace SmsBytes.ShortCodeRegistry.Api.GraphQL.DataLoaders
{
    public class ShortCodeDetailsByApplicationLoader : DataLoaderBase<string, ShortCodeDetails>
    {
        private readonly IShortCodeRegistryService _shortCodeRegistryService;

        public ShortCodeDetailsByApplicationLoader(IShortCodeRegistryService shortCodeRegistryService)
        {
            _shortCodeRegistryService = shortCodeRegistryService;
        }

        protected override async Task FetchAsync(IEnumerable<DataLoaderPair<string, ShortCodeDetails>> list, CancellationToken cancellationToken)
        {
            var applications = list.Select(x => x.Key).ToList();
            var details = await _shortCodeRegistryService.FindByApplicationIDs(applications);
            foreach (var entry in list)
            {
                var exists = details.TryGetValue(entry.Key, out var detail);
                entry.SetResult(exists ? detail : null);
            }
        }
    }
}
