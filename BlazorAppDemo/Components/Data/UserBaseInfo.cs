namespace BlazorAppDemo.Components.Data
{
    /// <summary>
    /// ユーザーの基本情報テーブルを表すクラス。
    /// </summary>
    public class UserBaseInfo
    {
        public int Id { get; set; }      // DBの主キー
        public string UserName { get; set; } = string.Empty; // 入力した名前
        public string Password { get; set; } = string.Empty; // 入力したパスワード
    }
}