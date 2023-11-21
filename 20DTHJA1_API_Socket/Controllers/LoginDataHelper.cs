using Microsoft.AspNetCore.Mvc;
using Libs.Services;
using Libs.Entities;

namespace _20DTHJA1_API_Socket.Controllers
{
    public static class LoginDataHelper
    {
        public static void InsertSupremeAdmin(int ID_AT, string Name_Admin, string Pass_Admin)
        {
            // Thực hiện lưu dữ liệu hoặc xử lý dữ liệu ở đây
            // Ví dụ: 
            LoginAdmin loginAdmin = new LoginAdmin();loginAdmin.ID_AT = ID_AT;

            loginAdmin.Name_Admin = Name_Admin;
            loginAdmin.Pass_Admin = Pass_Admin;
            
/*            LoginAdminService.insert_SupremeAdmin(loginAdmin);*/
        }
    }
}
