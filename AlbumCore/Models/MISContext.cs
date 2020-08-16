using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AlbumCore.Models
{
    public partial class MISContext : DbContext
    {
        public MISContext()
        {
        }

        public MISContext(DbContextOptions<MISContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<AlbumPicture> AlbumPicture { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=JOY\\SQLEXPRESS;Initial Catalog=MIS;User ID=sa;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.SN);

                entity.Property(e => e.SN).HasColumnName("SN");

                entity.Property(e => e.crdate)
                    .HasColumnName("crdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.cruser)
                    .HasColumnName("cruser")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.download)
                    .HasColumnName("download")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.eddate)
                    .HasColumnName("eddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.eduser)
                    .HasColumnName("eduser")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.remark)
                    .HasColumnName("remark")
                    .HasMaxLength(500);

                entity.Property(e => e.sctrl)
                    .HasColumnName("sctrl")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AlbumPicture>(entity =>
            {
                entity.HasKey(e => new { e.Sn, e.idnum });

                entity.Property(e => e.Sn).HasColumnName("SN");

                entity.Property(e => e.idnum).HasColumnName("idnum");

                entity.Property(e => e.cruser)
                  .HasColumnName("cruser")
                  .HasMaxLength(10)
                  .IsUnicode(false);

                entity.Property(e => e.crdate)
                    .HasColumnName("crdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.eddate)
                    .HasColumnName("eddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.eduser)
                    .HasColumnName("eduser")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Path).HasColumnName("path");

                entity.Property(e => e.Picturefile)
                    .IsRequired()
                    .HasColumnName("picturefile");

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(500);

                entity.Property(e => e.sctrl)
                    .HasColumnName("sctrl")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<CommAccount>(entity =>
            {
                entity.HasKey(e => e.Sn);

                entity.ToTable("Comm_Account");

                entity.Property(e => e.Sn).HasColumnName("SN");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
