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

        // ActiveRecordエンティティ(運動内容)のDbSetを定義
        public DbSet<ActiveRecordInfo> ActiveRecords { get; set; }

        // Userエンティティ(ユーザー情報)のDbSetを定義
        public DbSet<UserInfo> UserInfoRecords { get; set; }

        // Menuエンティティ(登録したメニュー)のDbSetを定義
        public DbSet<MenulInfo> MenuRecords { get; set; }
    }
}