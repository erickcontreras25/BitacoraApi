using Bitacora.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bitacora.API.Data

{
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Actividad> Actividad { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}