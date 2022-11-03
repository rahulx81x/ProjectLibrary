using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectLibraryDAL.Models
{
    public partial class ProjectLibraryDBContext : DbContext
    {
        public ProjectLibraryDBContext()
        {
        }

        public ProjectLibraryDBContext(DbContextOptions<ProjectLibraryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookList> BookList { get; set; }
        public virtual DbSet<LendingLog> LendingLog { get; set; }
        public virtual DbSet<Members> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ProjectLibraryDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookList>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("pk_bookid");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LendingLog>(entity =>
            {
                entity.HasKey(e => e.TransactId)
                    .HasName("pk_TransactId");

                entity.Property(e => e.BorrowedOn).HasColumnType("datetime");

                entity.Property(e => e.ReturnedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.LendingLog)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__LendingLo__BookI__3B75D760");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.LendingLog)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__LendingLo__Membe__3A81B327");
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("pk_memberid");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MemberName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MemberSince).HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
