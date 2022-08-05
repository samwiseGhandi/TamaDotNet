using Microsoft.EntityFrameworkCore;

namespace TamaDotNet.Server.Data {
    public class TamaDbContext:DbContext {
        public TamaDbContext(DbContextOptions<TamaDbContext> options):base(options) {

        }
        public DbSet<TamaModel> Tamas { get; set; }
        public DbSet<QuoteModel> Quotes { get; set; }
        
    }
}
