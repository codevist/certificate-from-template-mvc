using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace PDF.Models
{
    [Table("CertificateTypeId")]
    public partial class CertificateTypeID
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }
        public int CertificateID { get; set; }
        public string path { get; set; }
        
    }
}