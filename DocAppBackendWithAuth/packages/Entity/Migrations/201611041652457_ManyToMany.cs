namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Symptoms", "Group_id", "dbo.Groups");
            DropForeignKey("dbo.Groups", "Departament_id", "dbo.Departaments");
            DropIndex("dbo.Groups", new[] { "Departament_id" });
            DropIndex("dbo.Symptoms", new[] { "Group_id" });
            CreateTable(
                "dbo.GroupDepartaments",
                c => new
                    {
                        Group_id = c.Int(nullable: false),
                        Departament_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_id, t.Departament_id })
                .ForeignKey("dbo.Groups", t => t.Group_id, cascadeDelete: true)
                .ForeignKey("dbo.Departaments", t => t.Departament_id, cascadeDelete: true)
                .Index(t => t.Group_id)
                .Index(t => t.Departament_id);
            
            CreateTable(
                "dbo.SymptomGroups",
                c => new
                    {
                        Symptom_id = c.Int(nullable: false),
                        Group_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Symptom_id, t.Group_id })
                .ForeignKey("dbo.Symptoms", t => t.Symptom_id, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_id, cascadeDelete: true)
                .Index(t => t.Symptom_id)
                .Index(t => t.Group_id);
            
            DropColumn("dbo.Groups", "Departament_id");
            DropColumn("dbo.Symptoms", "Group_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Symptoms", "Group_id", c => c.Int());
            AddColumn("dbo.Groups", "Departament_id", c => c.Int());
            DropForeignKey("dbo.SymptomGroups", "Group_id", "dbo.Groups");
            DropForeignKey("dbo.SymptomGroups", "Symptom_id", "dbo.Symptoms");
            DropForeignKey("dbo.GroupDepartaments", "Departament_id", "dbo.Departaments");
            DropForeignKey("dbo.GroupDepartaments", "Group_id", "dbo.Groups");
            DropIndex("dbo.SymptomGroups", new[] { "Group_id" });
            DropIndex("dbo.SymptomGroups", new[] { "Symptom_id" });
            DropIndex("dbo.GroupDepartaments", new[] { "Departament_id" });
            DropIndex("dbo.GroupDepartaments", new[] { "Group_id" });
            DropTable("dbo.SymptomGroups");
            DropTable("dbo.GroupDepartaments");
            CreateIndex("dbo.Symptoms", "Group_id");
            CreateIndex("dbo.Groups", "Departament_id");
            AddForeignKey("dbo.Groups", "Departament_id", "dbo.Departaments", "id");
            AddForeignKey("dbo.Symptoms", "Group_id", "dbo.Groups", "id");
        }
    }
}
