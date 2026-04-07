namespace BlazorAppDemo.Components.Data
{
    public class UserInfo
    {
        public int Id { get; set; }      // DBの主キー
        public string Name { get; set; } = string.Empty;
        public bool IsDone { get; set; }
    }
}
