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
        public List<LoginAdmin> LogIn_Admin(LoginAdmin LG)
        {
            return LoginAdminRepository.LogIn_Admin(LG);
 
        }
        public void Save()
        {
            this.dbContext.SaveChanges();
        }
    }
}
