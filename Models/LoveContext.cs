using System;
using Microsoft.EntityFrameworkCore;

namespace k_love.Models
{
    public class LoveContext : DbContext 
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public LoveContext(DbContextOptions<LoveContext> options) : base(options)
        {

        }
       
    }
}
