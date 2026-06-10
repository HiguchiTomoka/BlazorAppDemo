using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlazorAppDemo.Components.Data
{
    /// <summary>
    /// Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [IgnoreAntiforgeryToken] //
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AuthController(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// ログイン処理
        /// ※@rendermode InteractiveServerの場合、ブラウザにクッキーの設定が届かないため、
        /// ブラウザからAPIを直接呼び出してクッキー状態を保存する。
        /// razorファイル→auth.js→Controllerの順に呼ばれる
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            //メールアドレス検索
            var user = _db.UserInfoRecords
                .FirstOrDefault(x => x.MailAddress == request.Email);

            //Claim作成(ログインユーザーの情報)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.MailAddress),
                new Claim("UserId", user.Id.ToString()),
                new Claim("Password", user.Password.ToString())
            };

            // identity(身分証)の作成。作成したClaimをCookie認証で使用するとまとめている
            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            // ログインユーザー
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal
            );

            return Ok("ログイン成功");
        }

        /// <summary>
        /// ログアウト処理
        /// razorファイル→auth.js→Controllerの順に呼ばれる
        /// </summary>
        /// <returns></returns>
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }
    }
}