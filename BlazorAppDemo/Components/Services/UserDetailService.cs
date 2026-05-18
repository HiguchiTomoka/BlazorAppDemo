using BlazorAppDemo.Components.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Services
{
    /// <summary>
    /// ユーザー詳細情報管理サービス
    /// </summary>
    public class UserDetailService
    {
        // AppDbContextのインスタンスを保持するフィールド
        private readonly AppDbContext _dbContext;

        // DIコンテナからAppDbContextを受け取るコンストラクタ
        public UserDetailService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// ユーザー詳細情報の全件取得処理
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserDetailInfo>> fetchUserDetailInfo()
        {
            // 該当ユーザーの人数
            List<UserDetailInfo> userDetailRecords = await _dbContext.UserDetailInfoRecords.ToListAsync();

            return userDetailRecords;
        }

        /// <summary>
        /// ユーザー詳細情報の新規登録処理
        /// </summary>
        /// <returns></returns>
        public async Task registUserDetailInfo(UserDetailInfo inputUserDetailInfo)
        {
            // 該当ユーザーの人数
            _dbContext.UserDetailInfoRecords.Add(inputUserDetailInfo);

            await _dbContext.SaveChangesAsync();
        }
    }
}