using Microsoft.EntityFrameworkCore;
namespace ef_core_web_app.Models{
    public class EFCoreWebAppContext : DbContext{
        public DbSet<Book>? Books { get; set; }
        public DbSet<Author>? Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(@"Server=tcp:sql-server-samu.database.windows.net,1433;Initial Catalog=sql-database;Persist Security Info=False;User ID=umasshia;Password=!m62xq^yYqSDeU;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}