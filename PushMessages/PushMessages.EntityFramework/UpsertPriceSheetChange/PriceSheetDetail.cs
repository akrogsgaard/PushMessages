using System;

namespace PushMessages.EntityFramework.UpsertPriceSheetChange
{
    public class PriceSheetDetail
    {
        public int EntityId { get; set; }
        public DateTime? StartDateUtc { get; set; }
        public DateTime? StopDateUtc { get; set; }
        public DateTime? TimeStampUtc { get; set; }
    }
}