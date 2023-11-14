using Microsoft.AspNetCore.Mvc;

namespace _20DTHJA1_API_Socket.Controllers
{
    public class AdminController : Controller
    {
        // Phương thức này sẽ xử lý yêu cầu khi người dùng truy cập trang chủ đăng nhập quản trị
        public IActionResult Index()
        {
            return View();
        }

        // Phương thức này sẽ xử lý yêu cầu khi người dùng gửi thông tin đăng nhập
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Kiểm tra thông tin đăng nhập ở đây
            if (IsValidUser(username, password))
            {
                // Nếu thông tin đúng, có thể chuyển hướng đến trang quản trị
                return RedirectToAction("AdminDashboard", "Admin");
            }
            else
            {
                // Nếu thông tin sai, có thể hiển thị thông báo lỗi
                ViewBag.Error = "Thông tin đăng nhập không đúng";
                return View("Index");
            }
        }

        // Phương thức này kiểm tra xem người dùng có hợp lệ hay không (đây chỉ là một ví dụ đơn giản)
        private bool IsValidUser(string username, string password)
        {
            // Đây chỉ là ví dụ đơn giản, bạn cần thay thế bằng kiểm tra thực tế
            return username == "admin" && password == "admin123";
        }

        // Phương thức này sẽ xử lý yêu cầu khi người dùng đăng xuất
        public IActionResult Logout()
        {
            // Xử lý đăng xuất ở đây (nếu cần)
            return RedirectToAction("Index", "Home"); // Chuyển hướng về trang chủ sau khi đăng xuất
        }
    }
}
