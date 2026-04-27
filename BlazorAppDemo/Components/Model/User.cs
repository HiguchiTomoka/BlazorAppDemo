namespace BlazorAppDemo.Components.Model
{
    public class User
    {
        // ID
        public int Id { get; set; }
        // 名前
        public string? Name { get; set; }
        // 年齢
        public int Age { get; set; }
        // オンラインか
        public bool IsActive { get; set; }
        // 性別
        public required string Gender { get; set; }
        // 所属
        public string? Affiliated { get; set; }
        // 住所
        public string? Address { get; set; }
    }
}