//using Microsoft.EntityFrameworkCore;

//public class TodoService
//{
//    // DB接続窓口
//    private readonly AppDbContext _context;
//    public TodoService(AppDbContext context) => _context = context;

//    // DBから全件取得
//    public async Task<List<TodoItem>> GetAll() await _context.TodoItems.ToListAsync();

//    // データ追加
//    public async Task Add(TodoItem item)
//    {
//        _context.TodoItems.Add(item);
//        await _context.SaveChangesAsync();
//    }
//}