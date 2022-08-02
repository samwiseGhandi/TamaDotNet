

namespace TamaDotNet.Server.Data {
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext(
            DbContextOptions options) : base(options) {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}