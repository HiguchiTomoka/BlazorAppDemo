using System.ComponentModel.DataAnnotations;

namespace BlazorAppDemo.Components.Data.DefineDB
{
    /// <summary>
    /// ユーザーの詳細情報テーブルを表すクラス。
    /// </summary>
    public class UserInfo
    {
        public int Id { get; set; }      // DBの主キー
        [Required]
        public string UserName { get; set; } = string.Empty; // 登録した名前(ニックネームでも可)
        [Required]
        public string Password { get; set; } = string.Empty; // 登録した人のユーザー番号
        [Required]
        [EmailAddress]
        public string MailAddress { get; set; } = string.Empty; // ユーザーのメールアドレス
        [Required]
        public string Gender { get; set; } = string.Empty; // 性別
        [Required]
        public double BodyWeight { get; set; } // 体重
        [Required]
        public double Bodyheight { get; set; } // 身長
        [Required]
        public int Age { get; set; } // 年齢
        [Required]
        public double BasalMetabolism { get; set; } // 基礎代謝量
        [Required]
        public double PhysicalActivityLevel { get; set; } // 身体活動レベル
        public double TotalDailyEnergyExpenditure { get; set; } // 身体活動レベル
    }
}