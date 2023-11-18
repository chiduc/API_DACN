using API_DACN.Models;
using Libs.Entities;
using Libs.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_DACN.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveRoomsController : ControllerBase
    {
        private LiveRoomService liveRoomService;
        public LiveRoomsController(LiveRoomService liveRoomService)
        {
            this.liveRoomService = liveRoomService;
        }
        [HttpPost]
        [Route("insert_live")]
        public IActionResult insert_live(int id_client)
        {
            LiveRoom LR = new LiveRoom();
            LR.ID_Client = id_client;

            liveRoomService.insertLive(LR);
            return Ok(new { status = true, message = "" });
        }

    }
}
