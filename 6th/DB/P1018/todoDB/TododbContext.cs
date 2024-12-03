using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace P1018.todoDB;

public partial class TododbContext : DbContext
{
    public TododbContext()
    {
    }

    public TododbContext(DbContextOptions<TododbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Todo> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=tododb;uid=root;pwd=1479");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.Dateid).HasName("PRIMARY");

            entity.ToTable("todo");

            entity.Property(e => e.Dateid)
                .HasColumnType("datetime")
                .HasColumnName("dateid");
            entity.Property(e => e.Checked).HasColumnName("checked");
            entity.Property(e => e.Descryp)
                .HasMaxLength(30)
                .HasColumnName("descryp");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
