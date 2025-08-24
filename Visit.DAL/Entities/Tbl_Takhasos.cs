namespace Visit.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Takhasos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Takhasos()
        {
            Tbl_Doctor_Takhasos = new HashSet<Tbl_Doctor_Takhasos>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Titel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Doctor_Takhasos> Tbl_Doctor_Takhasos { get; set; }
    }
}
