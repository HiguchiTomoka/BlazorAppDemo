namespace BlazorAppDemo.Components.Data
{
    public class WorkoutRecordInfo
    {

        public int Id { get; set; }      // DBの主キー
        public string MenuName { get; set; } = string.Empty; // 筋トレのメニュー名
        public int Weight { get; set; } // 筋トレの重量
        public int Reps { get; set; } // 筋トレの回数
        public int Sets { get; set; } // 筋トレのセット数
        public DateTime TrainingDate { get; set; } // 筋トレの実施日
    }
}
