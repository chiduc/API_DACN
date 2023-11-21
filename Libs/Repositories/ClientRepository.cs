using Libs.Data;
using Libs.Entities;
using Microsoft.Data.SqlClient;
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
        public void signIn_Client(Client cli);
        public  List<ClientModel> login_Client(ClientModel cli);
        public void update_Client(Client cli);
        public string Update_Client_Live(string name);
    }
    public class ClientRepository : RepositoryBase<Client> , IPCllientRepository
    {
        public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public List<ClientModel> login_Client(ClientModel cli)
        {
            var result = _dbContext.clientModels.FromSqlRaw("EXEC Proc_Login_Client @username ={0},@password={1}", 
                cli.Username_Client, cli.Password_Client).ToList();

            return result; 
        }

        public void update_Client(Client cli)
        {
            throw new NotImplementedException();
        }
        public void signIn_Client(Client cli)
        {
            _dbContext.Database.ExecuteSqlRaw("EXEC Proc_insert_Client " +
                "@Name_Client={0}, @Username_Client={1},@Password_Client={2},@ngay_sinh={3},@SDT={4}",
                cli.Name_Client, cli.Username_Client, cli.Password_Client, cli.NgaySinh, cli.SDT);
        }

        public string Update_Client_Live(string name)
        {
            string outputMessage;
            var parameters = new[]
            {
                new SqlParameter("@Username_Client", name),
                new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 4000) { Direction = ParameterDirection.Output }
             };
            _dbContext.Database.ExecuteSqlRaw("EXEC Proc_Update_Client_Live @Username_Client, @OutputMessage OUTPUT", parameters);

            outputMessage = parameters[1].Value?.ToString();

            return outputMessage;

        }
    }
}
