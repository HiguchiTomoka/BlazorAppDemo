using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // UserInfoエンティティのDbSetを定義
        public DbSet<UserInfo> Users { get; set; }

        // WorkoutRecordエンティティのDbSetを定義
        public DbSet<WorkoutRecordInfo> WorkoutRecords { get; set; }
    }
}