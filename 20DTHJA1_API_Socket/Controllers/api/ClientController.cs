using API_DACN.Models;
using Libs.Entities;
using Libs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;


namespace API_DACN.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private ClientService clientService;
        public ClientController(ClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpPost]
        [Route("Login_Client")]
        public IActionResult login_Client(string username, string password)
        {
            ClientModel clientModel = new ClientModel();
            clientModel.Name_Client = username;
            clientModel.Pass_Client = password;
            List<ClientModel> cli_m = clientService.login_Client(clientModel);
        return Ok(new { status = true, message = "", data = cli_m });
        }


    }
}
