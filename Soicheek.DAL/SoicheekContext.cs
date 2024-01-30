using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Soicheek.DAL.DataModels;

namespace Soicheek.DAL;

public class SoicheekContext : IdentityDbContext<ApplicationUser>
{
    public SoicheekContext(DbContextOptions<SoicheekContext> options) : base(options)
    {
    }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
}