namespace Visit.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tbl_Doctor Takhasos")]
    public partial class Tbl_Doctor_Takhasos
    {
        public int ID { get; set; }

        public int DoctorID { get; set; }

        public byte TakhasosID { get; set; }

        public virtual Tbl_Doctor Tbl_Doctor { get; set; }

        public virtual Tbl_Takhasos Tbl_Takhasos { get; set; }
    }
}
