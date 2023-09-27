using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace P0927.quizDB;

public partial class Quiz1Context : DbContext
{
    public Quiz1Context()
    {
    }

    public Quiz1Context(DbContextOptions<Quiz1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=quiz1;uid=root;pwd=1479");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Number).HasName("PRIMARY");

            entity.ToTable("student");

            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.English).HasColumnName("english");
            entity.Property(e => e.Korean).HasColumnName("korean");
            entity.Property(e => e.Math).HasColumnName("math");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
