namespace Visit.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bimars",
                c => new
                    {
                        BimarID = c.Int(nullable: false),
                        NationalCode = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.BimarID)
                .ForeignKey("dbo.Users", t => t.BimarID)
                .Index(t => t.BimarID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        MobileNumber = c.String(nullable: false, maxLength: 11, fixedLength: true, unicode: false),
                        Email = c.String(maxLength: 254, fixedLength: true, unicode: false),
                        Picture = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FromID = c.Int(nullable: false),
                        ToID = c.Int(nullable: false),
                        Text = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.FromID)
                .ForeignKey("dbo.Users", t => t.ToID)
                .Index(t => t.FromID)
                .Index(t => t.ToID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorID = c.Int(nullable: false),
                        CodeNezamPezeshki = c.String(nullable: false, maxLength: 5, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.DoctorID)
                .ForeignKey("dbo.Users", t => t.DoctorID)
                .Index(t => t.DoctorID);
            
            CreateTable(
                "dbo.Tbl_Doctor Takhasos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DoctorID = c.Int(nullable: false),
                        TakhasosID = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Takhasos", t => t.TakhasosID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID)
                .Index(t => t.DoctorID)
                .Index(t => t.TakhasosID);
            
            CreateTable(
                "dbo.Takhasos",
                c => new
                    {
                        ID = c.Byte(nullable: false, identity: true),
                        Titel = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DoctorID = c.Int(nullable: false),
                        BimarID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Time = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID)
                .ForeignKey("dbo.Bimars", t => t.BimarID)
                .Index(t => t.DoctorID)
                .Index(t => t.BimarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "BimarID", "dbo.Bimars");
            DropForeignKey("dbo.Doctors", "DoctorID", "dbo.Users");
            DropForeignKey("dbo.Visits", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Tbl_Doctor Takhasos", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Tbl_Doctor Takhasos", "TakhasosID", "dbo.Takhasos");
            DropForeignKey("dbo.Chats", "ToID", "dbo.Users");
            DropForeignKey("dbo.Chats", "FromID", "dbo.Users");
            DropForeignKey("dbo.Bimars", "BimarID", "dbo.Users");
            DropIndex("dbo.Visits", new[] { "BimarID" });
            DropIndex("dbo.Visits", new[] { "DoctorID" });
            DropIndex("dbo.Tbl_Doctor Takhasos", new[] { "TakhasosID" });
            DropIndex("dbo.Tbl_Doctor Takhasos", new[] { "DoctorID" });
            DropIndex("dbo.Doctors", new[] { "DoctorID" });
            DropIndex("dbo.Chats", new[] { "ToID" });
            DropIndex("dbo.Chats", new[] { "FromID" });
            DropIndex("dbo.Bimars", new[] { "BimarID" });
            DropTable("dbo.Visits");
            DropTable("dbo.Takhasos");
            DropTable("dbo.Tbl_Doctor Takhasos");
            DropTable("dbo.Doctors");
            DropTable("dbo.Chats");
            DropTable("dbo.Users");
            DropTable("dbo.Bimars");
        }
    }
}
