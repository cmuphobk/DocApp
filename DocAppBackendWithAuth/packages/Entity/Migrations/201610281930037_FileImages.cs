namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departaments", "smallImage", c => c.Binary());
            AddColumn("dbo.Departaments", "bigImage", c => c.Binary());
            AddColumn("dbo.Groups", "image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groups", "image");
            DropColumn("dbo.Departaments", "bigImage");
            DropColumn("dbo.Departaments", "smallImage");
        }
    }
}
