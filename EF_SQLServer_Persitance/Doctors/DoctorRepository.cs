using EF_SQLServer_Persitance;
using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Departments;
using Maktab.Sample.Blog.Domain.Doctors;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Persistence.Doctors
{
    public class DoctorRepository : GenericRepository<Doctor, SqlServerDbContext>, IDoctorRepository
    {
        public DoctorRepository(SqlServerDbContext dbContext, ILogger<DoctorRepository> logger) : base(dbContext, logger)
        {
        }

        public async Task<(List<Doctor> items, int totalRows)> GetDoctorsListAsync(Expression<Func<Doctor, bool>> predicate, Paging paging, bool AsNoTracking = true, Func<IQueryable<Doctor>, IIncludableQueryable<Doctor, object>> include = null)
        {
            var query = _dbContext.Set<Doctor>().AsQueryable();
            query = AsNoTracking ? query.AsNoTracking() : query;
            query = include == null ? query : include(query);
            var totalRows = await query.CountAsync();
            var result = await query.Where(predicate).OrderByDescending(p => p.CreatedAt).Skip(paging.Skip()).Take(paging.PageSize).ToListAsync();
            return (result, totalRows);
        }
    }
}
