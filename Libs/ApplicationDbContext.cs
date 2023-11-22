using Libs.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Libs
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public DbSet<LoginAdmin> loginAdmin { get; set; }
        public DbSet<ClientModel> clientModels { get; set; }
        public DbSet<LiveRoom> Liveroom { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<BandManager> bandManagers {  get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}