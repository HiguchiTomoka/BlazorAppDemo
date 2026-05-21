using BlazorAppDemo.Components.Data;
using BlazorAppDemo.Components.Data.DefineDB;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Services
{
    /// <summary>
    /// 食品成分表CSVデータを管理するサービス
    /// </summary>
    public class FoodImportService
    {
        private readonly AppDbContext _context;

        public FoodImportService(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 食品成分表CSVからDBに登録する処理
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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
                    WasteRate = int.Parse(cols[4]),
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
                    SaltEquivalent = ParseDecimal(cols[60]),
                };

                _context.Foods.Add(food);
            }

            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// オートコンプリート処理(検索処理)
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<List<FoodCompositionTable>> SearchFood(string keyword)
        {
            List<FoodCompositionTable> searchResults 
                = await _context.Foods.Where(x => x.FoodName.Contains(keyword))
                    .Take(10).ToListAsync();

            return searchResults;
        }

        /// <summary>
        /// 食品成分表から栄養素の文字列をdecimalに変換します
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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