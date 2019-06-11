namespace WindowsService1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DosyaOlaylari")]
    public partial class DosyaOlaylari
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Yol { get; set; }

        public DateTime? Tarih { get; set; }

        public int? EventTurId { get; set; }

        public virtual EylemTurleri EylemTurleri { get; set; }
    }
}
