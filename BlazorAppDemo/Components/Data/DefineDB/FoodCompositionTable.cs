namespace BlazorAppDemo.Components.Data.DefineDB
{
    /// <summary>
    /// 食品成分表をDBに登録するテーブルを表すクラス。
    /// </summary>
    public class FoodCompositionTable
    {
        public int Id { get; set; }      // DBの主キー
        public string FoodCode { get; set; } = string.Empty; // 食品コード
        public string FoodName { get; set; } = string.Empty; // 食品名称
        public decimal? Energy { get; set; } // エネルギー
        public decimal? Protein { get; set; } // タンパク質
        public decimal? Fat { get; set; } // 脂質
        public decimal? Carbohydrate { get; set; } // 炭水化物
        public decimal? Retinol { get; set; } // レチノール
        public decimal? Bcarotene { get; set; } // βカロテン当量
        public decimal? VitaminB1 { get; set; } // ビタミンB1
        public decimal? VitaminB2 { get; set; } // ビタミンB2
        public decimal? VitaminC { get; set; } // ビタミンC
        public decimal? VitaminD { get; set; } // ビタミンD
        public decimal? VitaminE { get; set; } // ビタミンE(αトコフェロール)
    }
}