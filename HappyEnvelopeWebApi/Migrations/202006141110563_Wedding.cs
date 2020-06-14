namespace HappyEnvelopeWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wedding : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weddings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        calculation_id = c.Int(),
                        gift_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Calculations", t => t.calculation_id)
                .ForeignKey("dbo.Gifts", t => t.gift_id)
                .Index(t => t.calculation_id)
                .Index(t => t.gift_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weddings", "gift_id", "dbo.Gifts");
            DropForeignKey("dbo.Weddings", "calculation_id", "dbo.Calculations");
            DropIndex("dbo.Weddings", new[] { "gift_id" });
            DropIndex("dbo.Weddings", new[] { "calculation_id" });
            DropTable("dbo.Weddings");
        }
    }
}
