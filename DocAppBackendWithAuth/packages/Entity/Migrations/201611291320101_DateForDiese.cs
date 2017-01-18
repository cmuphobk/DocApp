namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateForDiese : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diseases", "dateDisease", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Diseases", "dateDisease");
        }
    }
}
