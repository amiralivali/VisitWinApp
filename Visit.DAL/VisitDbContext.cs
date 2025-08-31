using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Visit.DAL
{
    public partial class VisitDbContext : DbContext
    {
        public VisitDbContext()
            : base("data source=.;initial catalog=Visit;integrated security=True;encrypt=False;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<Bimar> Bimars { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Doctor_Takhasos> Doctor_Takhasoses { get; set; }
        public virtual DbSet<Takhasos> Takhasoses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bimar>()
                .Property(e => e.NationalCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bimar>()
                .HasMany(e => e.Visits)
                .WithRequired(e => e.Bimar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.CodeNezamPezeshki)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Doctor_Takhasoses)
                .WithRequired(e => e.Doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Visits)
                .WithRequired(e => e.Doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Takhasos>()
                .HasMany(e => e.Doctor_Takhasoses)
                .WithRequired(e => e.Takhasos)
                .HasForeignKey(e => e.TakhasosID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.MobileNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Bimar)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Chats)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FromID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Chats1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.ToID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Doctor)
                .WithRequired(e => e.User);
        }
    }
}
