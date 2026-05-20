using BlazorAppDemo.Components.Data.DefineDB;

namespace BlazorAppDemo.Components.Data
{
    /// <summary>
    /// 食事記録表示を行た目のまとめたクラス。
    /// </summary>
    public class MealDashboardData
    {
        public List<MealRecordInfo> MealList { get; set; } = new(); // 取得した食事記録リスト
        public int TotalCalories { get; set; }// 総カロリー摂取量
        public decimal TotalProtein { get; set; }// 総タンパク質量
        public decimal TotalFat { get; set; }// 総脂質量
        public decimal TotalCarbs { get; set; }// 総炭水化物量
    }
}