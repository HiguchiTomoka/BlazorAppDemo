using BlazorAppDemo.Components.Data;
using BlazorAppDemo.Components.Data.DefineDB;
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
        /// テーブル表示用データの取得
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<MenuInfoForShowTable>> FetchMenuInfoForTable(int userId)
        {
            // 該当ユーザーが登録したメニュー
            List<MenulInfo> menuRecords =
                await _dbContext.MenuRecords.Where(r => r.UserId == userId).ToListAsync();

             List<MenuInfoForShowTable> dataForTableDisplay = menuRecords.GroupBy(x => x.DishName).Select(g => new MenuInfoForShowTable
             {
                DishName = g.Key,
                TotalCalories = g.Sum(x => x.Calories),
                TotalProtein = g.Sum(x => x.Protein),
                TotalFat = g.Sum(x => x.Fat),
                TotalCarbs = g.Sum(x => x.Carbs),
                TotalVitaminA = g.Sum(x => x.VitaminA),
                TotalVitaminB1 = g.Sum(x => x.VitaminB1),
                TotalVitaminB2 = g.Sum(x => x.VitaminB2),
                TotalVitaminC = g.Sum(x => x.VitaminC),
                TotalVitaminD = g.Sum(x => x.VitaminD),
                TotalVitaminE = g.Sum(x => x.VitaminE),
                TotalSaltEquivalent = g.Sum(x => x.SaltEquivalent)
            })
            .ToList();

            return dataForTableDisplay;
        }

        /// <summary>
        /// メニューの詳細データ取得処理
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<MenulInfo>> FetchMenuInfoForDetail(int userId)
        {
            // 該当ユーザーが登録したメニュー
            List<MenulInfo> menuRecords =
                await _dbContext.MenuRecords.Where(r => r.UserId == userId).ToListAsync();

            List<MenuInfoForShowTable> dataForTableDisplay = menuRecords.GroupBy(x => x.DishName).Select(g => new MenuInfoForShowTable
            {
                DishName = g.Key,
                TotalCalories = g.Sum(x => x.Calories),
                TotalProtein = g.Sum(x => x.Protein),
                TotalFat = g.Sum(x => x.Fat),
                TotalCarbs = g.Sum(x => x.Carbs),
                TotalVitaminA = g.Sum(x => x.VitaminA),
                TotalVitaminB1 = g.Sum(x => x.VitaminB1),
                TotalVitaminB2 = g.Sum(x => x.VitaminB2),
                TotalVitaminC = g.Sum(x => x.VitaminC),
                TotalVitaminD = g.Sum(x => x.VitaminD),
                TotalVitaminE = g.Sum(x => x.VitaminE),
                TotalSaltEquivalent = g.Sum(x => x.SaltEquivalent)
            })
           .ToList();

            // TODO resultを入れ替えたい
            MenuInfoForShowTable menuInfo;


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
        public async Task DeleteMenuInfo(string dishName)
        {
            // 指定されたIDのレコードを特定
            var menu = await _dbContext.MenuRecords.FirstOrDefaultAsync(x => x.DishName == dishName);
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