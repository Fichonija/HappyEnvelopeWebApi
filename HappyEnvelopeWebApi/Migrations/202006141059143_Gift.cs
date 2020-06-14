namespace HappyEnvelopeWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Gift : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gifts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        description = c.String(nullable: false),
                        cost = c.Double(nullable: false),
                        imageUrl = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Gifts");
        }
    }
}
