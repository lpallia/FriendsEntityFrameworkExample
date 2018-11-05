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
                "dbo.UserAgendas",
                c => new
                    {
                        User_Id = c.Guid(nullable: false),
                        Agenda_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Agenda_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Agenda", t => t.Agenda_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Agenda_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Agenda_Id", "dbo.Agenda");
            DropForeignKey("dbo.UserAgendas", "Agenda_Id", "dbo.Agenda");
            DropForeignKey("dbo.UserAgendas", "User_Id", "dbo.Users");
            DropIndex("dbo.UserAgendas", new[] { "Agenda_Id" });
            DropIndex("dbo.UserAgendas", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Agenda_Id" });
            DropTable("dbo.UserAgendas");
            DropTable("dbo.Users");
            DropTable("dbo.Agenda");
        }
    }
}
