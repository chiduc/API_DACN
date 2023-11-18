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
        [Route("insert_SupremeAdmin")]
        public IActionResult insert_SupremeAdmin(int ID_AT, string Name_Admin, string Pass_Admin)
        {
            LoginAdmin LG = new LoginAdmin();
            LG.ID_AT = ID_AT;
            LG.Name_Admin = Name_Admin;
            LG.Pass_Admin = Pass_Admin;


            loginAdminService.insert_SupremeAdmin(LG);
            return Ok(new { status = true, message = "" });
        }

    }
}

