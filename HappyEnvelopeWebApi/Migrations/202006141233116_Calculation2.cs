namespace HappyEnvelopeWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Calculation2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Calculations", "event_id", "dbo.Events");
            DropForeignKey("dbo.Calculations", "locale_id", "dbo.Locales");
            DropForeignKey("dbo.Calculations", "relationship_id", "dbo.Relationships");
            DropForeignKey("dbo.Calculations", "season_id", "dbo.Seasons");
            DropIndex("dbo.Calculations", new[] { "event_id" });
            DropIndex("dbo.Calculations", new[] { "locale_id" });
            DropIndex("dbo.Calculations", new[] { "relationship_id" });
            DropIndex("dbo.Calculations", new[] { "season_id" });
            AlterColumn("dbo.Calculations", "event_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Calculations", "locale_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Calculations", "relationship_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Calculations", "season_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Calculations", "relationship_id");
            CreateIndex("dbo.Calculations", "locale_id");
            CreateIndex("dbo.Calculations", "event_id");
            CreateIndex("dbo.Calculations", "season_id");
            AddForeignKey("dbo.Calculations", "event_id", "dbo.Events", "id", cascadeDelete: true);
            AddForeignKey("dbo.Calculations", "locale_id", "dbo.Locales", "id", cascadeDelete: true);
            AddForeignKey("dbo.Calculations", "relationship_id", "dbo.Relationships", "id", cascadeDelete: true);
            AddForeignKey("dbo.Calculations", "season_id", "dbo.Seasons", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calculations", "season_id", "dbo.Seasons");
            DropForeignKey("dbo.Calculations", "relationship_id", "dbo.Relationships");
            DropForeignKey("dbo.Calculations", "locale_id", "dbo.Locales");
            DropForeignKey("dbo.Calculations", "event_id", "dbo.Events");
            DropIndex("dbo.Calculations", new[] { "season_id" });
            DropIndex("dbo.Calculations", new[] { "event_id" });
            DropIndex("dbo.Calculations", new[] { "locale_id" });
            DropIndex("dbo.Calculations", new[] { "relationship_id" });
            AlterColumn("dbo.Calculations", "season_id", c => c.Int());
            AlterColumn("dbo.Calculations", "relationship_id", c => c.Int());
            AlterColumn("dbo.Calculations", "locale_id", c => c.Int());
            AlterColumn("dbo.Calculations", "event_id", c => c.Int());
            CreateIndex("dbo.Calculations", "season_id");
            CreateIndex("dbo.Calculations", "relationship_id");
            CreateIndex("dbo.Calculations", "locale_id");
            CreateIndex("dbo.Calculations", "event_id");
            AddForeignKey("dbo.Calculations", "season_id", "dbo.Seasons", "id");
            AddForeignKey("dbo.Calculations", "relationship_id", "dbo.Relationships", "id");
            AddForeignKey("dbo.Calculations", "locale_id", "dbo.Locales", "id");
            AddForeignKey("dbo.Calculations", "event_id", "dbo.Events", "id");
        }
    }
}
