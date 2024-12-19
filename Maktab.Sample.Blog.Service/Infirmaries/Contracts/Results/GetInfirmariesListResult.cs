using Maktab.Sample.Blog.Abstraction.Presistence;
using Maktab.Sample.Blog.Abstraction.Service;
using Maktab.Sample.Blog.Service.Posts.Contracts.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Service.Infirmaries.Contracts.Results
{
    public class GetInfirmariesListResult : BasePaginatedListResult<InfirmaryArgs>
    {
        public GetInfirmariesListResult()
        {

        }
        public GetInfirmariesListResult(List<InfirmaryArgs> items, int totalRows, int pageSize, int pageNumber)
        {
            Items = items;
            TotalRows = totalRows;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public GetInfirmariesListResult(List<InfirmaryArgs> items, int totalRows, Paging paging)
        {
            Items = items;
            TotalRows = totalRows;
            PageSize = paging.PageSize;
            PageNumber = paging.PageNumber;
        }
    }
}
