using BlazorAppDemo.Components;
using BlazorAppDemo.Components.Data;
using BlazorAppDemo.Components.Data.DefineDB;
using BlazorAppDemo.Components.Extensions;
using BlazorAppDemo.Components.Hubs;
using BlazorAppDemo.Components.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

// アプリ起動
var builder = WebApplication.CreateBuilder(args);

// DI注入
// AddRazorComponentsメソッド(コンポーネントを登録、ルーティング・レンダリング基盤を作る)
// AddInteractiveServerComponentsメソッド(イベントや状態保持をサーバーで有効化、動的UIが可能になる)
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// コントローラーの追加
builder.Services.AddControllers();

// AddDbContextをSQLサーバーの受口として登録
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).LogTo(Console.WriteLine));

// MealRecordInfoをアプリ全体で共有
builder.Services.AddSingleton<MealRecordInfo>();

// signalRハブの作成(リアルタイム通信を行うため)
builder.Services.AddSignalR();

// Serviceの一括登録
builder.Services.AddAppServices();

// Cookieによる認証機能を使いますという宣言
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login"; // 未ログイン時にページにアクセスした際、強制で「/login」に飛ばす設定
    });

// 権限制御を使う宣言
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorizationCore();
// DIコンテナにHttipClientを登録
//builder.Services.AddHttpClient();

// HttpClient の接続先URLの設定
builder.Services.AddScoped(sp =>
{
    var navigation =
        sp.GetRequiredService<NavigationManager>();

    return new HttpClient
    {
        BaseAddress = new Uri(navigation.BaseUri)
    };
});

var app = builder.Build();

// Referencesフォルダ内の「食品成分表」CSVをDBに読み込む
using (var scope = app.Services.CreateScope())
{
    var importer = scope.ServiceProvider
        .GetRequiredService<FoodImportService>();

    await importer.ImportAsync("References/syokuhinseibunhyoCSV.csv");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // エラー処理(例外時のリダイレクト先)
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // HTTPS強制
    app.UseHsts();
}
// HTTPステータスコードごとにエラーページ表示
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

// HTTPをHTTPSに強制リダイレクト 
app.UseHttpsRedirection();

// Cookieを確認してログインユーザーを復元する
app.UseAuthentication();

// 対象ユーザーはアクセス可能かを判定
app.UseAuthorization();

// CSRF対策
app.UseAntiforgery();

// 静的ファイルの配信設定
app.MapStaticAssets();

// コントローラーの使用
app.MapControllers();

// ルーティング登録,インタラクティブ機能の登録
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

// signalRエンドポイントの構成
app.MapHub<ConnectionHub>("/connectionHub");

app.Run();
