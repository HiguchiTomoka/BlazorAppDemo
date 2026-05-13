using BlazorAppDemo.Components.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Services
{
    public class WorkoutService
    {

        /// <summary>
        /// トレーニング記録情報を取得する
        /// </summary>
        public List<WorkoutRecordInfo> fecthWorkoutRecordInfo() => DbContext.WorkoutRecords.ToListAsync();
    }
}