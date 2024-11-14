using System;
using System.Collections.Generic;
using GreenDiamond.Domain.ErpEntities;
using Microsoft.EntityFrameworkCore;

namespace GreenDiamond.Infrastructure;

public partial class GreenDiamondContext : DbContext
{
    public GreenDiamondContext(DbContextOptions<GreenDiamondContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CartMaster> CartMasters { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ClassOfTrade> ClassOfTrades { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartMaster>(entity =>
        {
            entity.ToTable("Cart_Masters");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CustId).HasColumnName("Cust_ID");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Clothe_Display");

            entity.ToTable("Category");

            entity.Property(e => e.ClotheName).HasMaxLength(100);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Discount).HasMaxLength(100);
            entity.Property(e => e.Discription).HasMaxLength(200);
            entity.Property(e => e.Manufacturer).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Photo).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TypeOfMaterial)
                .HasMaxLength(100)
                .HasColumnName("Type_Of_Material");
        });

        modelBuilder.Entity<ClassOfTrade>(entity =>
        {
            entity.HasKey(e => e.TradeCode).HasName("Class_Of_Trade$PrimaryKey");

            entity.ToTable("Class_Of_Trade");

            entity.Property(e => e.TradeCode)
                .HasMaxLength(3)
                .HasColumnName("Trade_Code");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.TradeDesc)
                .HasMaxLength(30)
                .HasColumnName("Trade_Desc");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PK__Customer__7B89513736BAD247");

            entity.ToTable("Customer");

            entity.Property(e => e.CustId).HasColumnName("Cust_ID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CustAddress)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Cust_Address");
            entity.Property(e => e.CustApproved).HasColumnName("Cust_Approved");
            entity.Property(e => e.CustCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Cust_City");
            entity.Property(e => e.CustCountry)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Cust_Country");
            entity.Property(e => e.CustEmailAddrerss)
                .HasMaxLength(50)
                .HasColumnName("Cust_EmailAddrerss");
            entity.Property(e => e.CustFirstName)
                .HasMaxLength(150)
                .HasColumnName("Cust_FirstName");
            entity.Property(e => e.CustLastName)
                .HasMaxLength(150)
                .HasColumnName("Cust_LastName");
            entity.Property(e => e.CustPassword)
                .HasMaxLength(50)
                .HasColumnName("Cust_Password");
            entity.Property(e => e.CustPhoneNo).HasColumnName("Cust_PhoneNo");
            entity.Property(e => e.CustState)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Cust_State");
            entity.Property(e => e.CustUserName)
                .HasMaxLength(50)
                .HasColumnName("Cust_UserName");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Login");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
