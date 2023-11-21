using Libs.Entities;
using Libs.Repositories;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Services
{
    public class ClientService
    {
        private ApplicationDbContext dbContext;
        private IPCllientRepository ClientRepository;

        public ClientService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.ClientRepository = new ClientRepository(dbContext);
        }
        public List<ClientModel> login_Client(ClientModel cli)
        {
            return ClientRepository.login_Client(cli);
        }
        public void signIn_Client(Client cli)
        {
            ClientRepository.signIn_Client(cli);

        }
        public string Update_Client_Live(string name)
        {
            string outputMessage;
            outputMessage = ClientRepository.Update_Client_Live(name);
            return outputMessage;

        }
    }
   

}
