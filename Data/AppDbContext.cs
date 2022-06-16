using csharp_webapi_example.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_webapi_example.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
  }
}
