﻿using Libs.Data;
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
        public void insertLive(LiveRoom lie);
        public void delete_live(LiveRoom lie);
    }
    public class LiveRoomRepository : RepositoryBase<LiveRoom>, IPLiveRepository
    {
        public LiveRoomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public void insertLive(LiveRoom lie)
        {
            _dbContext.Database.ExecuteSqlRaw("EXEC Proc_Insert_LiveRoom @Id_client={0}", lie.ID_Client);
            //_dbContext.Live.Add(lie);
        }
        

        public void delete_live(LiveRoom lie)
        {
            if (lie == null)
            {
                return;
            }
            else
            {
                _dbContext.Liveroom.Remove(lie);
            }
        }
    }
}