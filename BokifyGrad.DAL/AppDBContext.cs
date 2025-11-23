using BokifyGrad.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace BokifyGrad.DAL
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> users { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
    }
}
