using System;
using IQ.Platform.Framework.Common.Mapping;
using PushMessages.EntityFramework.RqPricingForUpsert;
using PricingContract = IQ.Platform.Pricing.Messaging.Contract.v1;

namespace PushMessages.MessageFactories.RqPricingForUpsert
{
    public interface IRqPricingForUpsertMapper : IMapper<PricingContract.RqPricingForUpsert, RqPricingForUpsertRecord>
    {
        RqPricingForUpsertRecord Map(PricingContract.RqPricingForUpsert source, int generationId);
    }

    public class RqPricingForUpsertMapper : IRqPricingForUpsertMapper
    {
        public RqPricingForUpsertRecord Map(PricingContract.RqPricingForUpsert source)
        {
            throw new NotImplementedException();
        }

        public RqPricingForUpsertRecord Map(PricingContract.RqPricingForUpsert source, int generationId)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return new RqPricingForUpsertRecord
            {
                CompanyId = source.CompanyId,
                EntityId = source.EntityId,
                CatalogItemId = source.CatalogItemId,
                GlobalProductId = source.GlobalProductId,
                PriceSheetId = source.PriceSheetId,
                TermId = source.TermId,
                RegularPrice = source.RegularPrice,
                OverridePrice = source.OverridePrice,
                OverrideStartDateUtc = source.OverrideStartDateUtc,
                OverrideStopDateUtc = source.OverrideStopDateUtc,
                PricingTermName = source.PricingTermName,
                TermLengthInYears = source.TermLengthInYears,
                StartDateUtc = source.StartDateUtc,
                StopDateUtc = source.StopDateUtc,
                TimeStampUtc = source.TimeStampUtc,
                GenerationId = generationId,
            };
        }
    }
}
