using Libs.Entities;
using Libs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Services
{
    public class LoginAdminService
    {
        private ApplicationDbContext dbContext;
        private LoginAdmintRepository LoginAdminRepository;
        public LoginAdminService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.LoginAdminRepository = new LoginAdminRepository(dbContext);
        }
        public void insert_SupremeAdmin(LoginAdmin LG)
        {
            LoginAdminRepository.insert_SupremeAdmin(LG);
            Save();
        }
        public void Save()
        {
            this.dbContext.SaveChanges();
        }
    }
}
