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
        public void insert_SupremeAdmin(LoginAdmin LG);

    }
    public class LoginAdminRepository : RepositoryBase<LoginAdmin>, LoginAdmintRepository
    {
        public LoginAdminRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public void insert_SupremeAdmin(LoginAdmin LG)
        {
            _dbContext.Database.ExecuteSqlRaw("EXEC Proc_insert_Admin " +
                "@ID_KTK={0}, @TenDangNhap={1},@MatKhau={2}",
                LG.ID_AT, LG.Name_Admin, LG.Pass_Admin);
        }
    }
}


