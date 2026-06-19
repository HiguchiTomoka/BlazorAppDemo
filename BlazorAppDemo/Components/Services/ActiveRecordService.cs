using BlazorAppDemo.Components.Data;
using BlazorAppDemo.Components.Data.DefineDB;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Services
{
    /// <summary>
    /// 運動記録管理サービス
    /// </summary>
    public class ActiveRecordService(AppDbContext dbContext)
    {
        /// <summary>
        /// 該当者の運動情報取得処理
        /// </summary>
        /// <returns></returns>
        public async Task<List<ActiveRecordInfo>> FetchActiveRecordInfo(int userId)
        {
            List<ActiveRecordInfo> activeRecords = await dbContext.ActiveRecords.ToListAsync();

            return activeRecords;
        }

        /// <summary>
        /// 運動記録の新規登録処理
        /// </summary>
        /// <returns></returns>
        public async Task RegistActiveRecordInfo(ActiveRecordInfo inputActiveRecordInfo)
        {
            // 該当ユーザーの人数
            dbContext.ActiveRecords.Add(inputActiveRecordInfo);

            await dbContext.SaveChangesAsync();
        }
    }
}