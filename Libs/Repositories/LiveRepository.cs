using Libs.Data;
using Libs.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface IPLiveRepository : IRepository<Live>
    {
        public void insertLive(Live lie);
        public void delete_live(Live lie);
    }
    public class LiveRepository : RepositoryBase<Live>, IPLiveRepository
    {
        public LiveRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void insertLive(Live lie)
        {
            _dbContext.Database.ExecuteSqlRaw("EXEC dbo.InsertLive @IdLive={0}, @NameLive={1}", lie.idLive,lie.name);
            //_dbContext.Live.Add(lie);
        }
        

        public void delete_live(Live lie)
        {
            if (lie == null)
            {
                return;
            }
            else
            {
                _dbContext.Live.Remove(lie);
            }
        }
    }
}
