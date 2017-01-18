namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageInDiagnos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diagnos", "image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Diagnos", "image");
        }
    }
}
