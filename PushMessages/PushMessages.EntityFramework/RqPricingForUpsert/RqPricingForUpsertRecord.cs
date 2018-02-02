using System;
using System.Collections;

namespace PushMessages.EntityFramework.RqPricingForUpsert
{
    public class RqPricingForUpsertRecord : IEnumerable
    {
        public int GenerationId { get; set; }
        public int CompanyId { get; set; }
        public int EntityId { get; set; }
        public Guid CatalogItemId { get; set; }
        public int GlobalProductId { get; set; }
        public int? PriceSheetId { get; set; }
        public int? TermId { get; set; }
        public Decimal? RegularPrice { get; set; }
        public Decimal? OverridePrice { get; set; }
        public DateTime? OverrideStartDateUtc { get; set; }
        public DateTime? OverrideStopDateUtc { get; set; }
        public string PricingTermName { get; set; }
        public int TermLengthInYears { get; set; }
        public DateTime? StartDateUtc { get; set; }
        public DateTime? StopDateUtc { get; set; }
        public DateTime? TimeStampUtc { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
