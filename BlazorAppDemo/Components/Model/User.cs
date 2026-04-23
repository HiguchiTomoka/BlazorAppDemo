namespace BlazorAppDemo.Components.Model
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public required string Gender { get; set; }
    }
}