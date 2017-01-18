namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Chat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dialogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstUser_Id = c.Int(),
                        SecondUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseUsers", t => t.FirstUser_Id)
                .ForeignKey("dbo.BaseUsers", t => t.SecondUser_Id)
                .Index(t => t.FirstUser_Id)
                .Index(t => t.SecondUser_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Dialog_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dialogs", t => t.Dialog_Id)
                .Index(t => t.Dialog_Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Bytes = c.Binary(),
                        Message_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Messages", t => t.Message_Id)
                .Index(t => t.Message_Id);
            
            CreateTable(
                "dbo.Hrefs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Link = c.String(),
                        Message_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Messages", t => t.Message_Id)
                .Index(t => t.Message_Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Bytes = c.Binary(),
                        Message_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Messages", t => t.Message_Id)
                .Index(t => t.Message_Id);
            
            AddColumn("dbo.BaseUsers", "ConnectionId", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dialogs", "SecondUser_Id", "dbo.BaseUsers");
            DropForeignKey("dbo.Messages", "Dialog_Id", "dbo.Dialogs");
            DropForeignKey("dbo.Images", "Message_Id", "dbo.Messages");
            DropForeignKey("dbo.Hrefs", "Message_Id", "dbo.Messages");
            DropForeignKey("dbo.Documents", "Message_Id", "dbo.Messages");
            DropForeignKey("dbo.Dialogs", "FirstUser_Id", "dbo.BaseUsers");
            DropIndex("dbo.Images", new[] { "Message_Id" });
            DropIndex("dbo.Hrefs", new[] { "Message_Id" });
            DropIndex("dbo.Documents", new[] { "Message_Id" });
            DropIndex("dbo.Messages", new[] { "Dialog_Id" });
            DropIndex("dbo.Dialogs", new[] { "SecondUser_Id" });
            DropIndex("dbo.Dialogs", new[] { "FirstUser_Id" });
            DropColumn("dbo.BaseUsers", "ConnectionId");
            DropTable("dbo.Images");
            DropTable("dbo.Hrefs");
            DropTable("dbo.Documents");
            DropTable("dbo.Messages");
            DropTable("dbo.Dialogs");
        }
    }
}
