namespace Visit.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Takhasos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Titel { get; set; }

        public virtual ICollection<Doctor_Takhasos> Doctor_Takhasoses { get; set; }
    }
}
