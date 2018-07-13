namespace PDF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    [Table("CertificateSet")]
    public partial class CertificateSet :DbContext
    {
        
        public int Id { get; set; }
        [Required]
        public string Topic { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        public string NameSurname { get; set; }
        public string path { get; set; }
       
        

    }
}

