namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isMaleisFemale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departaments", "isMale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Departaments", "isFemale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Groups", "isMale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Groups", "isFemale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Symptoms", "isMale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Symptoms", "isFemale", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Symptoms", "isFemale");
            DropColumn("dbo.Symptoms", "isMale");
            DropColumn("dbo.Groups", "isFemale");
            DropColumn("dbo.Groups", "isMale");
            DropColumn("dbo.Departaments", "isFemale");
            DropColumn("dbo.Departaments", "isMale");
        }
    }
}
