using ASPNET.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options): base(options) 
        { 

        }
        public DbSet<Category> Categories { get; set; }
    }
}
