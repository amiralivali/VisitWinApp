using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Visit.DAL
{
    public partial class VisitDbContext : DbContext
    {
        public VisitDbContext()
            : base("name=VisitDbContext")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tbl_Bimar> Tbl_Bimar { get; set; }
        public virtual DbSet<Tbl_Chat> Tbl_Chat { get; set; }
        public virtual DbSet<Tbl_Doctor> Tbl_Doctor { get; set; }
        public virtual DbSet<Tbl_Doctor_Takhasos> Tbl_Doctor_Takhasos { get; set; }
        public virtual DbSet<Tbl_Takhasos> Tbl_Takhasos { get; set; }
        public virtual DbSet<Tbl_User> Tbl_User { get; set; }
        public virtual DbSet<Tbl_Visit> Tbl_Visit { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_Bimar>()
                .Property(e => e.NationalCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Bimar>()
                .HasMany(e => e.Tbl_Visit)
                .WithRequired(e => e.Tbl_Bimar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Doctor>()
                .Property(e => e.CodeNezamPezeshki)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Doctor>()
                .HasMany(e => e.Tbl_Doctor_Takhasos)
                .WithRequired(e => e.Tbl_Doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Doctor>()
                .HasMany(e => e.Tbl_Visit)
                .WithRequired(e => e.Tbl_Doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_Takhasos>()
                .HasMany(e => e.Tbl_Doctor_Takhasos)
                .WithRequired(e => e.Tbl_Takhasos)
                .HasForeignKey(e => e.TakhasosID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_User>()
                .Property(e => e.MobileNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_User>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_User>()
                .HasOptional(e => e.Tbl_Bimar)
                .WithRequired(e => e.Tbl_User);

            modelBuilder.Entity<Tbl_User>()
                .HasMany(e => e.Tbl_Chat)
                .WithRequired(e => e.Tbl_User)
                .HasForeignKey(e => e.FromID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_User>()
                .HasMany(e => e.Tbl_Chat1)
                .WithRequired(e => e.Tbl_User1)
                .HasForeignKey(e => e.FromID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tbl_User>()
                .HasOptional(e => e.Tbl_Doctor)
                .WithRequired(e => e.Tbl_User);
        }
    }
}
