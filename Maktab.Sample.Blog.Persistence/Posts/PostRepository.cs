using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Domain.Posts;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;

namespace Maktab.Sample.Blog.Persistence.Posts;

public class PostRepository : GenericRepository<Post, BlogDbContext>, IPostRepository
{
    public PostRepository(BlogDbContext dbContext, ILogger<PostRepository> logger) : base(dbContext, logger)
    {
    }

    public Task<(List<Post> items, int totalRows)> GetPostsListAsync(Paging paging, bool asNoTracking = true, Func<IQueryable<Post>, IIncludableQueryable<Post, object>> include = null)
    {
        throw new NotImplementedException();
    }
}