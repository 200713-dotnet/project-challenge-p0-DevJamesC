using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaStore.Storing
{
    public partial class PizzaStoreDbContext : DbContext
    {
        public PizzaStoreDbContext()
        {
        }

        public PizzaStoreDbContext(DbContextOptions<PizzaStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Crust> Crust { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrder { get; set; }
        public virtual DbSet<FkCustomerOrderCustomer> FkCustomerOrderCustomer { get; set; }
        public virtual DbSet<FkCustomerOrderPizza> FkCustomerOrderPizza { get; set; }
        public virtual DbSet<FkPizzaToppingId> FkPizzaToppingId { get; set; }
        public virtual DbSet<Name> Name { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Topping> Topping { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=PizzaStoreDb;user id=sa;password=Elowyn32!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crust>(entity =>
            {
                entity.ToTable("Crust", "Pizza");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "Agent");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.HasOne(d => d.Name)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.NameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_NameId");
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.ToTable("CustomerOrder", "Agent");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.Property(e => e.OrderedFrom)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("totalPrice")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<FkCustomerOrderCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerOrderCustomerId)
                    .HasName("PK_CustomerOrderCustomerId");

                entity.ToTable("FK_CustomerOrder_Customer", "Agent");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.FkCustomerOrderCustomer)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_CustomerOrderCustomer_Customer");

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany(p => p.FkCustomerOrderCustomer)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_CustomerOrderCustomer_CustomerOrder");
            });

            modelBuilder.Entity<FkCustomerOrderPizza>(entity =>
            {
                entity.HasKey(e => e.CustomerOrderPizzaId)
                    .HasName("PK_CustomerOrderPizzaId");

                entity.ToTable("FK_CustomerOrder_Pizza", "Agent");

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany(p => p.FkCustomerOrderPizza)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_CustomerOrderPizzaId_CustomerOrder");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.FkCustomerOrderPizza)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_CustomerOrderPizzaId_Pizza");
            });

            modelBuilder.Entity<FkPizzaToppingId>(entity =>
            {
                entity.HasKey(e => e.PizzaToppingId)
                    .HasName("PK_PizzaToppingId");

                entity.ToTable("FK_Pizza_ToppingId", "Pizza");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.FkPizzaToppingId)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_PizzaTopping_PizzaId");

                entity.HasOne(d => d.Topping)
                    .WithMany(p => p.FkPizzaToppingId)
                    .HasForeignKey(d => d.ToppingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_PizzaTopping_ToppingId");
            });

            modelBuilder.Entity<Name>(entity =>
            {
                entity.ToTable("Name", "Agent");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.Property(e => e.NameText).HasMaxLength(250);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "Pizza");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.CrustId)
                    .HasConstraintName("FK_CrustId");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_SizeId");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("Shop", "Agent");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.HasOne(d => d.Name)
                    .WithMany(p => p.Shop)
                    .HasForeignKey(d => d.NameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shop_NameId");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size", "Pizza");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.ToTable("Topping", "Pizza");

                entity.Property(e => e.DateModified).HasColumnType("datetime2(0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
