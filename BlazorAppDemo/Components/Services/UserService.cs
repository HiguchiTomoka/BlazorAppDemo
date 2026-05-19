using BlazorAppDemo.Components.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Services
{
    /// <summary>
    /// ユーザー詳細情報管理サービス
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
        /// ユーザー詳細情報の全件取得処理
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserInfo>> fetchUserInfo()
        {
            // 全ユーザー検索
            List<UserInfo> userDetailRecords = await _dbContext.UserInfoRecords.ToListAsync();

            return userDetailRecords;
        }

        /// <summary>
        /// 引数に与えられたメールアドレスとパスワードに合致する者のみ検索
        /// </summary>
        /// <param name="usersRecors"></param>
        /// <param name="mailaddress"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserInfo fetchMatchUserInfo(List<UserInfo> usersRecors,string mailaddress, string password)
        {
            // 該当ユーザー1件のみ
            UserInfo userDetailRecords = usersRecors.FirstOrDefault(r => r.MailAddress == mailaddress && r.Password == password);

            return userDetailRecords;
        }

        /// <summary>
        /// ユーザー詳細情報の新規登録処理
        /// </summary>
        /// <returns></returns>
        public async Task registUserInfo(UserInfo inputUserData)
        {
            // 該当ユーザーの人数
            _dbContext.UserInfoRecords.Add(inputUserData);

            await _dbContext.SaveChangesAsync();
        }
    }
}