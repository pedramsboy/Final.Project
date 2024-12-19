using EF_SQLServer_Persitance;
using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace Maktab.Sample.Blog.Persistence.Infirmaries;

public class InfirmaryRepository : GenericRepository<Infirmary, SqlServerDbContext>, IInfirmaryRepository
{
    

    public InfirmaryRepository(SqlServerDbContext dbContext, ILogger<InfirmaryRepository> logger) : base(dbContext, logger)
    {
        
    }

    public async Task<(List<Infirmary> items, int totalRows)> GetInfirmariesListAsync(Paging paging, bool AsNoTracking = true, Func<IQueryable<Infirmary>, IIncludableQueryable<Infirmary, object>> include = null)
    {
        var query = _dbContext.Set<Infirmary>().AsQueryable();
        query = AsNoTracking ? query.AsNoTracking() : query;
        query = include == null ? query : include(query);
        var totalRows = await query.CountAsync();
        var result = await query.OrderByDescending(p => p.CreatedAt).Skip(paging.Skip()).Take(paging.PageSize).ToListAsync();
        return (result, totalRows);
    }
}
