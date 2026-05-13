using BlazorAppDemo.Components.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Services
{
    public class WorkoutService
    {
        private readonly AppDbContext _dbContext;

        public WorkoutService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// トレーニング全記録情報を取得する
        /// </summary>
        public async Task<List<WorkoutRecordInfo>> FetchWorkoutRecordInfo()
        {
            return await _dbContext.WorkoutRecords.ToListAsync();
        }
        /// <summary>
        /// 総トレーニング回数を取得する
        /// </summary>
        /// <returns></returns>
        public async Task<int> FetchTotalWorkoutCount()
        {
            return await _dbContext.WorkoutRecords.CountAsync();
        }
        /// <summary>
        /// 1週間のうちに何日トレーニングしたかを取得する
        /// </summary>
        /// <returns></returns>
        public async Task<int> FetchThisWeeksWorkoutCount()
        {
            // 今週の開始日を取得
            var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);

            // 今週の終了日を取得
            var endOfWeek = startOfWeek.AddDays(7);

            // 今週のトレーニング日数をデータベースから取得
            int thisWeek = await _dbContext.WorkoutRecords
                .Where(r => r.TrainingDate >= startOfWeek && r.TrainingDate < endOfWeek)
                .Select(r => r.TrainingDate.Date)// 日付だけ取り出し
                .Distinct() // 重複除去
                .CountAsync();

            return thisWeek;
        }

        /// <summary>
        /// Bnchの最大重量
        /// </summary>
        /// <returns></returns>
        public async Task<int> FetchMaxBenchPressWeight()
        {
            return await _dbContext.WorkoutRecords.Where(r => r.MenuName == "Bench Press").MaxAsync(r => r.Weight);
        }

        /// <summary>
        /// トレーニング記録情報(本日行ったもののみ)を取得する
        /// </summary>
        public async Task<List<WorkoutRecordInfo>> FetchTodayWorkoutRecordInfo()
        {
            // 本日の日付を取得
            var today = DateTime.Today;
            // トレーニング日が本日の日付と一致する記録をデータベースから取得
            return await _dbContext.WorkoutRecords.Where(r => r.TrainingDate >= today && r.TrainingDate < today.AddDays(1)).ToListAsync();
        }

        /// <summary>
        /// ワークアウト記録をデータベースに追加し、変更を非同期に保存します。
        /// </summary>
        /// <remarks>データベースへの保存時に DbUpdateException などの例外が発生する可能性があります。</remarks>
        /// <param name="record">追加する WorkoutRecordInfo。null は許容されません。</param>
        /// <returns>操作の完了を表す Task。</returns>
        public async Task AddWorkoutRecord(WorkoutRecordInfo record)
        {
            _dbContext.WorkoutRecords.Add(record);
            await _dbContext.SaveChangesAsync();
        }
    }
}