namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departaments", "isDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Groups", "isDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Symptoms", "isDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Diagnos", "isDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Diagnos", "isDelete");
            DropColumn("dbo.Symptoms", "isDelete");
            DropColumn("dbo.Groups", "isDelete");
            DropColumn("dbo.Departaments", "isDelete");
        }
    }
}
