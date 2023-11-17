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
    public class LiveRoomService
    {
        private ApplicationDbContext dbContext;
        private IPLiveRepository LiveRepository;

        public LiveRoomService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.LiveRepository = new LiveRoomRepository(dbContext);
        }
        public void Save()
        {
            this.dbContext.SaveChanges();
        }
        public void insertLive(LiveRoom lie)
        {
            LiveRepository.insertLive(lie);
            Save();

        }
        public void delete_live(LiveRoom lie)
        {
            if (lie != null)
            {
                LiveRepository.delete_live(lie);
                Save();
            }

        }
    }


}
