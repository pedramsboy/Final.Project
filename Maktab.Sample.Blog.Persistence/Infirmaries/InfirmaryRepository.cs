using Maktab.Sample.Blog.Domain.Infirmaries;
using Microsoft.Extensions.Logging;

namespace Maktab.Sample.Blog.Persistence.Infirmaries;

public class InfirmaryRepository : GenericRepository<Infirmary, BlogDbContext>, IInfirmaryRepository
{
    public InfirmaryRepository(BlogDbContext dbContext, ILogger<InfirmaryRepository> logger) : base(dbContext, logger)
    {
    }

    public async Task<List<Infirmary>> SearchInfirmaryByTitle(string infirmaryName)
    {
        return await QueryAsync(p => p.InfirmaryName.Contains(infirmaryName));
    }
}
