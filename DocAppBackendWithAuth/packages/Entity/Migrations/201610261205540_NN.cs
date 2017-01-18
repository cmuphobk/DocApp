namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NN : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diagnos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Weights",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Key_id = c.Int(),
                        Diagnos_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Symptoms", t => t.Key_id)
                .ForeignKey("dbo.Diagnos", t => t.Diagnos_id)
                .Index(t => t.Key_id)
                .Index(t => t.Diagnos_id);
            
            CreateTable(
                "dbo.Symptoms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weights", "Diagnos_id", "dbo.Diagnos");
            DropForeignKey("dbo.Weights", "Key_id", "dbo.Symptoms");
            DropIndex("dbo.Weights", new[] { "Diagnos_id" });
            DropIndex("dbo.Weights", new[] { "Key_id" });
            DropTable("dbo.Symptoms");
            DropTable("dbo.Weights");
            DropTable("dbo.Diagnos");
        }
    }
}
