using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAppCoreAzure.Models
{
    public partial class PayScaleDbContext : DbContext
    {
        public PayScaleDbContext()
        {
        }

        public PayScaleDbContext(DbContextOptions<PayScaleDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PayScale> PayScale { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:payscale2.database.windows.net,1433;Initial Catalog=PayScaleDb;Persist Security Info=False;User ID=admin1255;Password=admin@1255;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PayScale>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__PayScale__7AD04F11475426D6");

                entity.Property(e => e.Da)
                    .HasColumnName("DA")
                    .HasComputedColumnSql("((0.05)*[BasicSalary])");

                entity.Property(e => e.Hra)
                    .HasColumnName("HRA")
                    .HasComputedColumnSql("((0.1)*[BasicSalary])");

                entity.Property(e => e.InHandSalary).HasComputedColumnSql("(((([BasicSalary]+(0.1)*[BasicSalary])+(0.05)*[BasicSalary])+(0.05)*[BasicSalary])-(0.1)*[BasicSalary])");

                entity.Property(e => e.NetSalary)
                    .HasColumnName("netSalary")
                    .HasComputedColumnSql("((([BasicSalary]+(0.1)*[BasicSalary])+(0.05)*[BasicSalary])+(0.05)*[BasicSalary])");

                entity.Property(e => e.PayBand)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ta)
                    .HasColumnName("TA")
                    .HasComputedColumnSql("((0.05)*[BasicSalary])");

                entity.Property(e => e.Tds)
                    .HasColumnName("TDS")
                    .HasComputedColumnSql("((0.1)*[BasicSalary])");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
