namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassificationSymptoms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departaments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Departament_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Departaments", t => t.Departament_id)
                .Index(t => t.Departament_id);
            
            AddColumn("dbo.Symptoms", "Group_id", c => c.Int());
            CreateIndex("dbo.Symptoms", "Group_id");
            AddForeignKey("dbo.Symptoms", "Group_id", "dbo.Groups", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "Departament_id", "dbo.Departaments");
            DropForeignKey("dbo.Symptoms", "Group_id", "dbo.Groups");
            DropIndex("dbo.Symptoms", new[] { "Group_id" });
            DropIndex("dbo.Groups", new[] { "Departament_id" });
            DropColumn("dbo.Symptoms", "Group_id");
            DropTable("dbo.Groups");
            DropTable("dbo.Departaments");
        }
    }
}
