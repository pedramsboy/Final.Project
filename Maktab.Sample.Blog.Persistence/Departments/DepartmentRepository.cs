using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Persistence.Departments
{
    public class DepartmentRepository : GenericRepository<Department, BlogDbContext>, IDepartmentRepository
    {
        public DepartmentRepository(BlogDbContext dbContext, ILogger<DepartmentRepository> logger) : base(dbContext, logger)
        {
        }

        public Task<(List<Department> items, int totalRows)> GetDepartmentsListAsync(Expression<Func<Department, bool>> predicate, Paging paging, bool asNoTracking = true, Func<IQueryable<Department>, IIncludableQueryable<Department, object>> include = null)
        {
            throw new NotImplementedException();
        }
    }
}
