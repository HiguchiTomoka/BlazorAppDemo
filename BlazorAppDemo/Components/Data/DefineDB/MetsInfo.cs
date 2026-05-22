using System.ComponentModel.DataAnnotations;

namespace BlazorAppDemo.Components.Data.DefineDB
{
    /// <summary>
    /// METS(運動強度)を保管しているテーブルを表すクラス。
    /// </summary>
    public class MetsInfo
    {
        public int Id { get; set; }      // DBの主キー
        [Required]
        public string Code { get; set; } = "";
        [Required]
        public decimal Mets { get; set; } // METS
        public string ActiveNameJa { get; set; } = string.Empty; // 活動名(日本語)
        public string DescriptionJa { get; set; } = string.Empty; // 活動詳細(日本語)
        public string? ActiveNameEn { get; set; } = string.Empty; // 活動名(英語)
        public string? DescriptionEn { get; set; } = string.Empty; // 活動詳細(英語)
    }
}