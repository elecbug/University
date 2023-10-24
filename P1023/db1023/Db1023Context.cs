using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace P1023.db1023;

public partial class Db1023Context : DbContext
{
    public Db1023Context()
    {
    }

    public Db1023Context(DbContextOptions<Db1023Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Table1> Table1s { get; set; }

    public virtual DbSet<Table2> Table2s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=db1023;uid=root;pwd=1479");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Table1>(entity =>
        {
            entity.HasKey(e => e.Date).HasName("PRIMARY");

            entity.ToTable("table1");

            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<Table2>(entity =>
        {
            entity.HasKey(e => e.Date).HasName("PRIMARY");

            entity.ToTable("table2");

            entity.HasIndex(e => e.Fkdate, "fkdate");

            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Fkdate)
                .HasColumnType("datetime")
                .HasColumnName("fkdate");
            entity.Property(e => e.Menu)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("menu");
            entity.Property(e => e.Num).HasColumnName("num");

            entity.HasOne(d => d.FkdateNavigation).WithMany(p => p.Table2s)
                .HasForeignKey(d => d.Fkdate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("table2_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
