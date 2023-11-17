using Libs.Data;
using Libs.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface IPCllientRepository : IRepository<Client>
    {
        public void insert_Client(Client cli);
        public  List<ClientModel> login_Client(ClientModel cli);
        public void update_Client_Live(Client cli);
        public void update_Client(Client cli);
    }
    public class ClientRepository : RepositoryBase<Client> , IPCllientRepository
    {
        public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public void insert_Client(Client cli)
        {
            _dbContext.Database.ExecuteSqlRaw("EXEC Proc_insert_Client " +
                "@name_client={0}, @pass_Client={1},@ngay_sinh={2},@SDT={3}",
                cli.Name_Client, cli.Pass_Client, cli.NgaySinh, cli.SDT);
        }
        public List<ClientModel> login_Client(ClientModel cli)
        {
            var result = _dbContext.clientModels.FromSqlRaw("EXEC Proc_Login_Client @username ={0},@password={1}", 
                cli.Name_Client, cli.Pass_Client).ToList();

            return result; 
        }

        public void update_Client(Client cli)
        {
            throw new NotImplementedException();
        }

        public void update_Client_Live(Client cli)
        {
            _dbContext.Database.ExecuteSqlRaw("EXEC Proc_Update_Client_Live @id_client = {0}",cli.ID_Client);
        }
    }
}
