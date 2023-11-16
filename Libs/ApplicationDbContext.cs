using Libs.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Libs
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public DbSet<LiveRoom> Live { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Client> Student { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}