namespace PDF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PDF.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PDF.Models.Certificates>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PDF.Models.Certificates context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.CertificateTypeIDs.AddOrUpdate(x => x.id,
                new CertificateTypeID { CertificateID = 1, path = "C:/Projects/certificate-from-template-mvc/PDF/Content/Certificates/sertifika.pdf" },
                new CertificateTypeID { CertificateID = 2, path = "C:/Projects/certificate-from-template-mvc/PDF/Content/Certificates/sertifika.pdf" });

        }
    }
}
