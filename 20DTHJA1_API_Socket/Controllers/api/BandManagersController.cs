using Libs.Entities;
using Libs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_DACN.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandManagersController : ControllerBase
    {
        private BandManagerService bandManagerService;

        public BandManagersController(BandManagerService bandManagerService)
        {
            this.bandManagerService = bandManagerService;
        }

        [HttpPost]
        [Route("SearchBandManager")]
        public IActionResult SearchBandManager(string usernameClient, string idClient)
        {
            BandManager BM = new BandManager();
         /*   BM.UsernameClient = usernameClient;*/
            BM.ID_Client = int.Parse(idClient); // Chuyển đổi string thành int để gán cho ID_Client

            var result = bandManagerService.Band_Manager(BM);

            if (result.Count == 0)
            {
                return NotFound(new { status = false, message = "Không tìm thấy Band Manager" });
            }

            // Thay đổi điều kiện kiểm tra tùy thuộc vào logic của bạn
            if (result[0].Status_Rp == true) // Sử dụng Status_Rp để làm điều kiện kiểm tra
            {
                return Ok(new { status = true, message = "Tìm thấy Band Manager", data = result });
            }
            else
            {
                return NotFound(new { status = false, message = "Điều kiện không đúng" });
            }
        }
    }
}
