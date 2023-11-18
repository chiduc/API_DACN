using API_DACN.Models;
using Libs.Entities;
using Libs.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using API_DACN.Controllers.api;

namespace API_DACN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ProductService productService;

        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;

        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditUser()
        {
            return View();
        }
        public IActionResult ReportManager()
        {
            return View();
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
        /*   public IActionResult ReportManager()
           {
               {
                   // Tạo danh sách báo cáo với dữ liệu giả mạo
                   List<Report> reports = new List<Report>
           {
               new Report { Id = 1, Title = "Báo cáo 1", Content = "Nội dung báo cáo 1", ReportDate = DateTime.Now.AddDays(-3), Reporter = "Người báo cáo 1", ReportedUser = "Người bị báo cáo 1", UserStatus = "Đang khóa", LockExpiration = DateTime.Now.AddDays(7) },
               new Report { Id = 2, Title = "Báo cáo 2", Content = "Nội dung báo cáo 2", ReportDate = DateTime.Now.AddDays(-2), Reporter = "Người báo cáo 2", ReportedUser = "Người bị báo cáo 2", UserStatus = "Chưa khóa" },
               new Report { Id = 1, Title = "Báo cáo 3", Content = "Nội dung báo cáo 3", ReportDate = DateTime.Now.AddDays(-1), Reporter = "Người báo cáo 1", ReportedUser = "Người bị báo cáo 1", UserStatus = "Chưa khóa" },
                   new Report { Id = 1, Title = "Báo cáo 3", Content = "Nội dung báo cáo 3", ReportDate = DateTime.Now.AddDays(-1), Reporter = "Người báo cáo 1", ReportedUser = "Người bị báo cáo 1", UserStatus = "Chưa khóa" },
               // Thêm các báo cáo khác nếu cần
           };

                   reports = Report.CalculateReportCount(reports);


                   // Truyền danh sách báo cáo cho View
                   return View(reports);
               }
           }*/




        /*           public static List<Report> CalculateReportCount(List<Report> reports)
                   {
                       var groupedReports = reports
                           .GroupBy(r => r.Id)
                           .Select(g => new Report
                           {
                               Id = g.Key,
                               ReportCount = g.Count(),
                               // Giữ lại các thuộc tính khác của Report
                               Title = g.First().Title,
                               Content = g.First().Content,
                               ReportDate = g.First().ReportDate,
                               Reporter = g.First().Reporter,
                               ReportedUser = g.First().ReportedUser,
                               // Thêm các thuộc tính khác nếu có
                           })
                           .ToList();

                       return groupedReports;
                   }*/
    


    public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public bool IsLocked { get; set; }
            public DateTime? LockExpiration { get; set; }

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

