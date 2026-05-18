using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Data
{
    /// <summary>
    /// DBコンテキストクラス。
    /// Entity Framework Coreを使用して、DBとのやり取りを行うためのクラスです。
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // MealRecordエンティティ(食事内容)のDbSetを定義
        public DbSet<MealRecordInfo> MealRecords { get; set; }
    }
}