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
        /// トレーニング記録情報を取得する
        /// </summary>
        public async Task<List<WorkoutRecordInfo>> FetchWorkoutRecordInfo()
        {
            return await _dbContext.WorkoutRecords.ToListAsync();
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