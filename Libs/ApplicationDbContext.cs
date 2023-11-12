using Libs.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Libs
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public DbSet<Live> Live { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Student> Student { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}