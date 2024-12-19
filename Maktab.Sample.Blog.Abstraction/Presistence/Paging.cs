using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maktab.Sample.Blog.Abstraction.Presistence
{
    public class Paging
    {
        public int PageSize { get; set; } = 3;
        public int PageNumber { get; set; } = 0;

        public int Skip() => PageNumber * PageSize;
    }
}
