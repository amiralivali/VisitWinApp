namespace Visit.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Chat
    {
        public int ID { get; set; }

        public int FromID { get; set; }

        public int ToID { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime DateTime { get; set; }

        public bool IsRead { get; set; }

        public virtual Tbl_User Tbl_User { get; set; }

        public virtual Tbl_User Tbl_User1 { get; set; }
    }
}
