namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class X333 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Messages", new[] { "sender_Id" });
            CreateIndex("dbo.Messages", "Sender_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            CreateIndex("dbo.Messages", "sender_Id");
        }
    }
}
