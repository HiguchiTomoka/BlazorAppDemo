using BlazorAppDemo.Components.Data;
using BlazorAppDemo.Components.Data.DefineDB;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Services
{
    /// <summary>
    /// ユーザー詳細情報管理サービス
    /// </summary>
    public class UserService(AppDbContext dbContext)
    {
        /// <summary>
        /// ユーザー詳細情報の全件取得処理
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserInfo>> FetchUserInfo()
        {
            // 全ユーザー検索
            List<UserInfo> userDetailRecords = await dbContext.UserInfoRecords.ToListAsync();

            return userDetailRecords;
        }

        /// <summary>
        /// 引数に与えられたメールアドレスとパスワードに合致する者のみ検索
        /// </summary>
        /// <param name="usersRecors"></param>
        /// <param name="mailaddress"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserInfo FetchMatchUserInfo(List<UserInfo> usersRecors, string mailaddress, string password)
        {
            // 該当ユーザー1件のみ
            UserInfo userDetailRecords = usersRecors.FirstOrDefault(r => r.MailAddress == mailaddress && r.Password == password);

            return userDetailRecords;
        }

        /// <summary>
        /// 該当するuserIDの体重を取得
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<double> FetchBodyWeight(int userId)
        {
            List<UserInfo> userInfos = await FetchUserInfo();
            UserInfo userInfo = userInfos.FirstOrDefault(r => r.Id == userId);
            double BodyWeight = userInfo.BodyWeight;

            return BodyWeight;

        }

        /// <summary>
        /// ユーザー詳細情報の新規登録処理
        /// </summary>
        /// <param name="inputUserData"></param>
        /// <returns></returns>
        public async Task RegistUserInfo(UserInfo inputUserData)
        {
            // 該当ユーザーの人数
            dbContext.UserInfoRecords.Add(inputUserData);

            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// ユーザー情報の更新処理
        /// </summary>
        /// <param name="inputUserData"></param>
        /// <returns></returns>
        public async Task UpdateUserInfo(UserInfo inputUserData)
        {
            // 更新レコードの特定
            var user = await dbContext.UserInfoRecords.FirstOrDefaultAsync
                (
                  x => 
                    x.UserName == inputUserData.UserName &&
                    x.Id == inputUserData.Id &&
                    x.MailAddress == inputUserData.MailAddress
                );

            // 更新内容の設定
            user.ThemeColor = inputUserData.ThemeColor;

            // 更新処理
            await dbContext.SaveChangesAsync();
        }
    }
}