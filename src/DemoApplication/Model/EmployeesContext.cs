﻿using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Model
{
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions<EmployeesContext> options) : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
    }

    /// <summary>
    /// Factory class for EmployeesContext
    /// </summary>
    public static class EmployeesContextFactory
    {
        public static EmployeesContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeesContext>();
            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new EmployeesContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }

    public class Employee
    {
        public Employee()
        {
        }

        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
    }
}