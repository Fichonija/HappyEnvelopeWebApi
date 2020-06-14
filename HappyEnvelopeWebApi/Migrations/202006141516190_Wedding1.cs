namespace HappyEnvelopeWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wedding1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Weddings", "calculation_id", "dbo.Calculations");
            DropForeignKey("dbo.Weddings", "gift_id", "dbo.Gifts");
            DropIndex("dbo.Weddings", new[] { "calculation_id" });
            DropIndex("dbo.Weddings", new[] { "gift_id" });
            AlterColumn("dbo.Weddings", "calculation_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Weddings", "gift_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Weddings", "calculation_id");
            CreateIndex("dbo.Weddings", "gift_id");
            AddForeignKey("dbo.Weddings", "calculation_id", "dbo.Calculations", "id", cascadeDelete: true);
            AddForeignKey("dbo.Weddings", "gift_id", "dbo.Gifts", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weddings", "gift_id", "dbo.Gifts");
            DropForeignKey("dbo.Weddings", "calculation_id", "dbo.Calculations");
            DropIndex("dbo.Weddings", new[] { "gift_id" });
            DropIndex("dbo.Weddings", new[] { "calculation_id" });
            AlterColumn("dbo.Weddings", "gift_id", c => c.Int());
            AlterColumn("dbo.Weddings", "calculation_id", c => c.Int());
            CreateIndex("dbo.Weddings", "gift_id");
            CreateIndex("dbo.Weddings", "calculation_id");
            AddForeignKey("dbo.Weddings", "gift_id", "dbo.Gifts", "id");
            AddForeignKey("dbo.Weddings", "calculation_id", "dbo.Calculations", "id");
        }
    }
}
