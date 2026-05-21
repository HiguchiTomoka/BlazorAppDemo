using BlazorAppDemo.Components.Data;
using BlazorAppDemo.Components.Data.DefineDB;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Services
{
    /// <summary>
    /// 自作料理管理サービス
    /// </summary>
    public class MenuService
    {
        // AppDbContextのインスタンスを保持するフィールド
        private readonly AppDbContext _dbContext;

        // DIコンテナからAppDbContextを受け取るコンストラクタ
        public MenuService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 自作料理情報の全件取得処理
        /// </summary>
        /// <returns></returns>
        public async Task<List<MenulInfo>> FetchMenuInfo(int userId)
        {
            // 該当ユーザーが登録したメニュー
            List<MenulInfo> menuRecords = 
                await _dbContext.MenuRecords.Where(r => r.UserId == userId).ToListAsync();

            return menuRecords;
        }

        /// <summary>
        /// 自作料理情報の新規登録処理
        /// </summary>
        /// <returns></returns>
        public async Task RegistMenuInfo(MenulInfo inputMenulInfo)
        {
            // 自作料理の情報を登録
            _dbContext.MenuRecords.Add(inputMenulInfo);

            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 自作料理情報の削除処理
        /// </summary>
        /// <returns></returns>
        public async Task DeleteMenuInfo(int id)
        {
            // 指定されたIDのレコードを特定
            var menu = await _dbContext.MenuRecords.FirstOrDefaultAsync(x => x.Id == id);
            // ない場合終了
            if (menu == null)
            {
                return;
            }
            // 削除処理
            _dbContext.MenuRecords.Remove(menu);
            // 変更の保存処理
            await _dbContext.SaveChangesAsync();
        }
    }
}