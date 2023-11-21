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
/*        Get_LiveRoom
        Stop_LiveRoom
        [HttpPost]*/
        [Route("insert_live")]
        public IActionResult Custom_LiveRoom(int id_client)
        {
            LiveRoom LR = new LiveRoom();
            LR.ID_Client = id_client;

            liveRoomService.Custom_LiveRoom(LR);
            return Ok(new { status = true, message = "" });
        }

    }
}
