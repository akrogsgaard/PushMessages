namespace PushMessages.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDbCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RqPricingForUpsert",
                c => new
                    {
                        CompanyId = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                        CatalogItemId = c.Guid(nullable: false),
                        GlobalProductId = c.Int(nullable: false),
                        PriceSheetId = c.Int(),
                        TermId = c.Int(),
                        RegularPrice = c.Decimal(precision: 18, scale: 2),
                        OverridePrice = c.Decimal(precision: 18, scale: 2),
                        OverrideStartDateUtc = c.DateTime(),
                        OverrideStopDateUtc = c.DateTime(),
                        PricingTermName = c.String(),
                        TermLengthInYears = c.Int(nullable: false),
                        StartDateUtc = c.DateTime(),
                        StopDateUtc = c.DateTime(),
                        TimeStampUtc = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.CompanyId, t.EntityId, t.CatalogItemId });
            
            CreateTable(
                "dbo.UpsertPriceSheetChange",
                c => new
                    {
                        CompanyId = c.Int(nullable: false),
                        PriceSheetId = c.Int(nullable: false),
                        PriceSheetStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyId, t.PriceSheetId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UpsertPriceSheetChange");
            DropTable("dbo.RqPricingForUpsert");
        }
    }
}
