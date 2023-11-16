using Libs.Data;
using Libs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface IPCllientRepository : IRepository<Client>
    {
        public void insert_Client(LiveRoom lie);
    }
    public class ClientRepository
    {

    }
}
