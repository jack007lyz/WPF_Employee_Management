﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WPF_Employee_Management.DB;

public partial class EmployeeManagementWpfContext : DbContext
{
    public EmployeeManagementWpfContext()
    {
    }

    public EmployeeManagementWpfContext(DbContextOptions<EmployeeManagementWpfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PermissionState> PermissionStates { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<SalaryMonth> SalaryMonths { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskState> TaskStates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=msi\\sqlexpress;Database=EmployeeManagementWPF; Trust Server Certificate=true; Integrated Security=SSPI");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.ImagePath).IsUnicode(false);
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PositionId).HasColumnName("PositionID");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Department");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Position");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.ToTable("Permission");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.PermissionEndDate).HasColumnType("date");
            entity.Property(e => e.PermissionExplanation).IsUnicode(false);
            entity.Property(e => e.PermissionStartDate).HasColumnType("date");

            entity.HasOne(d => d.Employee).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permission_Employee");

            entity.HasOne(d => d.PermissionStateNavigation).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.PermissionState)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permission_PermissionState");
        });

        modelBuilder.Entity<PermissionState>(entity =>
        {
            entity.ToTable("PermissionState");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.StateName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.ToTable("Position");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.PositionName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Positions)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Position_Department");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.ToTable("Salary");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.MonthId).HasColumnName("MonthID");

            entity.HasOne(d => d.Employee).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Salary_Employee");

            entity.HasOne(d => d.Month).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.MonthId)
                .HasConstraintName("FK_Salary_SalaryMonth");
        });

        modelBuilder.Entity<SalaryMonth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Month");

            entity.ToTable("SalaryMonth");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MonthName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("Task");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.TaskContent).IsUnicode(false);
            entity.Property(e => e.TaskDeliveryDate).HasColumnType("date");
            entity.Property(e => e.TaskStartDate).HasColumnType("date");
            entity.Property(e => e.TaskTitle)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_Employee");

            entity.HasOne(d => d.TaskStateNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TaskState)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_TaskState");
        });

        modelBuilder.Entity<TaskState>(entity =>
        {
            entity.ToTable("TaskState");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.StateName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
