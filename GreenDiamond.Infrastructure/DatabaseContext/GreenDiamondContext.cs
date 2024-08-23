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

    public virtual DbSet<ClassOfTrade> ClassOfTrades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
