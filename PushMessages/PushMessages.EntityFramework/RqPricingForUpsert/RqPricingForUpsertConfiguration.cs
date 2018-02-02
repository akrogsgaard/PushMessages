using System.Data.Entity.ModelConfiguration;

namespace PushMessages.EntityFramework.RqPricingForUpsert
{
    public class RqPricingForUpsertConfiguration : EntityTypeConfiguration<RqPricingForUpsertRecord>
    {
        public RqPricingForUpsertConfiguration()
        {
            ToTable("RqPricingForUpsert");
            HasKey(x => new { x.CompanyId, x.EntityId, x.CatalogItemId });
        }
    }
}
