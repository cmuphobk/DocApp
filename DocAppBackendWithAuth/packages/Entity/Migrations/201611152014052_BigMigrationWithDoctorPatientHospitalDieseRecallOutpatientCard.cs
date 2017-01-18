namespace DocAppBackendWithAuth.Entity.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BigMigrationWithDoctorPatientHospitalDieseRecallOutpatientCard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Card_Id = c.Int(),
                        Diagnos_id = c.Int(),
                        Doctor_Id = c.Int(),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OutpatientCards", t => t.Card_Id)
                .ForeignKey("dbo.Diagnos", t => t.Diagnos_id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .Index(t => t.Card_Id)
                .Index(t => t.Diagnos_id)
                .Index(t => t.Doctor_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.OutpatientCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Speciality = c.String(),
                        Hospital_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.Hospital_Id)
                .ForeignKey("dbo.BaseUsers", t => t.User_Id)
                .Index(t => t.Hospital_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recalls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        caller_Id = c.Int(),
                        doctor_Id = c.Int(),
                        hospital_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseUsers", t => t.caller_Id)
                .ForeignKey("dbo.Doctors", t => t.doctor_Id)
                .ForeignKey("dbo.Hospitals", t => t.hospital_Id)
                .Index(t => t.caller_Id)
                .Index(t => t.doctor_Id)
                .Index(t => t.hospital_Id);
            
            AddColumn("dbo.Symptoms", "Disease_Id", c => c.Int());
            CreateIndex("dbo.Symptoms", "Disease_Id");
            AddForeignKey("dbo.Symptoms", "Disease_Id", "dbo.Diseases", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Symptoms", "Disease_Id", "dbo.Diseases");
            DropForeignKey("dbo.Diseases", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Doctors", "User_Id", "dbo.BaseUsers");
            DropForeignKey("dbo.Doctors", "Hospital_Id", "dbo.Hospitals");
            DropForeignKey("dbo.Recalls", "hospital_Id", "dbo.Hospitals");
            DropForeignKey("dbo.Recalls", "doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Recalls", "caller_Id", "dbo.BaseUsers");
            DropForeignKey("dbo.Diseases", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Diseases", "Diagnos_id", "dbo.Diagnos");
            DropForeignKey("dbo.OutpatientCards", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Patients", "User_Id", "dbo.BaseUsers");
            DropForeignKey("dbo.Diseases", "Card_Id", "dbo.OutpatientCards");
            DropIndex("dbo.Recalls", new[] { "hospital_Id" });
            DropIndex("dbo.Recalls", new[] { "doctor_Id" });
            DropIndex("dbo.Recalls", new[] { "caller_Id" });
            DropIndex("dbo.Doctors", new[] { "User_Id" });
            DropIndex("dbo.Doctors", new[] { "Hospital_Id" });
            DropIndex("dbo.Patients", new[] { "User_Id" });
            DropIndex("dbo.OutpatientCards", new[] { "Patient_Id" });
            DropIndex("dbo.Diseases", new[] { "Patient_Id" });
            DropIndex("dbo.Diseases", new[] { "Doctor_Id" });
            DropIndex("dbo.Diseases", new[] { "Diagnos_id" });
            DropIndex("dbo.Diseases", new[] { "Card_Id" });
            DropIndex("dbo.Symptoms", new[] { "Disease_Id" });
            DropColumn("dbo.Symptoms", "Disease_Id");
            DropTable("dbo.Recalls");
            DropTable("dbo.Hospitals");
            DropTable("dbo.Doctors");
            DropTable("dbo.Patients");
            DropTable("dbo.OutpatientCards");
            DropTable("dbo.Diseases");
        }
    }
}
