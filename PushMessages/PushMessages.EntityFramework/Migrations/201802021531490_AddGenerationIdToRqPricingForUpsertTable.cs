namespace PushMessages.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenerationIdToRqPricingForUpsertTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RqPricingForUpsert", "GenerationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RqPricingForUpsert", "GenerationId");
        }
    }
}
