using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore.Query;

namespace Maktab.Sample.Blog.Domain.Infirmaries;

public interface IInfirmaryRepository : IGenericRepository<Infirmary>
{
    Task<(List<Infirmary> items, int totalRows)> GetInfirmariesListAsync(Paging paging, bool asNoTracking = true,
          Func<IQueryable<Infirmary>, IIncludableQueryable<Infirmary, object>> include = null);
}