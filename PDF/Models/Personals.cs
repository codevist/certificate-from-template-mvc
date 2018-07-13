namespace PDF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Personals
    {
        public int Id { get; set; }

        public int BolumID { get; set; }

        public string Adi { get; set; }

        public int Yas { get; set; }

        public string Gorev { get; set; }

        public virtual Bolums Bolums { get; set; }
    }
}
