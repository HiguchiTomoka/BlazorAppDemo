namespace BlazorAppDemo.Components.Data
{
    /// <summary>
    /// 自作料理の栄養価情報テーブルを表すクラス。
    /// </summary>
    public class MenulInfo
    {
        public int Id { get; set; }      // DBの主キー
        public string UserName { get; set; } = string.Empty; // 登録した人の名前
        public string DishName { get; set; } = string.Empty; // 登録した料理名
        public string MaterialName { get; set; } = string.Empty; // 材料名称
        public double MaterialWeight { get; set; } // 材料重量
        public int Calories { get; set; } // カロリー
        public decimal Protein { get; set; } // タンパク質
        public decimal Fat { get; set; } // 脂質
        public decimal Carbs { get; set; } // 炭水化物
    }
}