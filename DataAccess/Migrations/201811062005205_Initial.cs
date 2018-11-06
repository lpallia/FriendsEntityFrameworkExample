namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Agenda_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agenda", t => t.Agenda_Id)
                .Index(t => t.Agenda_Id);
            
            CreateTable(
                "dbo.AgendaUsers",
                c => new
                    {
                        Agenda_Id = c.Guid(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Agenda_Id, t.User_Id })
                .ForeignKey("dbo.Agenda", t => t.Agenda_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Agenda_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AgendaUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.AgendaUsers", "Agenda_Id", "dbo.Agenda");
            DropForeignKey("dbo.Users", "Agenda_Id", "dbo.Agenda");
            DropIndex("dbo.AgendaUsers", new[] { "User_Id" });
            DropIndex("dbo.AgendaUsers", new[] { "Agenda_Id" });
            DropIndex("dbo.Users", new[] { "Agenda_Id" });
            DropTable("dbo.AgendaUsers");
            DropTable("dbo.Users");
            DropTable("dbo.Agenda");
        }
    }
}
