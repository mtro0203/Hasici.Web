

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hasici.Web
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }

        public DbSet<Article> Articles { get; set; }

    }
}
