using API_DACN.Models;
using Libs.Entities;
using Libs.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using API_DACN.Controllers.api;
using API_DACN.Controllers;
using _20DTHJA1_API_Socket.Controllers;
using Libs.Repositories;
using Libs;
using System.Net.Sockets;

namespace API_DACN.Controllers
{
    public class HomeController : Controller
    {
        private readonly LoginAdminService loginAdminService;

        private readonly ClientService clientService;

        //       private ApplicationDbContext dbContext;
        /*        public HomeController(ApplicationDbContext dbContext)
                {
                    this.dbContext = dbContext;
                    this.LoginAdminRepository = new LoginAdminRepository(dbContext);
                }*/
        public HomeController(LoginAdminService loginAdminService, ClientService clientService)
        {
            this.loginAdminService = loginAdminService;
            this.clientService = clientService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditUser()
        {
            return View();
        }
        public IActionResult ReportManager(string Name_Client, bool IsClientLive, int Count_RP, int ID_Is_Live, string Image_Client, string Bio, int SDT, DateTime NgaySinh, string Password_Client, int ID_Client, String Username_Client, String OutputMessage)
        {
            Client client = new Client();
/*            client.ID_Client = ID_Client;*/
            ViewBag.ID_Client = client.ID_Client;
            ViewBag.Name_Client = client.Name_Client;
            ViewBag.IsClientLive = client.IsClientLive;
            ViewBag.Count_RP = client.Count_RP;
            ViewBag.ID_Is_Live = client.ID_Is_Live;
            ViewBag.Image_Client = client.Image_Client;
            ViewBag.Bio = client.Bio;
            ViewBag.SDT = client.SDT;
            ViewBag.NgaySinh = client.NgaySinh;
            ViewBag.Password_Client = client.Password_Client;
            ViewBag.Username_Client = client.Username_Client;



            return View(ReportManager);

        }
/*        public HomeController(ClientService clientService)
        {
            this.ClientService = clientService;
        }
*/


        public IActionResult DangNhap(string Name_Admin, string Pass_Admin)
        {
            LoginAdmin loginAdmin = new LoginAdmin();

            loginAdmin.Name_Admin = Name_Admin;
            loginAdmin.Pass_Admin = Pass_Admin;
            List<LoginAdmin> loginAdmins = loginAdminService.LogIn_Admin(loginAdmin);
            if (loginAdmins.Count == 0)
            {
                return RedirectToAction("index");
            }
            string name = loginAdmins[0].Name_Admin;
            string pass = loginAdmins[0].Pass_Admin;
            if (name == Name_Admin && pass == Pass_Admin)
                return RedirectToAction("Home");
            else
            {

            }
                return RedirectToAction("index");

            
            // LoginDataHelper.InsertSupremeAdmin(ID_AT, Name_Admin, Pass_Admin);
            // Xử lý kết quả nếu cần

        }


        public static List<Report> LayDanhSachBaoCao(string chuoiKetNoi)
        {

            List<Report> danhSachBaoCao = new List<Report>();

            using (SqlConnection ketNoi = new SqlConnection(chuoiKetNoi))
            {
                ketNoi.Open();

                string cauTruyVan = "SELECT ID_RP, ID_Client, ID_LR, Time_RP, NoiDung, Status_Rp, Time_Band, HinhAnh FROM Report WHERE Report.Status_Rp = 1";

                using (SqlCommand lenh = new SqlCommand(cauTruyVan, ketNoi))
                {
                    using (SqlDataReader txt = lenh.ExecuteReader())
                    {
                        while (txt.Read())
                        {
                            Report baoCao = new Report();
                            {
                                baoCao.ID_RP = txt.GetInt32(0);
                                baoCao.ID_Client = txt.GetInt32(1);
                                baoCao.ID_LR = txt.GetInt32(2);
                                baoCao.Time_RP = txt.GetDateTime(3);
                                baoCao.NoiDung = txt.GetString(4);
                                baoCao.Status_Rp = txt.GetBoolean(5);
                                baoCao.Time_Band = txt.IsDBNull(6) ? (DateTime?)null : txt.GetDateTime(6);
                                baoCao.HinhAnh = txt.IsDBNull(7) ? null : txt.GetString(7);
                            };

                            danhSachBaoCao.Add(baoCao);
                        }
                    }
                }
            }

            return danhSachBaoCao;
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

