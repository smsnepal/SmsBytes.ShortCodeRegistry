using System.Collections.Generic;
using System.Threading.Tasks;
using SmsBytes.ShortCodeRegistry.Business.ApplicationInfo;
using SmsBytes.ShortCodeRegistry.Business.Exceptions;
using SmsBytes.ShortCodeRegistry.Storage;

namespace SmsBytes.ShortCodeRegistry.Business
{
    public interface IShortCodeRegistryService
    {
        Task<ShortCodeDetails> Create(SetShortCodeInput input, string currentUserId, string authHeader);
        Task<Dictionary<string, ShortCodeDetails>> FindByApplicationIDs(IEnumerable<string> applicationIds);
    }

    public class ShortCodeRegistryService : IShortCodeRegistryService
    {
        private readonly IApplicationInfoService _applicationInfoService;
        private readonly IShortCodeRepository _shortCodeRepository;

        public ShortCodeRegistryService(
            IShortCodeRepository shortCodeRepository,
            IApplicationInfoService applicationInfoService
        )
        {
            _shortCodeRepository = shortCodeRepository;
            _applicationInfoService = applicationInfoService;
        }

        public async Task<ShortCodeDetails> Create(SetShortCodeInput details, string currentUserId, string authHeader)
        {
            var application = await _applicationInfoService.GetApplicationInfo(details.ApplicationId, authHeader);
            if (application == null)
            {
                throw new ApplicationNotFoundException();
            }

            if (application.Owner.Id != currentUserId)
            {
                throw new NotAuthorizedException();
            }

            if ((await _shortCodeRepository.FindByApplicationIds(new[] {details.ApplicationId})).Count != 0)
            {
                throw new InvalidOperationException("short code details already present and cannot be changed");
            }
            return await _shortCodeRepository.Create(new ShortCodeDetails
            {
                Approved = false,
                ApplicationId = details.ApplicationId,
                ShortCode = details.ShortCode,
                UseDefaultShortCode = details.UseDefaultShortCode,
            });
        }

        public async Task<Dictionary<string, ShortCodeDetails>> FindByApplicationIDs(IEnumerable<string> applicationIds)
        {
            return await _shortCodeRepository.FindByApplicationIds(applicationIds);
        }
    }
}
