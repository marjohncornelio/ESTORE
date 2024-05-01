using ESTORE.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ESTORE.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } 
        public DbSet<Address> Addresses { get; set; }
    }
}
