using EF_SQLServer_Persitance;
using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore;
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
    public class DepartmentRepository : GenericRepository<Department, SqlServerDbContext>, IDepartmentRepository
    {
        public DepartmentRepository(SqlServerDbContext dbContext, ILogger<DepartmentRepository> logger) : base(dbContext, logger)
        {
        }

        public async Task<(List<Department> items, int totalRows)> GetDepartmentsListAsync(Expression<Func<Department, bool>> predicate, Paging paging, bool AsNoTracking = true, Func<IQueryable<Department>, IIncludableQueryable<Department, object>> include = null)
        {
            var query = _dbContext.Set<Department>().AsQueryable();
            query = AsNoTracking ? query.AsNoTracking() : query;
            query = include == null ? query : include(query);
            var totalRows = await query.CountAsync();
            var result = await query.Where(predicate).OrderByDescending(p => p.CreatedAt).Skip(paging.Skip()).Take(paging.PageSize).ToListAsync();
            return (result, totalRows);
        }
    }
}
