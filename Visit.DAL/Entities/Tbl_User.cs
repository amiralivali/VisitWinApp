namespace Visit.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_User()
        {
            Tbl_Chat = new HashSet<Tbl_Chat>();
            Tbl_Chat1 = new HashSet<Tbl_Chat>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(11)]
        public string MobileNumber { get; set; }

        [StringLength(254)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Picture { get; set; }

        public virtual Tbl_Bimar Tbl_Bimar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Chat> Tbl_Chat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Chat> Tbl_Chat1 { get; set; }

        public virtual Tbl_Doctor Tbl_Doctor { get; set; }
    }
}
