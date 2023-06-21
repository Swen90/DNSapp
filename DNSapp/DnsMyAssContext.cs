using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DNSapp;

public partial class DnsMyAssContext : DbContext
{
    public DnsMyAssContext()
    {
    }

    public DnsMyAssContext(DbContextOptions<DnsMyAssContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<ProductCatalog> ProductCatalogs { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DNS_my_ASS");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC07F370CC9B");

            entity.Property(e => e.CreatedAt).HasColumnType("date");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductCount).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__4D94879B");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Orders__ProductI__4CA06362");
        });

        modelBuilder.Entity<ProductCatalog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Catalog");

            entity.ToTable("ProductCatalog");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Product).HasMaxLength(50);
            entity.Property(e => e.ProductCount).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.ToTable("userInfo");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.SecondName).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
