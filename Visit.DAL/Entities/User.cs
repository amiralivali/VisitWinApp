namespace Visit.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
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
        public byte[] Picture { get; set; }

        public virtual Bimar Bimar { get; set; }

        public virtual ICollection<Chat> Chats { get; set; }

        public virtual ICollection<Chat> Chats1 { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
