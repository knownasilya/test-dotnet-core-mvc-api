using Microsoft.EntityFrameworkCore;
using TestApi.Models;

namespace TestApi.PrototypeApi {
  public class ApiContext : DbContext {
    public ApiContext(DbContextOptions<ApiContext> options) : base(options) {
    }

    public DbSet<User> Users { get; set; }
  }
}