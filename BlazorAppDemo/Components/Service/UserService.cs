using BlazorAppDemo.Components.Model;
using BlazorAppDemo.Components.DTO;

namespace BlazorAppDemo.Components.Service
{
    public class UserService
    {
        private static string GENDER_MALE = "male";
        private static string GENDER_FEMALE = "female";

        private List<User> _users = new()
        {
            new User { Id = 1,  Name = "B.D", Age = 25, IsActive= true, Gender = GENDER_FEMALE},
            new User { Id = 2, Name = "S.D", Age = 20, IsActive= false, Gender = GENDER_MALE},
            new User { Id = 3, Name = "Chime", Age = 32, IsActive= true, Gender = GENDER_FEMALE},
            new User { Id = 4, Name = "Tri", Age = 18, IsActive= false, Gender = GENDER_MALE},
            new User { Id = 5, Name = "Timp", Age = 28, IsActive= true, Gender = GENDER_MALE},
            new User { Id = 6, Name = "Vib", Age = 27, IsActive= true, Gender = GENDER_FEMALE},
            new User { Id = 7, Name = "Xyl", Age = 25, IsActive= false, Gender = GENDER_FEMALE},
            new User { Id = 8, Name = "Mari", Age = 29, IsActive= true, Gender = GENDER_FEMALE},
            new User { Id = 9, Name = "S.B", Age = 17, IsActive= false, Gender = GENDER_FEMALE},
            new User { Id = 10,  Name = "Clabess", Age = 18, IsActive= false, Gender = GENDER_FEMALE},
            new User { Id = 11, Name = "Cym", Age = 20, IsActive= false, Gender = GENDER_MALE},
            new User { Id = 12, Name = "S.Cym", Age = 21, IsActive= true, Gender = GENDER_FEMALE},
            new User { Id = 13, Name = "Tamb", Age = 23, IsActive= false, Gender = GENDER_MALE},
            new User { Id = 14, Name = "TomTom", Age = 22, IsActive= true, Gender = GENDER_FEMALE},
            new User { Id = 15, Name = "Tam", Age = 22, IsActive= false, Gender = GENDER_FEMALE},
            new User { Id = 16, Name = "Conga", Age = 26, IsActive= true, Gender = GENDER_MALE},
            new User { Id = 17, Name = "Bonga", Age = 26, IsActive= true, Gender = GENDER_MALE},
            new User { Id = 18, Name = "Drum", Age = 24, IsActive= false, Gender = GENDER_MALE},
            new User { Id = 19, Name = "Glok", Age = 21, IsActive= true, Gender = GENDER_FEMALE},
            new User { Id = 20, Name = "Shaker", Age = 25, IsActive= false, Gender = GENDER_FEMALE},
            new User { Id = 21, Name = "Agogo", Age = 24, IsActive= true, Gender = GENDER_MALE},
            new User { Id = 22, Name = "Cast", Age = 28, IsActive= true, Gender = GENDER_MALE},
            new User { Id = 23, Name = "Whisle", Age = 19, IsActive= false, Gender = GENDER_MALE},
        };

        /// <summary>
        /// デリゲートを受け取り、ユーザーを検索する
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<User> FindUsers(Func<User, bool> predicate)
        {
            // Whre(LINQのフィルタ機能)
            return _users.Where(predicate).ToList();
        }

        /// <summary>
        /// 検索 + ソート + ページング
        /// </summary>
        /// <param name="name"></param>
        /// <param name="minAge"></param>
        /// <param name="isActive"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<User> Search(
            string? name,
            int? minAge,
            bool? isActive,
            int page,
            int pageSize
            )
        {
            // 検索+ソート+ページング
            return _users
                .Where(u => string.IsNullOrEmpty(name) || u.Name.Contains(name))
                .Where(u => !minAge.HasValue || u.Age >= minAge.Value)
                .Where(u => !isActive.HasValue || u.IsActive == isActive.Value)
                .OrderBy(u => u.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

        }

        /// <summary>
        /// DTOに変換
        /// </summary>
        /// <returns></returns>
        public List<UserDto> GetUserDtos()
        {
            return _users
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Age = u.Age
                })
                .ToList();
        }

        /// <summary>
        /// 1件取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User? GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// 集計
        /// </summary>
        /// <returns></returns>
        public int GetActiveCount()
        {
            return _users.Count(u => u.IsActive);
        }

        /// <summary>
        /// 年齢の合計メソッド
        /// </summary>
        /// <returns></returns>
        public int GetTotalAge()
        {
            return _users.Sum(u => u.Age);
        }

        /// <summary>
        /// グループ化(年齢別)
        /// </summary>
        /// <returns></returns>
        public List<object> GroupByAge()
        {
            return _users
                .GroupBy(u => u.Age)
                .Select(g => new
                {
                    Age = g.Key,
                    Count = g.Count()
                })
                .Cast<object>()
                .ToList();
        }

        /// <summary>
        /// ページング単体
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<User> GetPaged(int page, int pageSize)
        {
            return _users
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        /// <summary>
        /// ソートの切り替え
        /// </summary>
        /// <param name="desc"></param>
        /// <returns></returns>
        public List<User> GetSorted(bool desc)
        {
            return desc ? 
                _users.OrderByDescending(u => u.Age).ToList()
                : _users.OrderBy(u => u.Age).ToList();
        }

    }
}