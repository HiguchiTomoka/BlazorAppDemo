using BlazorAppDemo.Components.Data;
using BlazorAppDemo.Components.Data.DefineDB;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppDemo.Components.Services
{
    /// <summary>
    /// METS管理サービス
    /// </summary>
    public class MetsInfoService
    {
        // AppDbContextのインスタンスを保持するフィールド
        private readonly AppDbContext _dbContext;

        // DIコンテナからAppDbContextを受け取るコンストラクタ
        public MetsInfoService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// METS情報全件取得処理
        /// </summary>
        /// <returns></returns>
        public async Task<List<MetsInfo>> FetchMetsInfo()
        {
            List<MetsInfo> metsInfo = await _dbContext.MetsRecords.ToListAsync();

            return metsInfo;
        }

        /// <summary>
        /// 活動名称(日本語)の被っているものを除外する
        /// </summary>
        /// <param name="metsInfo"></param>
        /// <returns></returns>
        public async Task<List<MetsInfo>> FetchActiveNameInfo()
        {
            List<MetsInfo> metsInfo = await FetchMetsInfo();

            List<MetsInfo> activeNameInfo = metsInfo.DistinctBy(x => x.ActiveNameJa).ToList();

            return activeNameInfo;
        }

        /// <summary>
        /// 引数の「activeName」と合致する活動詳細リストを返却します
        /// </summary>
        /// <param name="activeName"></param>
        /// <param name="metsInfo"></param>
        /// <returns></returns> 
        public async Task<List<MetsInfo>> FetchActiveDetailInfo(string activeName)
        {
            List<MetsInfo> metsInfo = await FetchMetsInfo();

            List<MetsInfo> activeDetailInfo =
               metsInfo.Where(x => x.ActiveNameJa == activeName)
                .OrderBy(x => x.ActiveNameJa)
                .ToList();

            return activeDetailInfo;
        }

        /// <summary>
        /// 引数でもらったmetsリストから該当するMETS情報を検索し、METSの値のみを返す
        /// </summary>
        /// <param name="metsInfo"></param>
        /// <param name="activeName"></param>
        /// <param name="activeDetail"></param>
        /// <returns></returns>
        public decimal FetchMets(List<MetsInfo> metsInfo, string activeName, string activeDetail)
        {
            MetsInfo hitMetsuInfo =
                metsInfo.FirstOrDefault(r => r.ActiveNameJa == activeName && r.DescriptionJa == activeDetail);

            decimal metsu = hitMetsuInfo.Mets;

            return metsu;
        }
    }
}