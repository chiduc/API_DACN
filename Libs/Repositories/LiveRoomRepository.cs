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
    public interface IPLiveRepository : IRepository<LiveRoom>
    {
        public void Custom_LiveRoom(LiveRoom liv);
        public void Stop_LiveRoom(LiveRoom liv);
        public List<LiveRoom> Get_LiveRoom();
    }
    public class LiveRoomRepository : RepositoryBase<LiveRoom>, IPLiveRepository
    {
        public LiveRoomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void Custom_LiveRoom(LiveRoom liv)
        {
            _dbContext.Database.ExecuteSqlRaw("EXEC Proc_Custom_LiveRoom @Username_Client={0}", liv.Username_Client);

        }
        public void Stop_LiveRoom(LiveRoom liv)
        {
            _dbContext.Database.ExecuteSqlRaw("EXEC Proc_Stop_LiveRoom @Username_Client={0}", liv.Username_Client);
        }
        public List<LiveRoom> Get_LiveRoom()
        {
            var result = _dbContext.Liveroom.FromSqlRaw("EXEC EXEC Proc_Get_LiveRoom ").ToList();

            return result;
        }
    }
}
