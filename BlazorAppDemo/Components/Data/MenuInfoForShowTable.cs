namespace BlazorAppDemo.Components.Data
{
    /// <summary>
    /// 自作料理の栄養価情報テーブルを表すクラス。
    /// </summary>
    public class MenuInfoForShowTable
    {
        public string DishName { get; set; } = string.Empty; // 登録した料理名
        public decimal? TotalCalories { get; set; } // カロリー
        public decimal? TotalProtein { get; set; } // タンパク質
        public decimal? TotalFat { get; set; } // 脂質
        public decimal? TotalCarbs { get; set; } // 炭水化物
        public decimal? TotalVitaminA { get; set; } // ビタミンA
        public decimal? TotalVitaminB1 { get; set; } // ビタミンB1
        public decimal? TotalVitaminB2 { get; set; } // ビタミンB2
        public decimal? TotalVitaminC { get; set; } // ビタミンC
        public decimal? TotalVitaminD { get; set; } // ビタミンD
        public decimal? TotalVitaminE { get; set; } // ビタミンE
        public decimal? TotalSaltEquivalent { get; set; } // 食塩相当量
    }
}