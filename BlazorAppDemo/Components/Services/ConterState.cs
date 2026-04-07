namespace BlazorAppDemo.Components.Services
{
    public class CounterState
    {
        public int Count { get; private set; }

        // 「何か起きたら呼ばれる関数を登録できる箱」
        public event Action? OnChange;

        public void Increment()
        {
            Count++;
            // 値に変更があったことを通知
            OnChange?.Invoke();
        }

        public void Reset()
        {
            Count = 0;
            OnChange?.Invoke();
        }
    }
}
