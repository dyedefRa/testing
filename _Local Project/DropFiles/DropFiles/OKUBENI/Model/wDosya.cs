namespace DropFiles.OKUBENI.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wDosya")]
    public partial class wDosya
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Path { get; set; }

        public int OrderId { get; set; }

        public virtual wSipari wSipari { get; set; }
    }
}
