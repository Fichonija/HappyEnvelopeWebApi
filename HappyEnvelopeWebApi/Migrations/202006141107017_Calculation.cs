namespace HappyEnvelopeWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Calculation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calculations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        attending = c.Boolean(nullable: false),
                        festivities = c.Boolean(nullable: false),
                        calculationSum = c.Double(nullable: false),
                        event_id = c.Int(),
                        locale_id = c.Int(),
                        relationship_id = c.Int(),
                        salary_id = c.Int(),
                        season_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Events", t => t.event_id)
                .ForeignKey("dbo.Locales", t => t.locale_id)
                .ForeignKey("dbo.Relationships", t => t.relationship_id)
                .ForeignKey("dbo.Salaries", t => t.salary_id)
                .ForeignKey("dbo.Seasons", t => t.season_id)
                .Index(t => t.event_id)
                .Index(t => t.locale_id)
                .Index(t => t.relationship_id)
                .Index(t => t.salary_id)
                .Index(t => t.season_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calculations", "season_id", "dbo.Seasons");
            DropForeignKey("dbo.Calculations", "salary_id", "dbo.Salaries");
            DropForeignKey("dbo.Calculations", "relationship_id", "dbo.Relationships");
            DropForeignKey("dbo.Calculations", "locale_id", "dbo.Locales");
            DropForeignKey("dbo.Calculations", "event_id", "dbo.Events");
            DropIndex("dbo.Calculations", new[] { "season_id" });
            DropIndex("dbo.Calculations", new[] { "salary_id" });
            DropIndex("dbo.Calculations", new[] { "relationship_id" });
            DropIndex("dbo.Calculations", new[] { "locale_id" });
            DropIndex("dbo.Calculations", new[] { "event_id" });
            DropTable("dbo.Calculations");
        }
    }
}
