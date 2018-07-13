namespace PDF.Models
{
    using System.Collections.Generic;
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Certificates : DbContext
    {
        public Certificates()
            : base("name=Certificates")
        {
        }
        
        public virtual DbSet<CertificateSet> CertificateSet { get; set; }
        
        public virtual DbSet<CertificateTypeID> CertificateTypeIDs { get; set; }
        







        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bolums>()
                .HasMany(e => e.Personals)
                .WithRequired(e => e.Bolums)
                .HasForeignKey(e => e.BolumID);
        }
        public virtual DbSet<Personals> Personals { get; set; }
        public virtual DbSet<Bolums> Bolums { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
    }
}
