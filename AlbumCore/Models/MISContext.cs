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
        public virtual DbSet<BudgetBugda> BudgetBugda { get; set; }
        public virtual DbSet<BudgetItems> BudgetItems { get; set; }
        public virtual DbSet<BudgetT> BudgetT { get; set; }
        public virtual DbSet<Bugda> Bugda { get; set; }
        public virtual DbSet<CommAccount> CommAccount { get; set; }
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public virtual DbSet<LevStep> LevStep { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Process> Process { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
        public virtual DbSet<Tuser> Tuser { get; set; }

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
                entity.HasKey(e => e.Sn);

                entity.Property(e => e.Sn).HasColumnName("SN");

                entity.Property(e => e.Crdate)
                    .HasColumnName("crdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cruser)
                    .HasColumnName("cruser")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Download)
                    .HasColumnName("download")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Eddate)
                    .HasColumnName("eddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Eduser)
                    .HasColumnName("eduser")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(500);

                entity.Property(e => e.Sctrl)
                    .HasColumnName("sctrl")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AlbumPicture>(entity =>
            {
                entity.HasKey(e => new { e.Sn, e.Idnum });

                entity.Property(e => e.Sn).HasColumnName("SN");

                entity.Property(e => e.Idnum).HasColumnName("idnum");

                entity.Property(e => e.Crdate)
                    .HasColumnName("crdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cruser)
                    .HasColumnName("cruser")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Eddate)
                    .HasColumnName("eddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Eduser)
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

                entity.Property(e => e.Sctrl)
                    .HasColumnName("sctrl")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BudgetBugda>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("Budget_Bugda");

                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.Bugda)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<BudgetItems>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("Budget_Items");

                entity.Property(e => e.Uid).ValueGeneratedNever();

                entity.Property(e => e.Crdate)
                    .HasColumnName("crdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cruser)
                    .HasColumnName("cruser")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Eddate)
                    .HasColumnName("eddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Eduser)
                    .HasColumnName("eduser")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Items)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Sctrl)
                    .HasColumnName("sctrl")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BudgetT>(entity =>
            {
                entity.HasKey(e => e.Bno)
                    .HasName("PK_Budget");

                entity.ToTable("Budget_t");

                entity.Property(e => e.Bno).HasMaxLength(10);

                entity.Property(e => e.Dept).HasMaxLength(10);

                entity.Property(e => e.Month)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Sctrl).HasMaxLength(1);
            });

            modelBuilder.Entity<Bugda>(entity =>
            {
                entity.HasKey(e => e.Bugda1);

                entity.Property(e => e.Bugda1)
                    .HasColumnName("Bugda")
                    .HasMaxLength(5);

                entity.Property(e => e.Bugna)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sctrl)
                    .HasColumnName("sctrl")
                    .HasMaxLength(1);
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

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasKey(e => e.DeptNo);

                entity.Property(e => e.DeptNo).HasMaxLength(4);

                entity.Property(e => e.Agent)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Gpdept).HasColumnName("GPdept");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Sctrl)
                    .HasColumnName("sctrl")
                    .HasMaxLength(1);

                entity.Property(e => e.Supervisor)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EMP");

                entity.Property(e => e.員工編號)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.姓名)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.專案任務)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.性別)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.是否已在專案中)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeDetails>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PinCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LevStep>(entity =>
            {
                entity.HasKey(e => new { e.Bno, e.System, e.Type, e.Lev });

                entity.ToTable("Lev_Step");

                entity.Property(e => e.Bno)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.System)
                    .HasColumnName("system")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lev)
                    .HasColumnName("lev")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Crdate)
                    .HasColumnName("crdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cruser)
                    .HasColumnName("cruser")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Eddate)
                    .HasColumnName("eddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Eduser)
                    .HasColumnName("eduser")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sctrl)
                    .HasColumnName("sctrl")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Sign)
                    .IsRequired()
                    .HasColumnName("sign")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Penno);

                entity.Property(e => e.Penno).HasMaxLength(4);

                entity.Property(e => e.Deptno)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(20);

                entity.Property(e => e.Pname).HasMaxLength(15);
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.HasKey(e => new { e.System, e.Type, e.Lev })
                    .HasName("PK_LevStep");

                entity.Property(e => e.System)
                    .HasColumnName("system")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lev)
                    .HasColumnName("lev")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Sctrl)
                    .HasColumnName("sctrl")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Sign)
                    .HasColumnName("sign")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SALARY");

                entity.Property(e => e.員工編號)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tuser>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasColumnName("account")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Village)
                    .HasColumnName("village")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
