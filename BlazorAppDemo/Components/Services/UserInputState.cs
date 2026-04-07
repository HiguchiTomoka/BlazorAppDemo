namespace BlazorAppDemo.Components.Services
{
    public class UserInputState
    {
        public string? InputText { get; set; }

        public event Action? OnChange;

        public void SetInput(string value)
        {
            InputText = value;
            OnChange?.Invoke(); // 登録者に通知
        }
    }
}