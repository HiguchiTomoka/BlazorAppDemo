using BlazorAppDemo.Components.Data;
using BlazorAppDemo.Components.Services;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Controller
{
    public class WorkoutRecordController
    {
        private readonly WorkoutService _service;

        public WorkoutRecordController(WorkoutService service)
        {
            _service = service;
        }

        /// <summary>
        /// トレーニング記録情報を取得する
        /// </summary>
        public List<WorkoutRecordInfo> fecthWorkoutRecordInfo()
        {
            return _service.fecthWorkoutRecordInfo();
        }
    }
}
