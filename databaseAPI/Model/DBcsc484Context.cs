using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace databaseAPI.Model
{
    public partial class DBcsc484Context : DbContext
    {
        public DBcsc484Context()
        {
        }

        public DBcsc484Context(DbContextOptions<DBcsc484Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=tcp:csc484.database.windows.net,1433;Initial Catalog=DBcsc484;Persist Security Info=False;User ID=csc484Admin;Password=MaoPasscsc484DB!@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentDate).IsUnicode(false);

                entity.Property(e => e.AppointmentNotes).IsUnicode(false);

                entity.Property(e => e.AppointmentTime).IsUnicode(false);

                entity.Property(e => e.DoctorId).IsUnicode(false);

                entity.Property(e => e.PatientId).IsUnicode(false);

                entity.Property(e => e.RoomNumber).IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__docto__6A30C649");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__patie__6B24EA82");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.DoctorId).IsUnicode(false);

                entity.Property(e => e.Department).IsUnicode(false);

                entity.Property(e => e.DoctorName).IsUnicode(false);

                entity.Property(e => e.Specialty).IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId).IsUnicode(false);

                entity.Property(e => e.Condition).IsUnicode(false);

                entity.Property(e => e.DoctorId).IsUnicode(false);

                entity.Property(e => e.PatientName).IsUnicode(false);

                entity.Property(e => e.RoomNumber).IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Patient__doctorI__6754599E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
