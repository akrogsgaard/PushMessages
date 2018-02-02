using System;
using System.Collections.Generic;
using IQ.Platform.Pricing.Messaging.Contract.v1;

namespace PushMessages.MessageFactories
{
    public class UpsertPriceSheetChangeMessageFactoryMessageFactory : MessageBuilderFactoryBase<UpsertPriceSheetChange>
    {
        private readonly int _companyId;
        private readonly int _priceSheetId;
        private readonly DateTime? _startDateUtc;
        private readonly DateTime? _stopDateUtc;

        public UpsertPriceSheetChangeMessageFactoryMessageFactory(int companyId, int priceSheetId, DateTime? startDateUtc, DateTime? stopDateUtc)
        {
            _companyId = companyId;
            _priceSheetId = priceSheetId;
            _startDateUtc = startDateUtc;
            _stopDateUtc = stopDateUtc;
        }
        
        public override UpsertPriceSheetChange BuildMessage()
        {
            return new UpsertPriceSheetChange
            {
                CompanyId = _companyId,
                PriceSheetId = _priceSheetId,
                PriceSheetStatus = PriceSheetStatus.Continual,
                PriceSheetDetail = new List<PriceSheetDetail>{
                    new PriceSheetDetail
                    {
                        EntityId = 24178,
                        StartDateUtc = _startDateUtc,
                        StopDateUtc = _stopDateUtc,
                        TimeStampUtc = DateTime.UtcNow
                    },
                    new PriceSheetDetail
                    {
                        EntityId = 24181,
                        StartDateUtc = _startDateUtc,
                        StopDateUtc = _stopDateUtc,
                        TimeStampUtc = DateTime.UtcNow
                    },
                    new PriceSheetDetail
                    {
                        EntityId = 24175,
                        StartDateUtc = _startDateUtc,
                        StopDateUtc = _stopDateUtc,
                        TimeStampUtc = DateTime.UtcNow
                    },
                    new PriceSheetDetail
                    {
                        EntityId = 39757,
                        StartDateUtc = _startDateUtc,
                        StopDateUtc = _stopDateUtc,
                        TimeStampUtc = DateTime.UtcNow
                    },
                    new PriceSheetDetail
                    {
                        EntityId = 24174,
                        StartDateUtc = _startDateUtc,
                        StopDateUtc = _stopDateUtc,
                        TimeStampUtc = DateTime.UtcNow
                    },
                }
            };
        }
    }
}