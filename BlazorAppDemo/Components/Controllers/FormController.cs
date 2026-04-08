using Microsoft.AspNetCore.Mvc;

namespace BlazorAppDemo.Components.Controllers
{
    [ApiController] // APIですという宣言
    [Route("api/form")] // URLの指定
    public class FormController : ControllerBase
    {
        // POSTメソッド
        [HttpPost]
        public IActionResult Save([FromBody] string text)
        {
            // DB or LocalStorageに保存とかする(今はいったんコンソール表示)
            Console.WriteLine(text);
            return Ok();
        }
    }
}