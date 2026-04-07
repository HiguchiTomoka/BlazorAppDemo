using BlazorAppDemo.Components;
using BlazorAppDemo.Components.Data;
using BlazorAppDemo.Components.Hubs;
using Microsoft.EntityFrameworkCore;

// アプリ起動
var builder = WebApplication.CreateBuilder(args);

// DI注入
// AddRazorComponentsメソッド(コンポーネントを登録、ルーティング・レンダリング基盤を作る)
// AddInteractiveServerComponentsメソッド(イベントや状態保持をサーバーで有効化、動的UIが可能になる)
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// AddDbContextをSQLサーバーの受口として登録
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// UserInfoをアプリ全体で共有
builder.Services.AddSingleton<UserInfo>();

// signalRハブの作成(リアルタイム通信を行うため)
builder.Services.AddSignalR();

var app = builder.Build();

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

// CSRF対策
app.UseAntiforgery();

// 静的ファイルの配信設定
app.MapStaticAssets();
// ルーティング登録,インタラクティブ機能の登録
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

// signalRエンドポイントの構成
app.MapHub<ConnectionHub>("/connectionHub");

app.Run();
