using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Libs.Data;
using Libs.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Libs.Repositories
{
    public interface IBandManagerRepository : IRepository<BandManager> 
    {
        List<BandManager> Band_Manager(BandManager BM);
    }

    public class BandManagerRepository : RepositoryBase<BandManager>, IBandManagerRepository 
    {
        public BandManagerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public List<BandManager> Band_Manager(BandManager BM)
        {
            var result = _dbContext.bandManagers.FromSqlRaw("EXEC Proc_Custom_LiveRoom " +
                " @Username_Client={0},@OutputMessage={1}", BM.ID_Client, BM.NoiDung).ToList();

            return result;
        }
    }
}

