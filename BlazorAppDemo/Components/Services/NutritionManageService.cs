using BlazorAppDemo.Components.Data;
using BlazorAppDemo.Components.Data.DefineDB;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Services
{
    /// <summary>
    /// 食事記録管理サービス
    /// </summary>
    public class NutritionManageService(AppDbContext dbContext)
    {
        /// <summary>
        /// これまでの食事全記録情報を取得する
        /// </summary>
        public async Task<List<MealRecordInfo>> FetchMealRecordInfo(int userId)
        {
            return await dbContext.MealRecords.Where(r => r.UserId == userId).ToListAsync();
        }

        /// <summary>
        /// 食事記録情報(本日行ったもののみ)を取得する
        /// </summary>
        public async Task<List<MealRecordInfo>> FetchTodayMealRecordInfo()
        {
            // 本日の日付を取得
            var today = DateTime.Today;
            // 食事日が本日の日付と一致する記録をデータベースから取得
            return await dbContext.MealRecords.Where(r => r.MealDate >= today && r.MealDate < today.AddDays(1)).ToListAsync();
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
            return mealRecords.Sum(r => (int)(r.Calories));
        }

        /// <summary>
        /// 取得した記録中の合計タンパク質を取得
        /// </summary>
        /// <returns></returns>
        private decimal FetchTotalProtein(List<MealRecordInfo> mealRecords)
        {
            // 総カロリー摂取量
            return mealRecords.Sum(r => (int)r.Protein);
        }

        /// <summary>
        /// 取得した記録中の合計脂質量を取得
        /// </summary>
        /// <returns></returns>
        private decimal FetchTotalFat(List<MealRecordInfo> mealRecords)
        {
            // 総カロリー摂取量
            return mealRecords.Sum(r => (int)r.Fat);
        }

        /// <summary>
        /// 取得した記録中の合計炭水化物量を取得
        /// </summary>
        /// <returns></returns>
        private decimal FetchTotalCarbs(List<MealRecordInfo> mealRecords)
        {
            // 総カロリー摂取量
            return mealRecords.Sum(r => (int)r.Carbs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<int>> FetchCalorieList(int userId)
        {

            var mealList = await FetchMealRecordInfo(userId);

            DateTime dt = DateTime.Today;

            int diffFromSunday = dt.DayOfWeek - DayOfWeek.Sunday;
            if (diffFromSunday < 0)
            {
                diffFromSunday += 7; // 土曜日の場合(0-1=-1なので+7して6)
            }

            // 今週の月曜日（週の始まり）
            DateTime startOfWeek = dt.AddDays(-diffFromSunday);

            // 今週の土曜日（または日曜日で週の終わりを定義）
            DateTime endOfWeek = startOfWeek.AddDays(6);

            // 日曜日の総カロリー摂取量
            var rawSundayCalories = mealList.Where(r => r.MealDate == startOfWeek).Sum(r => r.Calories);
            int sundayCalories = rawSundayCalories == null ? 0 : (int) rawSundayCalories;

            // 月曜日の総カロリー摂取量
            var rawMondayCalories = mealList.Where(r => r.MealDate == startOfWeek.AddDays(1)).Sum(r => r.Calories);
            int mondayCalories = rawMondayCalories == null ? 0 : (int) rawMondayCalories;

            // 火曜日の総カロリー摂取量
            var rawThuesdayCalories = mealList.Where(r => r.MealDate == startOfWeek.AddDays(2)).Sum(r => r.Calories);
            int thuesdayCalories = rawThuesdayCalories == null ? 0 : (int) rawThuesdayCalories;

            // 水曜日の総カロリー摂取量
            var rawWednesdayCalories = mealList.Where(r => r.MealDate == startOfWeek.AddDays(3)).Sum(r => r.Calories);
            int wednesdayCalories = rawWednesdayCalories == null ? 0 : (int) rawWednesdayCalories;

            // 木曜日の総カロリー摂取量
            var rawThursdayCalories = mealList.Where(r => r.MealDate == endOfWeek.AddDays(-2)).Sum(r => r.Calories);
            int thursdayCalories = rawThursdayCalories == null ? 0 : (int) rawThursdayCalories;

            // 金曜日の総カロリー摂取量
            var rawFridayCalories = mealList.Where(r => r.MealDate == endOfWeek.AddDays(-1)).Sum(r => r.Calories);
            int fridayCalories = rawFridayCalories == null ? 0 : (int) rawFridayCalories;

            // 土曜日の総カロリー摂取量
            var rawSaturdayCalories = mealList.Where(r => r.MealDate == endOfWeek).Sum(r => r.Calories);
            int saturdayCalories = rawSaturdayCalories == null ? 0 : (int) rawSaturdayCalories;

            List<int> calorieList = new List<int>();
            calorieList.Add(sundayCalories);
            calorieList.Add(mondayCalories);
            calorieList.Add(thuesdayCalories);
            calorieList.Add(wednesdayCalories);
            calorieList.Add(thursdayCalories);
            calorieList.Add(fridayCalories);
            calorieList.Add(saturdayCalories);

            return calorieList;
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
            dbContext.MealRecords.Add(record);
            // 変更の保存処理
            await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 指定された食事記録を削除します。
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task DeleteMealRecord(MealRecordInfo record)
        {
            // 削除処理
            dbContext.MealRecords.Remove(record);
            // 変更の保存処理
            await dbContext.SaveChangesAsync();
        }
    }
}