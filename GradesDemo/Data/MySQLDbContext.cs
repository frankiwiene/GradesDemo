using GradesDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace GradesDemo.Data
{
    public class MySQLDbContext : DbContext
    {
        public MySQLDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Subject> Subject { get; set; }
        //public DbSet<Activity> Activity { get; set; }
        public DbSet<Actividad> Actividad { get; set; }

        protected MySQLDbContext()
        {
        }
    }
}
