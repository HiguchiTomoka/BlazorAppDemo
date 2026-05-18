namespace BlazorAppDemo.Components.Data
{
    /// <summary>
    /// 食事記録の情報テーブルを表すクラス。
    /// </summary>
    public class MealRecordInfo
    {
        public int Id { get; set; }      // DBの主キー
        public string MealName { get; set; } = string.Empty; // 食事した内容
        public int UserNo { get; set; } // 登録した人の一意なユーザー番号
        public int Calories { get; set; } // カロリー
        public decimal Protein { get; set; } // タンパク質
        public decimal Fat { get; set; } // 脂質
        public decimal Carbs { get; set; } // 炭水化物
        public DateTime MealDate { get; set; } // 食事をした日時
    }
}