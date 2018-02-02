using System.Collections.Generic;

namespace PushMessages.EntityFramework.UpsertPriceSheetChange
{
    public class UpsertPriceSheetChangeRecord
    {
        public UpsertPriceSheetChangeRecord()
        {
            PriceSheetDetail = new List<PriceSheetDetail>();
        }

        public int CompanyId { get; set; }
        public int PriceSheetId { get; set; }
        public PriceSheetStatus PriceSheetStatus { get; set; }
        public IEnumerable<PriceSheetDetail> PriceSheetDetail { get; set; }

    }
}
