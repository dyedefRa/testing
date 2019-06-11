namespace WindowsService1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EylemTurleri")]
    public partial class EylemTurleri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EylemTurleri()
        {
            DosyaOlaylaris = new HashSet<DosyaOlaylari>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DosyaOlaylari> DosyaOlaylaris { get; set; }
    }
}
