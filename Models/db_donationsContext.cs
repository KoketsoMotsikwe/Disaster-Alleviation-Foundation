using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAF_Project.Models
{
    public partial class db_donationsContext : DbContext
    {
        public db_donationsContext()
        {
        }

        public db_donationsContext(DbContextOptions<db_donationsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Disaster> Disasters { get; set; } = null!;
        public virtual DbSet<Good> Goods { get; set; } = null!;
        public virtual DbSet<GoodsCategory> GoodsCategories { get; set; } = null!;
        public virtual DbSet<Monetary> Monetaries { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=db_donations;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Disaster>(entity =>
            {
                entity.ToTable("disaster");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("amount");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.Type)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.ToTable("goods");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Donor)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("donor");

                entity.Property(e => e.NumberOfItems).HasColumnName("number_of_items");
            });

            modelBuilder.Entity<GoodsCategory>(entity =>
            {
                entity.ToTable("goods_category");

                entity.HasIndex(e => e.Category, "UQ__goods_ca__F7F53CC26B939A3D")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Sequence).HasColumnName("sequence");
            });

            modelBuilder.Entity<Monetary>(entity =>
            {
                entity.ToTable("monetary");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Donor)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("donor");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.UserName, "UQ__user__7C9273C422B0179D")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
