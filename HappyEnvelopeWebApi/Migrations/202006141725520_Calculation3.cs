namespace HappyEnvelopeWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Calculation3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Calculations", "attending", c => c.Int(nullable: false));
            AlterColumn("dbo.Calculations", "festivities", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Calculations", "festivities", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Calculations", "attending", c => c.Boolean(nullable: false));
        }
    }
}
