using EF_SQLServer_Persitance;
using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Doctors;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Domain.prescription;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Persistence.Prescriptions
{
    public class PrescriptionRepository : GenericRepository<Prescription, SqlServerDbContext>, IPrescriptionRepository
    {
        public PrescriptionRepository(SqlServerDbContext dbContext, ILogger<PrescriptionRepository> logger) : base(dbContext, logger)
        {
        }

        public async Task<(List<Prescription> items, int totalRows)> GetPrescriptionsListAsync(Expression<Func<Prescription, bool>> predicate, Paging paging, bool AsNoTracking = true, Func<IQueryable<Prescription>, IIncludableQueryable<Prescription, object>> include = null)
        {
            var query = _dbContext.Set<Prescription>().AsQueryable();
            query = AsNoTracking ? query.AsNoTracking() : query;
            query = include == null ? query : include(query);
            var totalRows = await query.CountAsync();
            var result = await query.Where(predicate).OrderByDescending(p => p.CreatedAt).Skip(paging.Skip()).Take(paging.PageSize).ToListAsync();
            return (result, totalRows);
        }
    }
}
