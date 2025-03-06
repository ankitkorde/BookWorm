using System;
using System.Collections.Generic;
using BookWorm_Dotnet.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace BookWorm_Dotnet.Repository;

public partial class BookWormDbContext : DbContext
{

    public BookWormDbContext(DbContextOptions<BookWormDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserActivityLog> UserActivityLogs { get; set; }

    public DbSet<LogEntry> LogEntries { get; set; }  // Log Table

    public virtual DbSet<AttributeMaster> AttributeMasters { get; set; }

    public virtual DbSet<BeneficiaryMaster> BeneficiaryMasters { get; set; }

    public virtual DbSet<CartDetail> CartDetails { get; set; }

    public virtual DbSet<CartMaster> CartMasters { get; set; }

    public virtual DbSet<CustomerMaster> CustomerMasters { get; set; }

    public virtual DbSet<GenreMaster> GenreMasters { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<LanguageMaster> LanguageMasters { get; set; }

    public virtual DbSet<MyShelf> MyShelves { get; set; }

    public virtual DbSet<MyShelfDetail> MyShelfDetails { get; set; }

    public virtual DbSet<ProductArribute> ProductArributes { get; set; }

    public virtual DbSet<ProductBeneficiary> ProductBeneficiaries { get; set; }

    public virtual DbSet<ProductMaster> ProductMasters { get; set; }

    public virtual DbSet<ProductTypeMaster> ProductTypeMasters { get; set; }

    public virtual DbSet<RentDetail> RentDetails { get; set; }

    public virtual DbSet<RoyaltyCalculation> RoyaltyCalculations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=bookworm;user=root;password=root", ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");


        modelBuilder.Entity<AttributeMaster>(entity =>
        {
            entity.HasKey(e => e.AttributeId).HasName("PRIMARY");
        });

        modelBuilder.Entity<BeneficiaryMaster>(entity =>
        {
            entity.HasKey(e => e.BenId).HasName("PRIMARY");
        });

        modelBuilder.Entity<CartDetail>(entity =>
        {
            entity.HasKey(e => e.CartDetailsId).HasName("PRIMARY");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartDetails).HasConstraintName("FK5u7nakxaradawhygg84syvu92");

            entity.HasOne(d => d.Product).WithMany(p => p.CartDetails).HasConstraintName("FKlfyc1r1caest795hguh2nto2m");
        });

        modelBuilder.Entity<CartMaster>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PRIMARY");

            entity.HasOne(d => d.Customer).WithMany(p => p.CartMasters).HasConstraintName("FK44sbajofqx6cngygmmwui5igc");
        });

        modelBuilder.Entity<CustomerMaster>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");
        });

        modelBuilder.Entity<GenreMaster>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PRIMARY");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PRIMARY");

            entity.HasOne(d => d.Cart).WithMany(p => p.Invoices).HasConstraintName("FK74rjp8604l111tb50mbg1ubbd");

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices).HasConstraintName("FKk9j7m0iwl2u5ccibh3piocfj");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.InvDtlId).HasName("PRIMARY");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceDetails).HasConstraintName("FKpc7xa72mljy7weoct7uubgjy7");

            entity.HasOne(d => d.Product).WithMany(p => p.InvoiceDetails).HasConstraintName("FK1anfj9yh7l91txbjf905la63l");
        });

        modelBuilder.Entity<LanguageMaster>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PRIMARY");
        });

        modelBuilder.Entity<MyShelf>(entity =>
        {
            entity.HasKey(e => e.ShelfId).HasName("PRIMARY");

            entity.HasOne(d => d.Customer).WithOne(p => p.MyShelf)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKcda6p3ku4rwecfvmwjv73hpfv");
        });

        modelBuilder.Entity<MyShelfDetail>(entity =>
        {
            entity.HasKey(e => e.ShelfDtlId).HasName("PRIMARY");

            entity.HasOne(d => d.Product).WithMany(p => p.MyShelfDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKnydbo1psmybo0qmv9rvgqo1o6");

            entity.HasOne(d => d.Rent).WithMany(p => p.MyShelfDetails).HasConstraintName("FKbtjwvxhfuon9laskq27fxc7g5");

            entity.HasOne(d => d.Shelf).WithMany(p => p.MyShelfDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK3vkqpj988tywu7bhqeobs2nr5");
        });

        modelBuilder.Entity<ProductArribute>(entity =>
        {
            entity.HasKey(e => e.ProductAttributeId).HasName("PRIMARY");

            entity.HasOne(d => d.Attribute).WithMany(p => p.ProductArributes).HasConstraintName("FKbdigfhujyub7ojp7lirf5l6d0");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductArributes).HasConstraintName("FKeu0ww30gewhci44umhb3we5x1");
        });

        modelBuilder.Entity<ProductBeneficiary>(entity =>
        {
            entity.HasKey(e => e.ProductBeneficiaryId).HasName("PRIMARY");

            entity.HasOne(d => d.Beneficiary).WithMany(p => p.ProductBeneficiaries).HasConstraintName("FKivxugs1htmu5356ka6adepyo4");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductBeneficiaries).HasConstraintName("FKimuuqbtoxmdkej3yb1rhq7qoh");
        });

        modelBuilder.Entity<ProductMaster>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.Property(e => e.MinRentDays).HasDefaultValueSql("'3'");

            entity.HasOne(d => d.Genre).WithMany(p => p.ProductMasters).HasConstraintName("FKceskcho96iufjsecekgohckua");

            entity.HasOne(d => d.Language).WithMany(p => p.ProductMasters).HasConstraintName("FK98ccg011o5dskuffl8qf7o7kk");

            entity.HasOne(d => d.Type).WithMany(p => p.ProductMasters).HasConstraintName("FKkqx9yklv6gwn0rx53udabv5bd");
        });

        modelBuilder.Entity<ProductTypeMaster>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");
        });

        modelBuilder.Entity<RentDetail>(entity =>
        {
            entity.HasKey(e => e.RentId).HasName("PRIMARY");

            entity.HasOne(d => d.Customer).WithMany(p => p.RentDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKibhwskuwhrxv3d99r8vyd8xv2");

            entity.HasOne(d => d.Product).WithMany(p => p.RentDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKkn9g6d3w8jyxy23y1yree59f0");
        });

        modelBuilder.Entity<RoyaltyCalculation>(entity =>
        {
            entity.HasKey(e => e.RoyCalId).HasName("PRIMARY");

            entity.HasOne(d => d.Beneficiary).WithMany(p => p.RoyaltyCalculations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKk6t36n4hai8yk4uo16c2u4xl5");

            entity.HasOne(d => d.Invoice).WithMany(p => p.RoyaltyCalculations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK6ef225pnw8r22kw85xfua6hni");

            entity.HasOne(d => d.Product).WithMany(p => p.RoyaltyCalculations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKas49u6dxu8mu28ylsq0cucx1b");
        });

        //modelBuilder.Entity<LogEntry>().ToTable("log_entries");


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
