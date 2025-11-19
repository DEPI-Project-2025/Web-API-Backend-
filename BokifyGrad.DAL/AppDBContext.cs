using BokifyGrad.DAL.Models;
using Microsoft.EntityFrameworkCore;



namespace BokifyGrad.DAL
{
    internal class AppDBContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
    }
}
