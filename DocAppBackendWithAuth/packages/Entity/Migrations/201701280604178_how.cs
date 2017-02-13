namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class how : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Symptoms", "Disease_Id", "dbo.Diseases");
            DropIndex("dbo.Symptoms", new[] { "Disease_Id" });
            CreateTable(
                "dbo.DiseaseSymptoms",
                c => new
                    {
                        Disease_Id = c.Int(nullable: false),
                        Symptom_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Disease_Id, t.Symptom_id })
                .ForeignKey("dbo.Diseases", t => t.Disease_Id, cascadeDelete: true)
                .ForeignKey("dbo.Symptoms", t => t.Symptom_id, cascadeDelete: true)
                .Index(t => t.Disease_Id)
                .Index(t => t.Symptom_id);
            
            DropColumn("dbo.Symptoms", "Disease_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Symptoms", "Disease_Id", c => c.Int());
            DropForeignKey("dbo.DiseaseSymptoms", "Symptom_id", "dbo.Symptoms");
            DropForeignKey("dbo.DiseaseSymptoms", "Disease_Id", "dbo.Diseases");
            DropIndex("dbo.DiseaseSymptoms", new[] { "Symptom_id" });
            DropIndex("dbo.DiseaseSymptoms", new[] { "Disease_Id" });
            DropTable("dbo.DiseaseSymptoms");
            CreateIndex("dbo.Symptoms", "Disease_Id");
            AddForeignKey("dbo.Symptoms", "Disease_Id", "dbo.Diseases", "Id");
        }
    }
}
