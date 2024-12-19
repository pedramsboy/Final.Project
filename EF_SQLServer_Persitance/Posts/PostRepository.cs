using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace EF_SQLServer_Persitance;


public class PostRepository : GenericRepository<Post, SqlServerDbContext>, IPostRepository
{
    
    public PostRepository(SqlServerDbContext dbContext, ILogger<PostRepository> logger) : base(dbContext, logger)
    {
        
    }

    public async Task<(List<Post> items, int totalRows)> GetPostsListAsync(Paging paging, bool AsNoTracking = true, Func<IQueryable<Post>, IIncludableQueryable<Post, object>> include = null)
    {
        var query = _dbContext.Set<Post>().AsQueryable();
        query = AsNoTracking ? query.AsNoTracking() : query;
        query = include == null ? query : include(query);
        var totalRows = await query.CountAsync();
        var result = await query.OrderByDescending(p => p.CreatedAt).Skip(paging.Skip()).Take(paging.PageSize).ToListAsync();
        return (result, totalRows);
    }
}