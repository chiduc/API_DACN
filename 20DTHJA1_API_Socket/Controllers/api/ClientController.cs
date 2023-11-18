using API_DACN.Models;
using Libs.Entities;
using Libs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;

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

            if (cli_m.IsNullOrEmpty())
            {
                return NotFound(new { status = false, message = "khong co usser" });
            }
        return Ok(new { status = true, message = "", data = cli_m });
        }
        [HttpPost]
        [Route("SignIn_Client")]
        public IActionResult signIn_Client(string username, string password,DateTime ngaysinh, int SDT)
        {
            Client cli = new Client();
            cli.Name_Client = username;
            cli.Pass_Client = password;
            cli.NgaySinh = ngaysinh;
            cli.SDT = SDT;
            clientService.signIn_Client(cli);
            return Ok(new { status = true, });

        }

    }
}
