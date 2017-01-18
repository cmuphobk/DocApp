namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YearForMessages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Year");
        }
    }
}
