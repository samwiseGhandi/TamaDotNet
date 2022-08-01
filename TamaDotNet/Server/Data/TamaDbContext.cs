using Microsoft.EntityFrameworkCore;

namespace TamaDotNet.Server.Data {
    public class TamaDbContext:DbContext {
        public TamaDbContext(DbContextOptions<TamaDbContext> options):base(options) {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TamaModel> Tamas { get; set; }
        public DbSet<QuoteModel> Quotes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<UserModel>()
                .HasOne(Ut => Ut.Tama)
                .WithOne(Tu => Tu.User)
                .HasForeignKey<UserModel>(u => u.TamaId);
        }
    }
}
