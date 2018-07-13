namespace PDF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CertificateSet", "path", c => c.String());
            DropColumn("dbo.CertificateSet", "CertificateID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CertificateSet", "CertificateID", c => c.Int(nullable: false));
            DropColumn("dbo.CertificateSet", "path");
        }
    }
}
