using Libs.Data;
using Libs.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface LoginAdmintRepository : IRepository<LoginAdmin>
    {
        public List<LoginAdmin> LogIn_Admin(LoginAdmin LG);

    }
    public class LoginAdminRepository : RepositoryBase<LoginAdmin>, LoginAdmintRepository
    {
        public LoginAdminRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public List<LoginAdmin> LogIn_Admin(LoginAdmin LG)
        {
            var result =  _dbContext.loginAdmin.FromSqlRaw("EXEC Proc_DangNhap_Admin " +
                " @TenDangNhap={0},@MatKhau={1}", LG.Name_Admin, LG.Pass_Admin).ToList();

            return result;
        }

    }
}


