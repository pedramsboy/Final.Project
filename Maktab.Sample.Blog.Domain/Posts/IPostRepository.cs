using Maktab.Sample.Blog.Abstraction.Domain;
using Maktab.Sample.Blog.Abstraction.Presistence;
using Microsoft.EntityFrameworkCore.Query;
using System.Net.NetworkInformation;

namespace Maktab.Sample.Blog.Domain.Posts;

public interface IPostRepository : IGenericRepository<Post>
{
    Task<(List<Post> items, int totalRows)> GetPostsListAsync(Paging paging, bool asNoTracking = true,
         Func<IQueryable<Post>, IIncludableQueryable<Post, object>> include = null);
}