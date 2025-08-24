namespace Visit.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Visit
    {
        public int ID { get; set; }

        public int DoctorID { get; set; }

        public int BimarID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public virtual Tbl_Bimar Tbl_Bimar { get; set; }

        public virtual Tbl_Doctor Tbl_Doctor { get; set; }
    }
}
