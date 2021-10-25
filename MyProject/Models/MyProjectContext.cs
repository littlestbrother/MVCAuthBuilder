using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Models
{
  public class MyProjectContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Foo> Foos { get; set; }
    public DbSet<Bar> Bars { get; set; }
    public DbSet<FooBar> FooBar { get; set; }

    public MyProjectContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}
