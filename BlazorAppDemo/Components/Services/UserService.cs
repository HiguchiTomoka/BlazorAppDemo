using BlazorAppDemo.Components.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Services
{
    /// <summary>
    /// ユーザー基本情報管理サービス
    /// </summary>
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
        /// ユーザー基本情報の全件取得処理
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserBaseInfo>> fetchUserBaseInfo()
        {
            // 該当ユーザーの人数
            List<UserBaseInfo> userRecords = await _dbContext.UserInfoRecords.ToListAsync();

            return userRecords;
        }

        /// <summary>
        /// ユーザー情報の新規登録処理
        /// </summary>
        /// <returns></returns>
        public async Task registUserBaseInfo(UserBaseInfo inputUserBaseInfo)
        {
            // 該当ユーザーの人数
            _dbContext.UserInfoRecords.Add(inputUserBaseInfo);

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 該当するユーザー情報がいるかどうかを取得する
        /// </summary>
        public int userExists(string userName, string password, List<UserBaseInfo> userRecords)
        {
           // 該当ユーザーの人数
           int numberOfApplicableUsers = userRecords.Where(r => r.UserName == userName && r.Password == password).Count();

            return numberOfApplicableUsers;
        }
    }
}