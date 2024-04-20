using Microsoft.EntityFrameworkCore;
using MyBeautySalon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBeautySalon.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DbContext> options)
            : base(options)
        { 
        }    
        public DbSet<Appointment> Appointments { get; set; }
    }
}
