namespace Visit.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Doctor()
        {
            Tbl_Doctor_Takhasos = new HashSet<Tbl_Doctor_Takhasos>();
            Tbl_Visit = new HashSet<Tbl_Visit>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DoctorID { get; set; }

        [Required]
        [StringLength(5)]
        public string CodeNezamPezeshki { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Doctor_Takhasos> Tbl_Doctor_Takhasos { get; set; }

        public virtual Tbl_User Tbl_User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Visit> Tbl_Visit { get; set; }
    }
}
