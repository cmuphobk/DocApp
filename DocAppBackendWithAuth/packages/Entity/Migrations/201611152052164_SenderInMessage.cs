namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SenderInMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "sender_Id", c => c.Int());
            CreateIndex("dbo.Messages", "sender_Id");
            AddForeignKey("dbo.Messages", "sender_Id", "dbo.BaseUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "sender_Id", "dbo.BaseUsers");
            DropIndex("dbo.Messages", new[] { "sender_Id" });
            DropColumn("dbo.Messages", "sender_Id");
        }
    }
}
