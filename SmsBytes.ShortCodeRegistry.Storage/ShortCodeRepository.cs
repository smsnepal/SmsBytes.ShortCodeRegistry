using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmsBytes.ShortCodeRegistry.Common.Uuid;

namespace SmsBytes.ShortCodeRegistry.Storage
{
    public interface IShortCodeRepository
    {
        Task<ShortCodeDetails> Create(ShortCodeDetails details);
        Task<Dictionary<string, ShortCodeDetails>> FindByApplicationIds(IEnumerable<string> applicationIds);
    }
    public class ShortCodeRepository : IShortCodeRepository
    {
        private readonly ApplicationContext _db;
        private readonly IUuidService _uuidService;

        public ShortCodeRepository(ApplicationContext db, IUuidService uuidService)
        {
            _db = db;
            _uuidService = uuidService;
        }

        public async Task<ShortCodeDetails> Create(ShortCodeDetails details)
        {
            var entry = await _db.ShortCodeDetails.AddAsync(new ShortCodeDetails
            {
                Id = _uuidService.GenerateUuId("short_code_details"),
                Approved = false,
                ApplicationId = details.ApplicationId,
                ShortCode = details.ShortCode,
                UseDefaultShortCode = details.UseDefaultShortCode,
            });
            await _db.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Dictionary<string, ShortCodeDetails>> FindByApplicationIds(IEnumerable<string> applicationIds)
        {
            return await _db
                .ShortCodeDetails
                .AsNoTracking()
                .Where(x => applicationIds.Contains(x.ApplicationId))
                .ToDictionaryAsync(x => x.ApplicationId);
        }
    }
}
