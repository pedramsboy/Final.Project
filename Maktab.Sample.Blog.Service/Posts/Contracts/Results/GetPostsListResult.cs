using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Abstraction.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Posts.Contracts.Results
{
    public class GetPostsListResult:BasePaginatedListResult<PostArgs>
    {
        public GetPostsListResult()
        {

        }
        public GetPostsListResult(List<PostArgs> items, int totalRows, int pageSize, int pageNumber)
        {
            Items = items;
            TotalRows = totalRows;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public GetPostsListResult(List<PostArgs> items, int totalRows, Paging paging)
        {
            Items = items;
            TotalRows = totalRows;
            PageSize = paging.PageSize;
            PageNumber = paging.PageNumber;
        }
    }
}
