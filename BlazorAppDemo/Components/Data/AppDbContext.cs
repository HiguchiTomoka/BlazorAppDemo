using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<UserInfo> Users { get; set; }
    }
}