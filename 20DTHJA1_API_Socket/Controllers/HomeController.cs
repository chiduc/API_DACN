using API_DACN.Models;
using Libs.Entities;
using Libs.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace API_DACN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login(string username, string password)
        {
            // Thực hiện kiểm tra đăng nhập ở đây
            if (username == "admin" && password == "admin1")
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Sai tên đăng nhập hoặc mật khẩu. Vui lòng thử lại." });
            }
        }
        public IActionResult Home()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
