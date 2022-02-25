using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API.Models
{
    public partial class TR3SDETR3SContext : DbContext
    {
        public TR3SDETR3SContext()
        {
        }

        public TR3SDETR3SContext(DbContextOptions<TR3SDETR3SContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Operation> Operations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.Property(e => e.N1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("n1");

                entity.Property(e => e.N2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("n2");

                entity.Property(e => e.Result)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("result");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
