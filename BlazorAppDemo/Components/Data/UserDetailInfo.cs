namespace BlazorAppDemo.Components.Data
{
    /// <summary>
    /// ユーザーの詳細情報テーブルを表すクラス。
    /// </summary>
    public class UserDetailInfo
    {
        public int Id { get; set; }      // DBの主キー
        public string UserName { get; set; } = string.Empty; // 登録した名前
        public bool Gender { get; set; } // 性別(true:男性, false:女性)
        public double BodyWeight { get; set; } // 体重体重
        public double Age { get; set; } // 年齢
        public double ExerciseIntensity { get; set; } // 運動強度
    }
}