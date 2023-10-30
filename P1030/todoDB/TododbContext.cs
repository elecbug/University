using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace P1030.todoDB;

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

    public virtual DbSet<TodoDetail> TodoDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=tododb;uid=root;pwd=1479");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("todo");

            entity.Property(e => e.Id)
                .HasColumnType("date")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("name");
        });

        modelBuilder.Entity<TodoDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("todo_detail");

            entity.HasIndex(e => e.TodoId, "todo_id");

            entity.Property(e => e.Id)
                .HasColumnType("datetime")
                .HasColumnName("id");
            entity.Property(e => e.Descrip)
                .HasMaxLength(20)
                .HasColumnName("descrip");
            entity.Property(e => e.IsDone).HasColumnName("is_done");
            entity.Property(e => e.TodoId)
                .HasColumnType("date")
                .HasColumnName("todo_id");

            entity.HasOne(d => d.Todo).WithMany(p => p.TodoDetails)
                .HasForeignKey(d => d.TodoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("todo_detail_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
