namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Coordinates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "coordX", c => c.Int(nullable: false));
            AddColumn("dbo.Groups", "coordY", c => c.Int(nullable: false));
            AddColumn("dbo.Groups", "coordRadius", c => c.Int(nullable: false));
            AddColumn("dbo.Symptoms", "coordX", c => c.Int(nullable: false));
            AddColumn("dbo.Symptoms", "coordY", c => c.Int(nullable: false));
            AddColumn("dbo.Symptoms", "coordRadius", c => c.Int(nullable: false));
            DropColumn("dbo.Departaments", "coordX");
            DropColumn("dbo.Departaments", "coordY");
            DropColumn("dbo.Departaments", "coordRadius");
            DropColumn("dbo.Diagnos", "coordX");
            DropColumn("dbo.Diagnos", "coordY");
            DropColumn("dbo.Diagnos", "coordRadius");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Diagnos", "coordRadius", c => c.Int(nullable: false));
            AddColumn("dbo.Diagnos", "coordY", c => c.Int(nullable: false));
            AddColumn("dbo.Diagnos", "coordX", c => c.Int(nullable: false));
            AddColumn("dbo.Departaments", "coordRadius", c => c.Int(nullable: false));
            AddColumn("dbo.Departaments", "coordY", c => c.Int(nullable: false));
            AddColumn("dbo.Departaments", "coordX", c => c.Int(nullable: false));
            DropColumn("dbo.Symptoms", "coordRadius");
            DropColumn("dbo.Symptoms", "coordY");
            DropColumn("dbo.Symptoms", "coordX");
            DropColumn("dbo.Groups", "coordRadius");
            DropColumn("dbo.Groups", "coordY");
            DropColumn("dbo.Groups", "coordX");
        }
    }
}
