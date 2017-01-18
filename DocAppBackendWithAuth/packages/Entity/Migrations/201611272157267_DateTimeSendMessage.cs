namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeSendMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "DateTimeSend", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "DateTimeSend");
        }
    }
}
