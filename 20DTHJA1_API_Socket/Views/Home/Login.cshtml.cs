using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _20DTHJA1_API_Socket.Views.Home
{
    public class LoginModel : PageModel
    {
        public IActionResult OnPostLogin(string username, string password)
        {
            // Thực hiện kiểm tra thông tin đăng nhập tại đây
            if (IsValidUser(username, password))
            {
                // Nếu thông tin đúng, chuyển hướng đến trang home
                return RedirectToPage("./View/Home/Home");

            }
            else
            {
                // Nếu thông tin sai, có thể hiển thị thông báo lỗi hoặc thực hiện các xử lý khác
                return Page();
            }
        }

        // Phương thức này kiểm tra xem người dùng có hợp lệ hay không (đây chỉ là một ví dụ đơn giản)
        private bool IsValidUser(string username, string password)
        {
            // Đây chỉ là ví dụ đơn giản, bạn cần thay thế bằng kiểm tra thực tế từ cơ sở dữ liệu hoặc bất kỳ nguồn dữ liệu nào khác
            return username == "admin" && password == "admin123";
        }
    }
}
