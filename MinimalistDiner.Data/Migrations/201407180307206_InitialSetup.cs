namespace MinimalistDiner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Value = c.String(maxLength: 4000),
                        Name = c.String(maxLength: 4000),
                        Priority = c.Int(nullable: false),
                        IsMultipleAllowed = c.Boolean(nullable: false),
                        QuantityOrdered = c.Int(nullable: false),
                        Menu_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.Menu_Id)
                .Index(t => t.Menu_Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dishes", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.Dishes", new[] { "Menu_Id" });
            DropTable("dbo.Menus");
            DropTable("dbo.Dishes");
        }
    }
}
