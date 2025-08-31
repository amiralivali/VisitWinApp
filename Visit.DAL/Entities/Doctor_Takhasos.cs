namespace Visit.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tbl_Doctor Takhasos")]
    public partial class Doctor_Takhasos
    {
        public int ID { get; set; }

        public int DoctorID { get; set; }

        public byte TakhasosID { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Takhasos Takhasos { get; set; }
    }
}
