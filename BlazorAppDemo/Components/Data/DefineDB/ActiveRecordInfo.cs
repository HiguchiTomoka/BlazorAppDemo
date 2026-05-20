namespace BlazorAppDemo.Components.Data.DefineDB
{
    /// <summary>
    /// 運動記録テーブルを表すクラス。
    /// </summary>
    public class ActiveRecordInfo
    {
        public int Id { get; set; }      // DBの主キー
        public string UserName { get; set; } = string.Empty; // 入力した名前
        public int UserId { get; set; } // 登録した人の一意なユーザー番号
        public int ActiveKind { get; set; } // 運動の種類(1:筋トレ、2:ランニング、3:スポーツ)
        public string ActiveName { get; set; } = string.Empty; // 活動名
        public decimal Weight { get; set; } // 重量(筋トレの場合)
        public int Reps { get; set; } // 回数(筋トレの場合)
        public int Set { get; set; } // セット(筋トレの場合)
        public decimal RunningDistance { get; set; } // 走った距離(ランニングの場合)
        public decimal Time { get; set; } // 行った時間(スポーツの場合)
    }
}