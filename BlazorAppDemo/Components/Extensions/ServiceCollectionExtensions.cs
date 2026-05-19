using BlazorAppDemo.Components.Services;

namespace BlazorAppDemo.Components.Extensions
{
    /// <summary>
    /// Program.csにSercieの内容を一括に登録するための拡張機能
    /// 
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Serviceの登録メソッド
        /// 
        /// Serviceを実装するたびにここに登録すること！
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<UserService>(); // ユーザー情報
            services.AddScoped<NutritionManageService>(); // 栄養管理
            services.AddScoped<ChartService>(); // チャートグラフ管理サービス

            return services;
        }
    }
}