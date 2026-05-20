using BlazorAppDemo.Components.Data;
using BlazorAppDemo.Components.Data.DefineDB;

namespace BlazorAppDemo.Components.Services
{
    public class FoodImportService
    {
        private readonly AppDbContext _context;

        public FoodImportService(AppDbContext context)
        {
            _context = context;
        }

        public async Task ImportAsync(string path)
        {
            // 既存データ削除
            _context.Foods.RemoveRange(_context.Foods);

            await _context.SaveChangesAsync();

            // CSV読み込み
            var lines = File.ReadAllLines(path);

            // 1行目はヘッダなのでSkip(1)
            foreach (var line in lines.Skip(1))
            {
                // 空行スキップ
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var cols = line.Split(',');

                // 列数不足対策
                if (cols.Length < 6)
                    continue;

                var food = new FoodCompositionTable
                {
                    FoodCode = cols[1],
                    FoodName = cols[3],
                    Energy = ParseDecimal(cols[5]),
                    Protein = ParseDecimal(cols[9]),
                    Fat = ParseDecimal(cols[12]),
                    Carbohydrate = ParseDecimal(cols[20]),
                    Retinol = ParseDecimal(cols[37]),
                    Bcarotene = ParseDecimal(cols[41]),
                    VitaminB1 = ParseDecimal(cols[49]),
                    VitaminB2 = ParseDecimal(cols[50]),
                    VitaminC = ParseDecimal(cols[58]),
                    VitaminD = ParseDecimal(cols[43]),
                    VitaminE = ParseDecimal(cols[44]),
                };

                _context.Foods.Add(food);
            }

            await _context.SaveChangesAsync();
        }

        private decimal? ParseDecimal(string value)
        {
            value = value.Trim();

            // 特殊値対応
            if (string.IsNullOrWhiteSpace(value))
                return null;

            if (value == "-")
                return null;

            if (value == "Tr")
                return 0.01m;

            value = value.Replace("*", "");

            if (decimal.TryParse(value, out var result))
                return result;

            return null;
        }
    }
}