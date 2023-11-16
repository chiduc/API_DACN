using Libs.Data;
using Libs.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    public interface IStudentRepository : IRepository<Client>
    {
        public void insertStudent(Client Student);
    }
    public class StudentRepository : RepositoryBase<Client>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public void insertStudent(Client Student)
        {
            _dbContext.Student.Add(Student);
        }
    }
}
