using EF_SQLServer_Persitance;
using Maktab.Sample.Blog.Domain.Infirmaries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Maktab.Sample.Blog.Persistence.Infirmaries;

public class InfirmaryRepository : GenericRepository<Infirmary, SqlServerDbContext>, IInfirmaryRepository
{
    private readonly SqlServerDbContext _context;

    public InfirmaryRepository(SqlServerDbContext dbContext, ILogger<InfirmaryRepository> logger) : base(dbContext, logger)
    {
        _context = dbContext;
    }

    public async Task<List<Infirmary>> GetAllInfirmaries()
    {
        return  await _context.Infirmaries.Include(x => x.Departments).ToListAsync();
    }

    public async Task<List<Infirmary>> SearchInfirmaryByTitle(string infirmaryName)
    {
        return await QueryAsync(p => p.InfirmaryName.Contains(infirmaryName));
    }
}
