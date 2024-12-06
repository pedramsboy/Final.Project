using EF_SQLServer_Persitance;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Microsoft.Extensions.Logging;

namespace Maktab.Sample.Blog.Persistence.Infirmaries;

public class InfirmaryRepository : GenericRepository<Infirmary, SqlServerDbContext>, IInfirmaryRepository
{
    public InfirmaryRepository(SqlServerDbContext dbContext, ILogger<InfirmaryRepository> logger) : base(dbContext, logger)
    {
    }

    public async Task<List<Infirmary>> SearchInfirmaryByTitle(string infirmaryName)
    {
        return await QueryAsync(p => p.InfirmaryName.Contains(infirmaryName));
    }
}
