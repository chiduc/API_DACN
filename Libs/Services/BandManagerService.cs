using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libs.Entities;
using Libs.Repositories;

namespace Libs.Services
{
    public class BandManagerService
    {
        private ApplicationDbContext dbContext;
        private IBandManagerRepository bandManagerRepository; 
        public BandManagerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.bandManagerRepository = new BandManagerRepository(dbContext); 
        }

        public List<BandManager> Band_Manager(BandManager BM)
        {
            return bandManagerRepository.Band_Manager(BM);
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }
    }
}
