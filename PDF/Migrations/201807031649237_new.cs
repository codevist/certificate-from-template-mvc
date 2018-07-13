namespace PDF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bolums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Personals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BolumID = c.Int(nullable: false),
                        Adi = c.String(),
                        Yas = c.Int(nullable: false),
                        Gorev = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bolums", t => t.BolumID, cascadeDelete: true)
                .Index(t => t.BolumID);
            
            
            CreateTable(
                "dbo.CertificateSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Topic = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        NameSurname = c.String(nullable: false),
                        CertificateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personals", "BolumID", "dbo.Bolums");
            DropIndex("dbo.Personals", new[] { "BolumID" });
            DropTable("dbo.CertificateSet");
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.Personals");
            DropTable("dbo.Bolums");
        }
    }
}
