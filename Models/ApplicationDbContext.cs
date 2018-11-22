

using Microsoft.EntityFrameworkCore;

namespace Hasici.Web
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }

        public DbSet<Article> Articles { get; set; }

    }
}
