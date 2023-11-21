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
        public void Custom_LiveRoom(LiveRoom liv)
        {
            LiveRepository.Custom_LiveRoom(liv);


        }
        public void Stop_LiveRoom(LiveRoom liv)
        {
            LiveRepository.Stop_LiveRoom(liv);

        }
        public  List<LiveRoom> Get_LiveRoom()
        {
            return LiveRepository.Get_LiveRoom();
        }
    }


}
