using BlazorAppDemo.Components.Data;
using BlazorAppDemo.Components.Data.DefineDB;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Services
{
    /// <summary>
    /// 食事記録管理サービス
    /// </summary>
    public class NutritionManageService
    {
        // AppDbContextのインスタンスを保持するフィールド
        private readonly AppDbContext _dbContext;

        // DIコンテナからAppDbContextを受け取るコンストラクタ
        public NutritionManageService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// これまでの食事全記録情報を取得する
        /// </summary>
        public async Task<List<MealRecordInfo>> FetchMealRecordInfo(int userId)
        {
            return await _dbContext.MealRecords.Where(r => r.UserId == userId).ToListAsync();
        }

        /// <summary>
        /// トレーニング記録情報(本日行ったもののみ)を取得する
        /// </summary>
        public async Task<List<MealRecordInfo>> FetchTodayMealRecordInfo()
        {
            // 本日の日付を取得
            var today = DateTime.Today;
            // トレーニング日が本日の日付と一致する記録をデータベースから取得
            return await _dbContext.MealRecords.Where(r => r.MealDate >= today && r.MealDate < today.AddDays(1)).ToListAsync();
        }

        /// <summary>
        /// 食事記録表示用データ
        /// </summary>
        /// <returns></returns>
        public async Task<MealDashboardData> FetchDashboardData(int userId)
        {
            // IDに該当する食事データを検索
            var mealList = await FetchMealRecordInfo(userId);

            MealDashboardData fecthMealRecords = new MealDashboardData
            {
                MealList = mealList,

                TotalCalories =
                    FetchTotalCalories(mealList),

                TotalProtein =
                    FetchTotalProtein(mealList),

                TotalFat =
                    FetchTotalFat(mealList),

                TotalCarbs =
                    FetchTotalCarbs(mealList)
            };

            return fecthMealRecords;
        }

        /// <summary>
        /// 取得した記録中の合計カロリーを取得
        /// </summary>
        /// <returns></returns>
        private int FetchTotalCalories(List<MealRecordInfo> mealRecords)
        {
            // 総カロリー摂取量
            return mealRecords.Sum(r => r.Calories);
        }

        /// <summary>
        /// 取得した記録中の合計タンパク質を取得
        /// </summary>
        /// <returns></returns>
        private decimal FetchTotalProtein(List<MealRecordInfo> mealRecords)
        {
            // 総カロリー摂取量
            return mealRecords.Sum(r => r.Protein);
        }

        /// <summary>
        /// 取得した記録中の合計脂質量を取得
        /// </summary>
        /// <returns></returns>
        private decimal FetchTotalFat(List<MealRecordInfo> mealRecords)
        {
            // 総カロリー摂取量
            return mealRecords.Sum(r => r.Fat);
        }

        /// <summary>
        /// 取得した記録中の合計炭水化物量を取得
        /// </summary>
        /// <returns></returns>
        private decimal FetchTotalCarbs(List<MealRecordInfo> mealRecords)
        {
            // 総カロリー摂取量
            return mealRecords.Sum(r => r.Carbs);
        }


        /// <summary>
        /// ワークアウト記録をデータベースに追加し、変更を非同期に保存します。
        /// </summary>
        /// <remarks>データベースへの保存時に DbUpdateException などの例外が発生する可能性があります。</remarks>
        /// <param name="record">追加する MealRecordInfo。null は許容されません。</param>
        /// <returns>操作の完了を表す Task。</returns>
        public async Task AddMealRecord(MealRecordInfo record)
        {
            // 登録処理
            _dbContext.MealRecords.Add(record);
            // 変更の保存処理
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 指定された食事記録を削除します。
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task deleteMealRecord(MealRecordInfo record)
        {
            // 削除処理
            _dbContext.MealRecords.Remove(record);
            // 変更の保存処理
            await _dbContext.SaveChangesAsync();
        }
    }
}