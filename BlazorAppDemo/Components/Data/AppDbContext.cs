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

        // Userエンティティ(ユーザー基本情報)のDbSetを定義
        public DbSet<UserBaseInfo> UserInfoRecords { get; set; }

        // UserDetailエンティティ(ユーザー詳細情報)のDbSetを定義
        public DbSet<UserDetailInfo> UserDetailInfoRecords { get; set; }

        // Menuエンティティ(登録メニュー)のDbSetを定義
        public DbSet<MenulInfo> MenuRecords { get; set; }

        // ActiveRecordエンティティ(運動内容)のDbSetを定義
        public DbSet<ActiveRecordInfo> ActiveRecords { get; set; }
    }
}