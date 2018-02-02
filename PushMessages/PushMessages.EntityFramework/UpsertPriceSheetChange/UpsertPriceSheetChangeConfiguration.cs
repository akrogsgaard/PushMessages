using System.Data.Entity.ModelConfiguration;

namespace PushMessages.EntityFramework.UpsertPriceSheetChange
{
    public class UpsertPriceSheetChangeConfiguration : EntityTypeConfiguration<UpsertPriceSheetChangeRecord>
    {
        public UpsertPriceSheetChangeConfiguration()
        {
            ToTable("UpsertPriceSheetChange");
            HasKey(x => new { x.CompanyId, x.PriceSheetId });
        }
    }
}
