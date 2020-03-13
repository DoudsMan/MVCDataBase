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

        public virtual DbSet<PersonAttributes> PersonAttributes { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }

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
            modelBuilder.Entity<PersonAttributes>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__PersonAt__AA2FFB85EB244509");

                entity.Property(e => e.PersonId).ValueGeneratedNever();

                entity.Property(e => e.Ethnicity).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.Height).IsUnicode(false);

                entity.Property(e => e.Weight).IsUnicode(false);
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("PK__Persons__AA2FFB85BF816C73");

                entity.Property(e => e.PersonId).ValueGeneratedNever();

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
