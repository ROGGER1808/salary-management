﻿using App_Salary_Management.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App_Salary_Management.Data;

public partial class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseMySql("server=localhost;user=root;password=\"root\";database=employee_salary_management", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.39-mysql"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8_general_ci")
            .HasCharSet("utf8");


        modelBuilder.Entity<Department>().ToTable("departments");
        modelBuilder.Entity<Employee>().ToTable("employees");
        modelBuilder.Entity<TimeSheet>().ToTable("time_sheets");
        base.OnModelCreating(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<TimeSheet> TimeSheets { get; set; }
  
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}