using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PushMessages.EntityFramework.RqPricingForUpsert
{
    public interface IRqPricingForUpsertRepository
    {
        Task CreateAsync(RqPricingForUpsertRecord rqPricingForUpsertRecord, CancellationToken cancellationToken);
        Task<IEnumerable<RqPricingForUpsertRecord>> GetAllByGenerationIdAsync(int generationId);
        Task RemoveAllMessagesAsync();
    }
}