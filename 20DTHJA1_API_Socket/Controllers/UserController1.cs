
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static API_DACN.Controllers.HomeController;


namespace _20DTHJA1_API_Socket.Controllers
{
    public class UserController : Controller
    {
        private List<User> users = new List<User>
    {
        new User { Id = 1, Username = "user1", Password = "password1", IsLocked = false, LockExpiration = null },
        new User { Id = 2, Username = "user2", Password = "password2", IsLocked = true, LockExpiration = DateTime.Now.AddDays(7) },
        // Thêm các người dùng khác nếu cần
    };

        public IActionResult Index()
        {
            return View(users);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (user == null)
            {
                return NotFound();
            }

            user.IsLocked = updatedUser.IsLocked;
            user.LockExpiration = updatedUser.LockExpiration;

            return RedirectToAction("Index");
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? LockExpiration { get; set; }
        // Các thuộc tính khác
    }


}
