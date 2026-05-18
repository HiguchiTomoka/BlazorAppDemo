using BlazorAppDemo.Components.Data;
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
        public async Task<List<MenulInfo>> fetchUserBaseInfo()
        {
            // 該当ユーザーの人数
            List<MenulInfo> menuRecords = await _dbContext.MenuRecords.ToListAsync();

            return menuRecords;
        }

        /// <summary>
        /// 自作料理情報の新規登録処理
        /// </summary>
        /// <returns></returns>
        public async Task registUserBaseInfo(MenulInfo inputMenulInfo)
        {
            // 自作料理の情報を登録
            _dbContext.MenuRecords.Add(inputMenulInfo);

            await _dbContext.SaveChangesAsync();
        }
    }
}