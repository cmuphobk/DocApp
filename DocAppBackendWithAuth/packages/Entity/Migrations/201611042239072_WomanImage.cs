namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WomanImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departaments", "bigImageWoman", c => c.Binary());
            AddColumn("dbo.Groups", "imageWoman", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groups", "imageWoman");
            DropColumn("dbo.Departaments", "bigImageWoman");
        }
    }
}
