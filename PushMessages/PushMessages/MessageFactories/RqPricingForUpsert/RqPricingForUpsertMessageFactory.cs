using System;
using System.Collections.Generic;
using System.Threading;
using IQ.Platform.Framework.Common.Mapping;
using PushMessages.EntityFramework.RqPricingForUpsert;
using PricingContract = IQ.Platform.Pricing.Messaging.Contract.v1;

namespace PushMessages.MessageFactories.RqPricingForUpsert
{
    public class RqPricingForUpsertMessageFactory : MessageBuilderFactoryBase<PricingContract.RqPricingForUpsert>
    {
        private readonly int _companyId;
        private readonly int _priceSheetId;
        private readonly DateTime? _startDateUtc;
        private readonly DateTime? _stopDateUtc;
        private readonly Random _randomNumberGenerator = new Random();
        private readonly IRqPricingForUpsertRepository _repository;
        private readonly IRqPricingForUpsertMapper _mapper;

        public RqPricingForUpsertMessageFactory(
            int companyId, 
            int priceSheetId, 
            DateTime? startDateUtc, 
            DateTime? stopDateUtc)
        {
            _companyId = companyId;
            _priceSheetId = priceSheetId;
            _startDateUtc = startDateUtc;
            _stopDateUtc = stopDateUtc;

            _repository = new RqPricingForUpsertRepository();
            _mapper = new RqPricingForUpsertMapper();
        }

        public override PricingContract.RqPricingForUpsert BuildMessage()
        {
            var rqPricingForUpsert = new PricingContract.RqPricingForUpsert
            {
                CompanyId = _companyId,
                EntityId = 24178,
                CatalogItemId = Guid.NewGuid(),
                GlobalProductId = _randomNumberGenerator.Next(100000),
                PriceSheetId = _priceSheetId,
                TermId = 5,
                RegularPrice = (decimal?)(_randomNumberGenerator.NextDouble() * 100),
                OverridePrice = null,
                OverrideStartDateUtc = null,
                OverrideStopDateUtc = null,
                PricingTermName = "test term",
                TermLengthInYears = _randomNumberGenerator.Next(5),
                StartDateUtc = _startDateUtc,
                StopDateUtc = _stopDateUtc,
                TimeStampUtc = DateTime.UtcNow
            };

            _repository.CreateAsync(_mapper.Map(rqPricingForUpsert, 1), CancellationToken.None);
            return rqPricingForUpsert;
        }

        public override IEnumerable<PricingContract.RqPricingForUpsert> BuildSecondGenerationMessages()
        {
            var messages = new List<PricingContract.RqPricingForUpsert>();
            var gen1Messages = _repository.GetAllByGenerationIdAsync(1).Result;

            foreach (var message in gen1Messages)
            {
                messages.Add(new PricingContract.RqPricingForUpsert
                {
                    CompanyId = _companyId,
                    EntityId = message.EntityId,
                    CatalogItemId = message.CatalogItemId,
                    GlobalProductId = message.GlobalProductId,
                    PriceSheetId = message.PriceSheetId,
                    TermId = message.TermId,
                    RegularPrice = (decimal?)(_randomNumberGenerator.NextDouble() * 100),
                    OverridePrice = message.OverridePrice,
                    OverrideStartDateUtc = message.OverrideStartDateUtc,
                    OverrideStopDateUtc = message.OverrideStopDateUtc,
                    PricingTermName = message.PricingTermName,
                    TermLengthInYears = message.TermLengthInYears,
                    StartDateUtc = _startDateUtc,
                    StopDateUtc = _stopDateUtc,
                    TimeStampUtc = DateTime.UtcNow
                });
            }

            _repository.RemoveAllMessagesAsync();

            return messages;
        }
    }
}