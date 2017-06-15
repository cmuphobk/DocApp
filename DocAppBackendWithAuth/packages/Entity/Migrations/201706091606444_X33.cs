namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class X33 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "DateTimeSend", c => c.DateTime());
            AlterColumn("dbo.Messages", "Year", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "Year", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "DateTimeSend", c => c.DateTime(nullable: false));
        }
    }
}
