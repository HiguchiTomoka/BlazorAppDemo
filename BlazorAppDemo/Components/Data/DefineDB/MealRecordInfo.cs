using System.ComponentModel.DataAnnotations;

namespace BlazorAppDemo.Components.Data.DefineDB
{
    /// <summary>
    /// 食事記録の情報テーブルを表すクラス。
    /// </summary>
    public class MealRecordInfo
    {
        public int Id { get; set; }      // DBの主キー
        [Required]
        public string MealName { get; set; } = string.Empty; // 食事した内容
        public int UserId { get; set; } // 登録した人の一意なユーザー番号
        [Required]
        public decimal? Calories { get; set; } // カロリー
        [Required]
        public decimal? Protein { get; set; } // タンパク質
        [Required]
        public decimal? Fat { get; set; } // 脂質
        [Required]
        public decimal? Carbs { get; set; } // 炭水化物
        public DateTime MealDate { get; set; } // 食事をした日時
    }
}