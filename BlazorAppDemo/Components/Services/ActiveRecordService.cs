using BlazorAppDemo.Components.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Services
{
    /// <summary>
    /// 運動記録管理サービス
    /// </summary>
    public class ActiveRecordService
    {
        // AppDbContextのインスタンスを保持するフィールド
        private readonly AppDbContext _dbContext;

        // DIコンテナからAppDbContextを受け取るコンストラクタ
        public ActiveRecordService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// ユーザーの運動記録全件取得処理
        /// </summary>
        /// <returns></returns>
        public async Task<List<ActiveRecordInfo>> fetchActiveRecordInfo()
        {
            List<ActiveRecordInfo> activeRecords = await _dbContext.ActiveRecords.ToListAsync();

            return activeRecords;
        }

        /// <summary>
        /// ユーザー情報の新規登録処理
        /// </summary>
        /// <returns></returns>
        public async Task registUserBaseInfo(ActiveRecordInfo inputUserBaseInfo)
        {
            // 該当ユーザーの人数
            _dbContext.ActiveRecords.Add(inputUserBaseInfo);

            await _dbContext.SaveChangesAsync();
        }
    }
}