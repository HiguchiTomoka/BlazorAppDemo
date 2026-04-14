using BlazorAppDemo.Components;
using BlazorAppDemo.Components.Data;

// アプリ起動
var builder = WebApplication.CreateBuilder(args);

// DI注入
// AddRazorComponentsメソッド(コンポーネントを登録、ルーティング・レンダリング基盤を作る)
// AddInteractiveServerComponentsメソッド(BlazorServerを使用可能に。イベントや状態保持をサーバーで有効化、動的UIが可能になる)
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// DIコンテナに登録
builder.Services.AddScoped<LocalStorageService>();

// API(Controller)の使用
builder.Services.AddControllers();

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

// ルーティング登録,インタラクティブ機能の登録,
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
