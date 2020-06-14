namespace HappyEnvelopeWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Calculation1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Calculations", "salary_id", "dbo.Salaries");
            DropIndex("dbo.Calculations", new[] { "salary_id" });
            AlterColumn("dbo.Calculations", "salary_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Calculations", "salary_id");
            AddForeignKey("dbo.Calculations", "salary_id", "dbo.Salaries", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calculations", "salary_id", "dbo.Salaries");
            DropIndex("dbo.Calculations", new[] { "salary_id" });
            AlterColumn("dbo.Calculations", "salary_id", c => c.Int());
            CreateIndex("dbo.Calculations", "salary_id");
            AddForeignKey("dbo.Calculations", "salary_id", "dbo.Salaries", "id");
        }
    }
}
