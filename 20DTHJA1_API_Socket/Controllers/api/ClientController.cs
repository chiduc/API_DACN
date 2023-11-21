using API_DACN.Models;
using Libs.Entities;
using Libs.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

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
            clientModel.Username_Client = username;
            clientModel.Password_Client = password;
            List<ClientModel> cli_m = clientService.login_Client(clientModel);

            if (cli_m.IsNullOrEmpty())
            {
                return NotFound(new { status = false, message = "khong co usser" });
            }
        return Ok(new { status = true, message = "", data = cli_m });
        }
        [HttpPost]
        [Route("SignIn_Client")]
        public IActionResult signIn_Client(string name,string username, string password,DateTime ngaysinh, int SDT)
        {
            Client cli = new Client();
            cli.Name_Client = name;
            cli.Username_Client = username;
            cli.Password_Client = password;
            cli.NgaySinh = ngaysinh;
            cli.SDT = SDT;
            clientService.signIn_Client(cli);
            return Ok(new { status = true, });

        }
        [HttpPost]
        [Route("Update_Client_Live")]
        public IActionResult Update_Client_Live(string name)
        {
            string message = clientService.Update_Client_Live(name);
            return Ok(new { status = true, message = message});
        }

        [HttpPost]
        [Route("insert_Product")]

        public IActionResult insert_Product(string nameclient, string nameprod,int slprod,int giaprod,string mota)
        {
            Product product = new Product();
            product.Name_Client = nameclient;
            product.Name_prod = nameprod;
            product.SL_Prod = slprod;
            product.Gia_Prod = giaprod;
            product.MoTa = mota;
            //clientService.insert_Product(product);
            return Ok(new { status = true, });
        }

    }
}
