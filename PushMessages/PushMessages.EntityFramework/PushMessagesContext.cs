using System;
using System.Data.Entity;
using PushMessages.EntityFramework.RqPricingForUpsert;
using PushMessages.EntityFramework.UpsertPriceSheetChange;

namespace PushMessages.EntityFramework
{
    public class PushMessagesContext : DbContext
    {
        public PushMessagesContext() : base("Default") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RqPricingForUpsertConfiguration());
            modelBuilder.Configurations.Add(new UpsertPriceSheetChangeConfiguration());

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<RqPricingForUpsert.RqPricingForUpsertRecord> RqPricingForUpsert { get; set; }
        public DbSet<UpsertPriceSheetChange.UpsertPriceSheetChangeRecord> UpsertPriceSheetChange { get; set; }
    }
}
