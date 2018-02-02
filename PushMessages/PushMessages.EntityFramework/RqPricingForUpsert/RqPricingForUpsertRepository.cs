using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PushMessages.EntityFramework.RqPricingForUpsert
{
    public class RqPricingForUpsertRepository : IRqPricingForUpsertRepository
    {
        public async Task CreateAsync(RqPricingForUpsertRecord rqPricingForUpsertRecord, CancellationToken cancellationToken)
        {
            if (rqPricingForUpsertRecord == null) throw new ArgumentNullException(nameof(rqPricingForUpsertRecord));

            using (var context = new PushMessagesContext())
            {
                context.RqPricingForUpsert.Add(rqPricingForUpsertRecord);
                await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<RqPricingForUpsertRecord>> GetAllByGenerationIdAsync(int generationId)
        {
            if (generationId <= 0) throw new ArgumentOutOfRangeException(nameof(generationId));

            IEnumerable<RqPricingForUpsertRecord> messages;

            using (var context = new PushMessagesContext())
            {
                messages = await context.RqPricingForUpsert.Where(x => x.GenerationId == generationId).ToListAsync().ConfigureAwait(false);
            }

            return messages;
        }

        public async Task RemoveAllMessagesAsync()
        {
            using (var context = new PushMessagesContext())
            {
                await context.Database.ExecuteSqlCommandAsync("TRUNCATE TABLE RqPricingForUpsert").ConfigureAwait(false);
            }
        }
    }
}
