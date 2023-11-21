using Libs.Entities;
using Libs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_DACN.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAdminsController : ControllerBase
    {
        private LoginAdminService loginAdminService;
        public LoginAdminsController(LoginAdminService loginAdminService)
        {
            this.loginAdminService = loginAdminService;
        }
        [HttpPost]
        [Route("LogIn_Admin")]
        public IActionResult LogIn_Admin(string Name_Admin, string Pass_Admin)
        {
            LoginAdmin LG = new LoginAdmin();
            LG.Name_Admin = Name_Admin;
            LG.Pass_Admin = Pass_Admin;

            List<LoginAdmin> loginAdmins = loginAdminService.LogIn_Admin(LG);
            if (loginAdmins.Count == 0)
            {
                return NotFound(new { status = false, message = "khong co admin" });
            }
            string name = loginAdmins[0].Name_Admin;
            string pass = loginAdmins[0].Pass_Admin;
            if(name == Name_Admin && pass == Pass_Admin)          
                return Ok(new { status = true, message = "" });
            else
                return NotFound(new { status = false, message = "Nhap sai pass or username" });

        }

    }
}

