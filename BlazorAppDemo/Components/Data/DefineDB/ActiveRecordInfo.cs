using System.ComponentModel.DataAnnotations;

namespace BlazorAppDemo.Components.Data.DefineDB
{
    /// <summary>
    /// 運動記録テーブルを表すクラス。
    /// </summary>
    public class ActiveRecordInfo
    {
        public int Id { get; set; }      // DBの主キー
        public int UserId { get; set; } // 登録した人の一意なユーザー番号
        public int ActiveKind { get; set; } // 運動の種類
        [Required]
        public string ActiveName { get; set; } = string.Empty; // 運動の種類
        public string ActiveDetail { get; set; } = string.Empty; // 活動詳細
        [Required]
        public decimal Time { get; set; } // 活動時間
        [Required]
        public decimal CaloriesBurned { get; set; } // 消費カロリー
    }
}