using Company.Data.Contexts;
using Company.Data.Models;
using Company_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Repository.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly CompanyDbContext _context;
        public DepartmentRepository(CompanyDbContext context) : base(context)
        {
        }

       
    }
}
