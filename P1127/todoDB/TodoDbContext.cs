using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace P1127.todoDB;

public partial class TodoDbContext : DbContext
{
    public TodoDbContext()
    {
    }

    public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Todo> Todos { get; set; }

    public virtual DbSet<TodoDetail> TodoDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=todoDB;uid=root;pwd=1479");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.PersonName }).HasName("PRIMARY");

            entity.ToTable("todo");

            entity.Property(e => e.Id)
                .HasColumnType("date")
                .HasColumnName("id");
            entity.Property(e => e.PersonName)
                .HasMaxLength(10)
                .HasColumnName("person_name");
        });

        modelBuilder.Entity<TodoDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("todo_detail");

            entity.HasIndex(e => new { e.TodoId, e.TodoPersonName }, "todo_id");

            entity.Property(e => e.Id)
                .HasColumnType("datetime")
                .HasColumnName("id");
            entity.Property(e => e.IsDone)
                .HasColumnType("bit(1)")
                .HasColumnName("is_done");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .HasColumnName("title");
            entity.Property(e => e.TodoId)
                .HasColumnType("date")
                .HasColumnName("todo_id");
            entity.Property(e => e.TodoPersonName)
                .HasMaxLength(10)
                .HasColumnName("todo_person_name");

            entity.HasOne(d => d.Todo).WithMany(p => p.TodoDetails)
                .HasForeignKey(d => new { d.TodoId, d.TodoPersonName })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("todo_detail_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
