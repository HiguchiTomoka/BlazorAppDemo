namespace BlazorAppDemo.Components.Data.DefineDB
{
    /// <summary>
    /// 自作料理の栄養価情報テーブルを表すクラス。
    /// </summary>
    public class MenulInfo
    {
        public int Id { get; set; }      // DBの主キー
        public int UserId { get; set; } // 登録した人の一意なユーザー番号
        public string DishName { get; set; } = string.Empty; // 登録した料理名
        public string MaterialName { get; set; } = string.Empty; // 材料名称
        public double MaterialWeight { get; set; } // 材料重量
        public decimal? Calories { get; set; } // カロリー
        public decimal? Protein { get; set; } // タンパク質
        public decimal? Fat { get; set; } // 脂質
        public decimal? Carbs { get; set; } // 炭水化物
        public decimal? VitaminA { get; set; } // ビタミンA
        public decimal? VitaminB1 { get; set; } // ビタミンB1
        public decimal? VitaminB2 { get; set; } // ビタミンB2
        public decimal? VitaminC { get; set; } // ビタミンC
        public decimal? VitaminD { get; set; } // ビタミンD
        public decimal? VitaminE { get; set; } // ビタミンE
        public decimal? SaltEquivalent { get; set; } // 食塩相当量
    }
}