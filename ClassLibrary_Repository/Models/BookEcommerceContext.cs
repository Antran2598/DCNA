using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookEccommerce_Admin.Models
{
    public partial class BookEcommerceContext : DbContext
    {
        public BookEcommerceContext()
        {
        }

        public BookEcommerceContext(DbContextOptions<BookEcommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Checkout> Checkouts { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShippingFee> ShippingFees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=AN\\ANTRAN; user id=sa;password=1;Database=BookEcommerce;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(11);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Book_Author");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Book_Category");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("FK_Book_Publisher");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Cart_Account");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_Cart_Book");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Categoryname).HasMaxLength(50);
            });

            modelBuilder.Entity<Checkout>(entity =>
            {
                entity.ToTable("Checkout");

                entity.Property(e => e.Depositornumber).HasMaxLength(50);

                entity.Property(e => e.Quantity)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Receivenember).HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Checkouts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Checkout_Account");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Checkouts)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Checkout_PaymentMethod");

                entity.HasOne(d => d.Shippingfee)
                    .WithMany(p => p.Checkouts)
                    .HasForeignKey(d => d.ShippingfeeId)
                    .HasConstraintName("FK_Checkout_ShippingFee");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("PaymentMethod");

                entity.Property(e => e.Paymentname).HasMaxLength(50);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("Publisher");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Review_Account");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_Review_Book");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Rolename).HasMaxLength(50);
            });

            modelBuilder.Entity<ShippingFee>(entity =>
            {
                entity.ToTable("ShippingFee");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
