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
        public void Save()
        {
            this.dbContext.SaveChanges();
        }
        public List<ClientModel> login_Client(ClientModel cli)
        {
            return ClientRepository.login_Client(cli);
        }
        public void signIn_Client(Client cli)
        {
            ClientRepository.signIn_Client(cli);
            Save();
        }
        
/*      public void update_Client_Live(Client cli)
        {
            ClientRepository.update_Client_Live(cli);
            Save();
        }*/
    }
   

}
