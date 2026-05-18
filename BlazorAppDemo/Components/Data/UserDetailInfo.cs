namespace BlazorAppDemo.Components.Data
{
    /// <summary>
    /// ユーザーの詳細情報テーブルを表すクラス。
    /// </summary>
    public class UserDetailInfo
    {
        public int Id { get; set; }      // DBの主キー
        public string UserName { get; set; } = string.Empty; // 登録した名前
        public int UserNo { get; set; } // 登録した人のユーザー番号
        public string Gender { get; set; } = string.Empty; // 性別
        public double BodyWeight { get; set; } // 体重
        public double Bodyheight { get; set; } // 身長
        public double Age { get; set; } // 年齢
        public double BasalMetabolism { get; set; } // 基礎代謝量
        public double ExerciseIntensity { get; set; } // 身体活動レベル
    }
}