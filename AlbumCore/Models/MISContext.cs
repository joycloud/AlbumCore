using System;
using System.Collections.Generic;
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
        public virtual DbSet<Album_User> Album_User { get; set; }
        //public IEnumerable<object> Album_User { get; internal set; }

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

            modelBuilder.Entity<Album_User>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.account)
               .HasColumnName("account")
               .HasMaxLength(20);

                entity.Property(e => e.name)
                .HasColumnName("name")
                .HasMaxLength(50);

                entity.Property(e => e.password)
                .HasColumnName("password")
                .HasMaxLength(1000);

                entity.Property(e => e.lev).HasColumnName("lev");

                entity.Property(e => e.type)
                .HasColumnName("type")
                .HasMaxLength(10);

                entity.Property(e => e.open)
                .HasColumnName("open")
                .HasMaxLength(1);

                entity.Property(e => e.Third)
                .HasColumnName("Third")
                .HasMaxLength(10);

                entity.Property(e => e.ThirdID)
                .HasColumnName("ThirdID")
                .HasMaxLength(200);


                entity.Property(e => e.createdate)
                .HasColumnName("createdate")
                .HasColumnType("datetime");

                entity.Property(e => e.editdate)
                .HasColumnName("editdate")
                .HasColumnType("datetime");

                entity.Property(e => e.logintime)
                .HasColumnName("logintime")
                .HasColumnType("datetime");
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
