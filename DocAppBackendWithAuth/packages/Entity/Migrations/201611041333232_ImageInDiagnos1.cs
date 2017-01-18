namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageInDiagnos1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diagnos", "descripton", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Diagnos", "descripton");
        }
    }
}
