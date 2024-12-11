using Maktab.Sample.Blog.Domain.Posts;
using Maktab.Sample.Blog.Persistence;
using Microsoft.Extensions.Logging;
namespace EF_SQLServer_Persitance;


public class PostRepository : GenericRepository<Post, SqlServerDbContext>, IPostRepository
{
    private readonly SqlServerDbContext _dbContext;
    public PostRepository(SqlServerDbContext dbContext, ILogger<PostRepository> logger) : base(dbContext, logger)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Post>> SearchPostsByTitle(string title)
    {
       //var comments= _dbContext.Comments.Where(x => x.AuthorId == new Guid()).ToList();
        return await QueryAsync(p => p.Title.Contains(title));
    }
}