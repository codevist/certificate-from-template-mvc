namespace PDF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdada : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CertificateTypeId", "CertificateSet_Id", "dbo.CertificateSet");
            DropIndex("dbo.CertificateTypeId", new[] { "CertificateSet_Id" });
            DropColumn("dbo.CertificateTypeId", "CertificateSet_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CertificateTypeId", "CertificateSet_Id", c => c.Int());
            CreateIndex("dbo.CertificateTypeId", "CertificateSet_Id");
            AddForeignKey("dbo.CertificateTypeId", "CertificateSet_Id", "dbo.CertificateSet", "Id");
        }
    }
}
