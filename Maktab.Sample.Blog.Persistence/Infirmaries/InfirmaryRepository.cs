using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace Maktab.Sample.Blog.Persistence.Infirmaries;

public class InfirmaryRepository : GenericRepository<Infirmary, BlogDbContext>, IInfirmaryRepository
{
    public InfirmaryRepository(BlogDbContext dbContext, ILogger<InfirmaryRepository> logger) : base(dbContext, logger)
    {
    }

    public Task<(List<Infirmary> items, int totalRows)> GetInfirmariesListAsync(Paging paging, bool asNoTracking = true, Func<IQueryable<Infirmary>, IIncludableQueryable<Infirmary, object>> include = null)
    {
        throw new NotImplementedException();
    }
}
