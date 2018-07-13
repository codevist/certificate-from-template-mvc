namespace PDF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CertificateTypeId",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CertificateID = c.Int(nullable: false),
                        path = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CertificateTypeId");
        }
    }
}
