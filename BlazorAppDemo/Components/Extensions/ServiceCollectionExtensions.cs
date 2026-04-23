using BlazorAppDemo.Components.Service;

namespace BlazorAppDemo.Components.Extensions
{
    /// <summary>
    /// Program.csに登録するための拡張機能
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
            services.AddScoped<UserDto>();
            services.AddScoped<CartService>();

            return services;
        }
    }
}