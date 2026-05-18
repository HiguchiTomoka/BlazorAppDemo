using BlazorAppDemo.Components.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Services
{
    public class UserService
    {
        // AppDbContextのインスタンスを保持するフィールド
        private readonly AppDbContext _dbContext;

        // DIコンテナからAppDbContextを受け取るコンストラクタ
        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// これまでの食事全記録情報を取得する
        /// </summary>
        public async Task<List<MealRecordInfo>> FetchMealRecordInfo()
        {
            return await _dbContext.MealRecords.ToListAsync();
        }
    }
}