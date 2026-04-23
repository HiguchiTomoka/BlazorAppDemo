namespace BlazorAppDemo.Components.Model
{
    public class BmiItem
    {
        public string Name { get; set; } = "";
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Bmi =>
            Weight / ((Height / 100.0) * (Height / 100.0));
    }
}